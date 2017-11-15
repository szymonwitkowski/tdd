using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TddShop.Cli.Order.Models;
using TddShop.Cli.Shipment;

namespace TddShop.Cli.Tests.Shipment
{
    [TestFixture]
    public class NumeralsConverterTests
    {
        private NumeralsConvereter _target;

        [SetUp]
        public void Initialize()
        {
            _target = new NumeralsConvereter();
        }

        [Test]
        public void ArabicToRomanNumeralsConverter_GetInt_ReturnString()
        {
            //Arrange
            var arabicNumber = 2493;

            //Act
            var actual = _target.ArabicToRomanNumeralsConverter(arabicNumber);

            //Assert
            Assert.That(actual, Is.InstanceOf<string>());
        }

        [Test]
        public void ArabicToRomanNumeralsConverter_1_ReturnIinRomanNumeral()
        {
            //Arrange
            var arabicNumber = 1;
            var expected = "I";

            //Act
            var actual = _target.ArabicToRomanNumeralsConverter(arabicNumber);

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ArabicToRomanNumeralsConverter_51_ReturnLIinRomanNumeral()
        {
            //Arrange
            var arabicNumber = 51;
            var expected = "LI";

            //Act
            var actual = _target.ArabicToRomanNumeralsConverter(arabicNumber);

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ArabicToRomanNumeralsConverter_551_ReturnDLIinRomanNumeral()
        {
            //Arrange
            var arabicNumber = 551;
            var expected = "DLI";

            //Act
            var actual = _target.ArabicToRomanNumeralsConverter(arabicNumber);

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ArabicToRomanNumeralsConverter_1551_ReturnMDLIinRomanNumeral()
        {
            //Arrange
            var arabicNumber = 1551;
            var expected = "MDLI";

            //Act
            var actual = _target.ArabicToRomanNumeralsConverter(arabicNumber);

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ArabicToRomanNumeralsConverter_0_ReturnCantConvert()
        {
            //Arrange
            var arabicNumber = 0;
            var expected = "Can't convert";

            //Act
            var actual = _target.ArabicToRomanNumeralsConverter(arabicNumber);

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ArabicToRomanNumeralsConverter_Over3999_ReturnCantConvert()
        {
            //Arrange
            var arabicNumber = 4000;
            var expected = "Can't convert";

            //Act
            var actual = _target.ArabicToRomanNumeralsConverter(arabicNumber);

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }


        [Test]
        public void ArabicToRomanNumeralsConverter_ValidArabicNumber_ValidRomanConversion()
        {
            //Arrange
            var arabicNumber = 2493;
            var expected = "MMCDXCIII";

            //Act
            var actual = _target.ArabicToRomanNumeralsConverter(arabicNumber);

            //Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}