using Microsoft.VisualStudio.TestTools.UnitTesting;
using Fitness.BL.Controller;
using System;

namespace Fitness.BL.Controller.Tests
{
    [TestClass()]
    public class UserControllerTests
    {

        [TestMethod()]
        public void SetNewUserDataTest()
        {
            // Arrange
            var nameGuid = Guid.NewGuid().ToString();
            var genderName = "unkhow";
            var dateBirth = DateTime.Now.AddYears(-10);

            var userController1 = new UserController(nameGuid);
            var userController2 = new UserController(nameGuid);

            // Act
            userController1.SetNewUserData(genderName, dateBirth, 1, 1);

            // Assert
            Assert.AreNotEqual(userController1, userController2);

        }

        [TestMethod()]
        public void SaveTest()
        {
            // Arrange
            var nameguid = Guid.NewGuid().ToString();

            // Act
            var userController = new UserController(nameguid);

            // Assert
            Assert.AreEqual(nameguid, userController.CurrentUser.Login);
        }

        [TestMethod()]
        public void ParseDateTimeTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void ParseIntTest()
        {
            Assert.Fail();
        }
    }
}