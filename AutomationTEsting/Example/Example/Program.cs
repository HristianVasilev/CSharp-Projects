using Example.Classes;
using System.Net.Http.Headers;

Area a1 = new Area(10);
Area a2 = new Area(20);

Area a3 = a1 + a2;

Console.WriteLine(a3.Value);