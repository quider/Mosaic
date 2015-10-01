using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mosaic;

namespace UnitTest
{
    [TestClass]
    public class TestContext
    {
        private Mosaic.Context ctx;
        private const string testPicturePath = @"D:\Skydrive\Obrazy\2012\Kupimierz 20 - 23.07.12r\20120720_171757.jpg";

        [TestInitialize]
        public void Initialize()
        {
            ctx = new Mosaic.Context();
        }

        [TestMethod]
        public void TestCreateMainForm()
        {
            var mainForm = ctx.CreateMainForm();
            Assert.IsNotNull(mainForm);
        }

        [TestMethod]
        public void TestBrowse()
        {
            var image = ctx.LoadPicture(testPicturePath);
            Assert.IsNotNull(image);
        }

        [TestMethod]
        public void TestCalculateHeightAndWithImage()
        {
            var image = ctx.LoadPicture(testPicturePath);
            decimal width, height;
            bool value = ctx.CalculateHeightAndWidthImage(image, out height, out width);
            Assert.IsTrue(value, "CalculateHeightAndWidthImage went wrongly");
            Assert.IsTrue(height > 0, "Height is not bigger than 0");
            Assert.IsTrue(width > 0, "Width is not bigger than 0");
        }
    }
}
