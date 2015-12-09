using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace API
{
    public delegate void ColorsEventHandler(ColorCalculationEventArgs color);
    
    /// <summary>
    /// 
    /// </summary>
    public abstract class ACalculateColors
    {
        /// <summary>
        /// Occurs when color is calculated for specific tile
        /// </summary>
        public event ColorsEventHandler ColorCalculated;

        public abstract Image CalculateColors(string fileName, out Color[,] color);

        /// <summary>
        /// Fire this method when color will be calculated
        /// </summary>
        /// <param name="color">Calculated color on specific field</param>
        /// <param name="tx">x param of image</param>
        /// <param name="ty">y param of image</param>
        public virtual void OnColorCalculated(Color color, int tx, int ty, int x, int y){
            if (ColorCalculated != null){
                ColorCalculated(new ColorCalculationEventArgs()
                {
                    AmountOfX =x,
                    AmountOfY =y,
                    Color = color,
                    x = tx,
                    y = ty
                });
            }
        }

    }
}
