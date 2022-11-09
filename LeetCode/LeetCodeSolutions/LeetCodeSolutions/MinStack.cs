namespace LeetCodeSolutions
{
    public class MinStack
    {
        private const int arraySize = 10000;
        private int[] array;
        private int i;

        public MinStack()
        {
            array = new int[arraySize];
            i = -1;
        }

        public void Push(int val)
        {
            array[++i] = val;
        }

        public void Pop()
        {
            array[i--] = 0;
        }

        public int Top()
        {
            return array[i];
        }

        public int GetMin()
        {
            int min = int.MaxValue;
            for (int k = 0; k <= i; k++)
            {
                if (array[k] < min)
                {
                    min = array[k];
                }
            }
            return min;
        }
    }
}
