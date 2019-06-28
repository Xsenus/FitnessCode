using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FitnessCode.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {
        [TestMethod()]
        public void SetNewUserDataTest()
        {
            // Arrange 
            var userName = Guid.NewGuid().ToString();
            var birtDate = DateTime.Now.AddYears(-18);
            var weight = 90;
            var height = 190;
            var gender = "man";
            var controller1 = new UserController(userName);

            // Act
            controller1.SetNewUserData(gender, birtDate, weight, height);

            var controller2 = new UserController(userName);

            // Assert
            Assert.AreEqual(userName, controller2.CurrentUser.Name);
            Assert.AreEqual(birtDate, controller2.CurrentUser.BirthDate);
            Assert.AreEqual(weight, controller2.CurrentUser.Weight);
            Assert.AreEqual(height, controller2.CurrentUser.Heiht);
            Assert.AreEqual(gender, controller2.CurrentUser.Gender.Name);

        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrange - объявление переменных
            var userName = Guid.NewGuid().ToString();

            // Act - действие
            var controller = new UserController(userName);

            // Assert - проверка того что получилось
            Assert.AreEqual(userName, controller.CurrentUser.Name);
        }
    }
}