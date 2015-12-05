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
    }
}
