using FoodTracker.Models;
using FoodTracker.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FoodTrackerTests
{
    [TestClass]
    public class AddViewModelsTests
    {
        [TestMethod]
        public void OnAddItemTest()
        {
            //Arrange
            AddViewModel addViewModel = new AddViewModel();
            //Act
            addViewModel.OnAddItem();
            //Assert
            Assert.IsFalse(addViewModel.isSuccessfull);
        }
    }
}
