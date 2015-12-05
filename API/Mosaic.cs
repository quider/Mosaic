using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API
{
    public delegate void MosaicEventHandler(Mosaic sender, MosaicEventArgs e);

    public abstract class Mosaic
    {
        public event MosaicEventHandler TileFit;
        public event MosaicEventHandler TileDontFit;
        public event MosaicEventHandler Calculated;
        public event MosaicEventHandler TilePlaced;
        public event MosaicEventHandler TileSkipped;

        public virtual void CalculateMosaic(object sender, DoWorkEventArgs e)
        {
        
        }
    }
}
