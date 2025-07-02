using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using TechStore.BL.BL;
using TechStore.BL.Models.Person;
using TechStore.DL;
using TechStore.Interfaces.BLInterfaces;
using TechStore.Interfaces.DLInterfaces;
using TechStore.BL.Models;

namespace TechStore.BL.Tests
{
    [TestClass]
    public class CustomerBLTests
    {
        private Mock<ICustomerDL> mockCustomerDL;
        private CustomerBL customerBL;

        [TestInitialize]
        public void Setup()
        {
            mockCustomerDL = new Mock<ICustomerDL>();
            customerBL = new CustomerBL(mockCustomerDL.Object);
        }

        [TestMethod]
        public void GetCustomersTest_ReturnsList()
        {
            // Arrange
            var expected = new List<Customer>
            {
                new Customer(1, "abc@gmail.com", "address1", "Ali", "123456", "Khan", "Regular"),
                new Customer(2, "xyz@gmail.com", "address2", "Zain", "654321", "Ahmed", "Walk_in")
            };

            mockCustomerDL.Setup(dl => dl.GetCustomers()).Returns(expected);

            // Act
            var result = customerBL.GetCustomers();

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Ali", result[0].firstName);
        }

        [TestMethod]
        public void AddCustomerTest_Success()
        {
            var customer = new Customer(0, "abc@gmail.com", "address", "Ali", "12345", "Khan", "Regular");

            mockCustomerDL.Setup(dl => dl.Addcustomer(customer)).Returns(true);

            bool result = customerBL.AddCustomer(customer);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void DeleteCustomerTest_ValidId()
        {
            mockCustomerDL.Setup(dl => dl.Deletecustomer(1)).Returns(true);

            bool result = customerBL.DeleteCustomer(1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UpdateCustomerTest_Success()
        {
            var customer = new Customer(1, "abc@gmail.com", "address", "Ali", "12345", "Khan", "Regular");

            mockCustomerDL.Setup(dl => dl.Updatecustomer(customer)).Returns(true);

            bool result = customerBL.UpdateCustomer(customer);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void SearchCustomersTest_ReturnsFilteredList()
        {
            var data = new List<Customer>
            {
                new Customer(1, "ali@gmail.com", "LHR", "Ali", "123", "Khan", "Regular"),
                new Customer(2, "bilal@gmail.com", "KHI", "Bilal", "456", "Zahid", "Walk_in")
            };

            mockCustomerDL.Setup(dl => dl.Searchcustomers("Ali")).Returns(data.Where(c => c.firstName.Contains("Ali")).ToList());

            var result = customerBL.SearchCustomers("Ali");

            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Ali", result[0].firstName);
        }
    }
}
