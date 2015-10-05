using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using Mosaic;

namespace UnitTest
{
    [TestClass]
    public class ColorsCalculationTest
    {
        private ColorsCalculation.ColorCalculation mosaicObject;
        private const string testPicturePath = @"D:\Skydrive\Obrazy\2012\Kupimierz 20 - 23.07.12r\20120720_171757.jpg";
        private Image image;
        private Context ctx;

        [TestInitialize]
        public void Initialize()
        {
            try
            {
                this.mosaicObject = new ColorsCalculation.ColorCalculation();
                this.image = Image.FromFile(testPicturePath);
                this.ctx = new Context();

            }
            catch (Exception)
            {

                throw;
            }
        }

        [TestMethod]
        public void TestCalculateColors()
        {
            decimal height, width;
            this.ctx.CalculateHeightAndWidthImage(this.image, out height, out width);
            //public void CalculateColorsWork(object sender, System.ComponentModel.DoWorkEventArgs e)
            System.ComponentModel.DoWorkEventArgs e = new System.ComponentModel.DoWorkEventArgs(new object[]{this.image, height, width});

            this.mosaicObject.CalculateColorsWork(null, e);
            Assert.IsNotNull(this.mosaicObject.avgsMaster, "avgsMaster field is null");
        }
    }
}
