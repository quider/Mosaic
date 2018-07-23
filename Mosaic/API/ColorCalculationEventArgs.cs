using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace API
{
    public class ColorCalculationEventArgs : EventArgs
    {
        public Color Color
        {
            get;
            set;
        }

        public int x
        {
            get;
            set;
        }

        public int y
        {
            get;
            set;
        }

        public int AmountOfX
        {
            get;
            set;
        }

        public int AmountOfY
        {
            get;
            set;
        }
    }
}
