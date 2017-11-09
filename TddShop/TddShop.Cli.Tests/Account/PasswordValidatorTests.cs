using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddShop.Cli.Account;

namespace TddShop.Cli.Tests.Account
{
    [TestFixture]
    public class PasswordValidatorTests
    {
        [Test]
        public void IsValid_ValidPassword_ShouldReturnTrue()
        {
            //Arrange
            var password = "asd23asdPO# 4s";
            var target = new PasswordValidator();

            //Act            
            var actual = target.IsValid(password);

            //Assert
            Assert.That(actual, Is.True);
        }

        [Test]
        public void IsValid_ContainsUpperCaseLetter_ShouldReturnFalse()
        {
            //Arrange
            var password = "asd23asdpo# 4s";
            var target = new PasswordValidator();

            //Act            
            var actual = target.IsValid(password);

            //Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        public void IsValid_ContainsLowerCaseLetter_ShouldReturnFalse()
        {
            //Arrange
            var password = "ASD23ASDPO# 4S";
            var target = new PasswordValidator();

            //Act            
            var actual = target.IsValid(password);

            //Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        public void IsValid_ContainsDigit_ShouldReturnFalse()
        {
            //Arrange
            var password = "asdasdPO# s";
            var target = new PasswordValidator();

            //Act            
            var actual = target.IsValid(password);

            //Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        public void IsValid_ContainsSpecialCharacter_ShouldReturnFalse()
        {
            //Arrange
            var password = "asd23asdPO4s";
            var target = new PasswordValidator();

            //Act            
            var actual = target.IsValid(password);

            //Assert
            Assert.That(actual, Is.False);
        }

        [Test]
        public void IsValid_HasAtLeast10_ShouldReturnFalse()
        {
            //Arrange
            var password = "aSd23# 4s";
            var target = new PasswordValidator();

            //Act            
            var actual = target.IsValid(password);

            //Assert
            Assert.That(actual, Is.False);
        }
    }
}

