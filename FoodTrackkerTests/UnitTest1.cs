using FoodTracker.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Xamarin.Forms;
namespace FoodTrackkerTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            AddViewModel addviewModel = new AddViewModel();
            addviewModel.ScannerToggled = false;
            //Act
            addviewModel.OnToggleScanner();
            //Assert
            Assert.IsTrue(addviewModel.ScannerToggled);
        }   
        [TestMethod]
        public void TestMethod2()
        {
            //Arrange
            AddViewModel addviewModel = new AddViewModel();
            
            //Act
            addviewModel.OnAddItem();
            //Assert
            Assert.IsFalse(addviewModel.isSuccessfull);
        }
    }
}
