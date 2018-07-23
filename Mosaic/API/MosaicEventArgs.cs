using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace API
{
    public class MosaicEventArgs: EventArgs
    {
        public string TilePath
        {
            get;
            set;
        }

        public Color TileColor
        {
            get;
            set;
        }

        public Color TileAverage
        {
            get;
            set;
        }

        public int CurrentY
        {
            get;
            set;
        }

        public int CurrentX
        {
            get;
            set;
        }

        public int Y
        {
            get;
            set;
        }

        public int X
        {
            get;
            set;
        }

        public double MaximumTiles
        {
            get;
            set;
        }

        public int Percentage
        {
            get;
            set;
        }
    }
}
