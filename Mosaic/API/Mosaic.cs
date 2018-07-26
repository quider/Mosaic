using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API {
    public delegate void MosaicEventHandler(Mosaic sender, MosaicEventArgs e);

    public abstract class Mosaic {
        public event MosaicEventHandler TileFit;
        public event MosaicEventHandler TileDontFit;
        public event MosaicEventHandler Calculated;
        public event MosaicEventHandler TilePlaced;
        public event MosaicEventHandler TileSkipped;
        public event MosaicEventHandler TileAverageColorCalculated;

        public abstract Image CalculateMosaic(Image averageImage, Color[,] colorMatrix, List<string> tilesNames);

        protected virtual void OnTileFit(Mosaic mosaic, MosaicEventArgs eventArgs) {
            if (TileFit != null) {
                TileFit(mosaic, eventArgs);
            }
        }

        protected virtual void OnTileDontFit(Mosaic mosaic, MosaicEventArgs eventArgs) {
            if (TileDontFit != null) {
                TileDontFit(mosaic, eventArgs);
            }
        }

        protected virtual void OnCalculated(Mosaic mosaic, MosaicEventArgs eventArgs) {
            if (Calculated != null) {
                Calculated(mosaic, eventArgs);
            }
        }

        protected virtual void OnTilePlaced(Mosaic mosaic, MosaicEventArgs eventArgs) {
            if (TilePlaced != null) {
                TilePlaced(mosaic, eventArgs);
            }
        }

        protected virtual void OnTileSkipped(Mosaic mosaic, MosaicEventArgs eventArgs) {
            if (TileSkipped != null) {
                TileSkipped(mosaic, eventArgs);
            }
        }

        /// <summary>
        /// Should be fired when average color of tile is calculated
        /// </summary>
        /// <param name="mosaic"></param>
        /// <param name="eventArgs"></param>
        protected virtual void OnTileAverageColorCalculated(Mosaic mosaic, MosaicEventArgs eventArgs) {
            if (TileSkipped != null) {
                TileSkipped(mosaic, eventArgs);
            }
        }
    }
}
