using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WP.Models.Entities;
using WP.Models.Interfeces;
using WP.Models.Services;

namespace TestProject.Model.Service
{
    internal class SecurityServiceTests
    {
        public ISecRepository Substitute { get; private set; }

        [Test]
        public void IsValid_帳號錯誤_ReturnFalse()
        {
            ISecRepository repo = new ARepo();
            var service = new SecurityService(repo);
            bool acutal = service.IsValid("A", "123");//User Input

            Assert.IsFalse(acutal);
        }

        [Test]
        public void IsValid_密碼錯誤_ReturnFalse()
        {
            ISecRepository repo = new BRepo();
            var service = new SecurityService(repo);
            bool acutal = service.IsValid("A", "123");//User Input

            Assert.IsFalse(acutal);
            //EmployeeEntity AAA = null;
            //ISecRepository repo = Substitute.For<ISecRepository>();
            //repo.Load("AAA").returns(AAA);
        }

        [Test]
        public void IsValid_帳號密碼正確_ReturnTrue()
        {
            ISecRepository repo = new CRepo();
            var service = new SecurityService(repo);
            bool acutal = service.IsValid("A", "123");//User Input

            Assert.IsTrue(acutal);
        }
    }

    public class ARepo : ISecRepository
    {
        public EmployeeEntity Load(string account)
        {
            return null;//Mock data from database
        }
    }

    public class BRepo : ISecRepository
    {
        public EmployeeEntity Load(string account)
        {
            return new EmployeeEntity { Account = account, Password = "QWEQWE" };//Mock data from database
        }
    }

    public class CRepo : ISecRepository
    {
        public EmployeeEntity Load(string account)
        {
            return new EmployeeEntity { Account = account, Password = "123" };//Mock data from database
        }


    }
}
