using FoodTracker.ftTrackService;
using FoodTracker.Models;
using FoodTracker.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace FoodTracker.Tests
{
    [TestClass]
    public class AddViewModelTests
    {
        [TestMethod]
        public void AddItemTest()
        {
            //Arrange
          
            var addViewModel = new AddViewModel();
            var service = new FtTrackService();
            addViewModel.Item = new Item()
            {
                ean = 00012,
                name = "simon",
                brand = "cool"

            };
            //Act
            addViewModel.OnAddItem();
            //Assert
            Assert.IsTrue(addViewModel.isSuccessfull);
        }
    }
}
