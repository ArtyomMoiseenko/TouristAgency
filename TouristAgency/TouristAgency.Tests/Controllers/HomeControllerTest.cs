//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Web.Mvc;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using TouristAgency;
//using TouristAgency.Controllers;
//using Moq;
//using ToristAgency.Contracts;

//namespace TouristAgency.Tests.Controllers
//{
//    [TestClass]
//    public class HomeControllerTest
//    {
//        private Mock<IGenericRepository<Role>> mockRoleRepository;
//        private Mock<IGenericRepository<User>> mockUserRepository;
//        private HomeController controller;

//        [TestInitialize]
//        public void SetUp()
//        {
//            mockRoleRepository = new Mock<IGenericRepository<Role>>();
//            mockRoleRepository.Setup(a => a.Get()).Returns(new List<Role>());
//            mockUserRepository = new Mock<IGenericRepository<User>>();
//            mockUserRepository.Setup(a => a.Get()).Returns(new List<User>());
//        }

//        [TestMethod]
//        public void Index()
//        {
//            // Arrange
//            controller = new HomeController(mockRoleRepository.Object, mockUserRepository.Object);

//            // Act
//            ViewResult result = controller.Index() as ViewResult;

//            // Assert
//            Assert.IsNotNull(result);
//        }

//        [TestMethod]
//        public void RolesAreExist()
//        {
//            // Arrange
//            controller = new HomeController(mockRoleRepository.Object, mockUserRepository.Object);

//            // Act
//            var roles = controller.GetAllRoles();

//            // Assert
//            Assert.IsNotNull(roles);
//        }

//        [TestMethod]
//        public void UsersAreExist()
//        {
//            // Arrange
//            controller = new HomeController(mockRoleRepository.Object, mockUserRepository.Object);

//            // Act
//            var users = controller.GetAllUsers();

//            // Assert
//            Assert.IsNotNull(users);
//        }
//    }
//}
