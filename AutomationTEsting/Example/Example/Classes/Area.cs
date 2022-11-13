namespace Example.Classes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Area
    {
        public Area(int value)
        {
            Value = value;
        }

        public static Area operator +(Area a1, Area a2)
        {
            return new Area(a1.Value + a2.Value);
        }

        public int Value { get; }
    }
}
