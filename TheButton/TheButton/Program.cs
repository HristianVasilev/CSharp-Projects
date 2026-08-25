// State Variables
const int STARTING_SECONDS = 108;
const string CORRECT_CODE = "4 8 15 16 23 42";
const int RESET_DELAY_MS = 3000; // 3-second confirmation delay

// Sound Parameters - Normal Phase (> 10s)
const int normalPitch = 2700;
const int normalPulseMs = 80;
const int normalGapMs = 1400;

// Sound Parameters - Emergency Phase (<= 10s)
const int urgentPitch = 2900;
const int urgentPulseMs = 60;
const int urgentGapMs = 40;

// Console Screen Layout Rows
const int timerLineRow = 0;
const int inputLineRow = 6;
const int statusLineRow = 8;

// Define a 5-row ASCII font representation for digits 0 through 9
string[][] asciiFont =
[
	[" ### ", "#   #", "#   #", "#   #", " ### "], // 0
	["  #  ", " ##  ", "  #  ", "  #  ", " ### "], // 1
	[" ### ", "    #", " ### ", "#    ", "#####"], // 2
	["#####", "    #", " ### ", "    #", "#####"], // 3
	["#   #", "#   #", "#####", "    #", "    #"], // 4
	["#####", "#    ", "#### ", "    #", "#####"], // 5
	[" ### ", "#    ", "#### ", "#   #", " ### "], // 6
	["#####", "    #", "   # ", "  #  ", " #   "], // 7
	[" ### ", "#   #", " ### ", "#   #", " ### "], // 8
	[" ### ", "#   #", " ####", "    #", " ### "]  // 9
];

int remainingSeconds = STARTING_SECONDS;
bool isFailed = false;
bool isPaused = false; // Flag to freeze countdown tick

using var cancellationTokenSource = new CancellationTokenSource();
CancellationToken token = cancellationTokenSource.Token;

// Start Background Tasks
Task alarmTask = Task.Run(() => PlayHatchAlarmLoop(token), token);
Task timerTask = Task.Run(() => RunCountdownTimer(token), token);

const ConsoleColor DEFAULT_CONSOLE_FOREGROUND_COLOR = ConsoleColor.Green;
ResetDefauldConsoleForegroundColor();
RenderInputPrompt();

// Main Thread: Asynchronous Command Line Processing Loop
while (!token.IsCancellationRequested && remainingSeconds > 0 && !isFailed)
{
	// Initiate line reading on a background task so background timer tasks keep ticking
	Task<string?> readLineTask = Task.Run(() => Console.ReadLine(), token);

	// Non-blocking wait loop checking for input completion or timer expiration
	while (!readLineTask.IsCompleted)
	{
		if (remainingSeconds <= 0 || token.IsCancellationRequested)
			break;

		await Task.Delay(100);
	}

	if (token.IsCancellationRequested || remainingSeconds <= 0)
		break;

	string? inputLine = await readLineTask;
	if (inputLine == null) continue;

	string command = inputLine.Trim();

	// 1. Process "kill" command -> Graceful Cancellation
	if (command.Equals("kill", StringComparison.OrdinalIgnoreCase))
	{
		UpdateStatus("TERMINATING SYSTEM VIA KILL COMMAND...", ConsoleColor.Yellow);
		cancellationTokenSource.Cancel();
		break;
	}
	// 2. Process correct code -> Freeze timer, display status, wait 3s, unfreeze
	else if (command == CORRECT_CODE)
	{
		isPaused = true;
		remainingSeconds = STARTING_SECONDS;
		ClearConsole();
		PrintCurrentTime(timerLineRow, asciiFont, remainingSeconds);

		// Hold countdown at 108 for 3 seconds
		await Task.Delay(RESET_DELAY_MS, token);

		isPaused = false;
	}
	// 3. Process invalid command -> System Failure
	else
	{
		isFailed = true;
		UpdateStatus("SYSTEM FAILURE! Incorrect code entered.", ConsoleColor.Red);
		cancellationTokenSource.Cancel();
		break;
	}

	RenderInputPrompt();
}

// Stop background threads safely
if (!cancellationTokenSource.IsCancellationRequested)
{
	cancellationTokenSource.Cancel();
}

await Task.WhenAll(alarmTask, timerTask);

// Print Final Output Below Status Area
Console.SetCursorPosition(0, statusLineRow + 2);
if (isFailed || remainingSeconds <= 0)
{
	Console.ForegroundColor = ConsoleColor.Red;
	Console.WriteLine("==============================================");
	Console.WriteLine("       [SYSTEM FAILURE - HATCH LOCKDOWN]      ");
	Console.WriteLine("==============================================");
	Console.ResetColor();
}
else
{
	Console.ForegroundColor = ConsoleColor.Green;
	Console.WriteLine("[SYSTEM SHUTDOWN] Program stopped via kill command.");
	Console.ResetColor();
}

// ==============================================================================
// Local Functions
// ==============================================================================

void RenderInputPrompt()
{
	lock (Console.Out)
	{
		Console.SetCursorPosition(0, inputLineRow);
		Console.Write(">: ".PadRight(65));
		Console.SetCursorPosition(3, inputLineRow);
	}
}

void UpdateStatus(string message, ConsoleColor color)
{
	lock (Console.Out)
	{
		Console.SetCursorPosition(0, statusLineRow);
		Console.ForegroundColor = color;
		Console.Write(message.PadRight(65));
		Console.ResetColor();
	}
}

async Task RunCountdownTimer(CancellationToken cancellationToken)
{
	try
	{
		while (remainingSeconds > 0 && !cancellationToken.IsCancellationRequested)
		{
			PrintCurrentTime(timerLineRow, asciiFont, remainingSeconds);
			await Task.Delay(1000, cancellationToken);

			// Decrement remaining seconds only if the timer is not in a paused state
			if (!isPaused)
			{
				remainingSeconds--;
			}
		}
	}
	catch (OperationCanceledException)
	{
		// Graceful exit on cancellation
	}
}

void PrintCurrentTime(int timerLineRow, string[][] asciiFont, int remainingSeconds)
{
	lock (Console.Out)
	{
		int currentLeft = Console.CursorLeft;
		int currentTop = Console.CursorTop;

		Console.ForegroundColor = GetBackgroundColorBasedOnTimerSeconds(remainingSeconds);
		Console.SetCursorPosition(0, timerLineRow);

		RenderBigNumber(remainingSeconds, asciiFont);

		Console.SetCursorPosition(currentLeft, currentTop);
		ResetDefauldConsoleForegroundColor();
	}
}

void PlayHatchAlarmLoop(CancellationToken cancelToken)
{
	try
	{
		while (!cancelToken.IsCancellationRequested)
		{
			if (remainingSeconds <= 10)
			{
				if (!PlayBeepSafe(urgentPitch, urgentPulseMs, cancelToken)) break;
				Thread.Sleep(urgentGapMs);
			}
			else if (remainingSeconds <= 30 && remainingSeconds > 10)
			{
				if (!PlayBeepSafe(normalPitch, normalPulseMs, cancelToken)) break;
				Thread.Sleep(normalGapMs);
			}
			else
			{
				Thread.Sleep(250);
			}
		}
	}
	catch (OperationCanceledException)
	{
		// Graceful exit on cancellation
	}

	bool PlayBeepSafe(int frequency, int duration, CancellationToken cancelToken)
	{
		if (cancelToken.IsCancellationRequested)
			return false;

		if (OperatingSystem.IsWindows())
		{
			Console.Beep(frequency, duration);
		}
		return !cancelToken.IsCancellationRequested;
	}
}

void RenderBigNumber(int number, string[][] font)
{
	string numberText = number.ToString();
	int fontHeight = font[0].Length;

	for (int row = 0; row < fontHeight; row++)
	{
		string rowOutput = "";

		foreach (char digitChar in numberText)
		{
			if (char.IsDigit(digitChar))
			{
				int digitIndex = digitChar - '0';
				rowOutput += font[digitIndex][row] + "  ";
			}
		}

		Console.WriteLine(rowOutput.PadRight(50));
	}
}

static ConsoleColor GetBackgroundColorBasedOnTimerSeconds(int remainingSeconds)
{
	if (remainingSeconds <= 10)
	{
		return ConsoleColor.Red;
	}
	else if (remainingSeconds <= 30 && remainingSeconds > 10)
	{
		return ConsoleColor.Yellow;
	}
	return ConsoleColor.White;
}

static void ResetDefauldConsoleForegroundColor()
{
	lock (Console.Out)
	{
		Console.ForegroundColor = DEFAULT_CONSOLE_FOREGROUND_COLOR;
	}
}

static void ClearConsole()
{
	lock (Console.Out)
	{
		Console.Clear();
	}
}