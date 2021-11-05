using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibraryPassword;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryPassword.Tests
{
    [TestClass()]
    public class PasswordCheckerTests
    {
        [TestMethod()]
        public void Check_5Symbols_ReturnsFalse()
        {
            string password = "Qa2$";
            bool exepted = false;
            bool actual = PasswordChecker.validatePassword(password);
            Assert.IsFalse(actual);
        }
         [TestMethod()]
        public void Check_10Symbols_ReturnsTrue()
        {
            string password = "DSAewq321$";
            bool exepted = true;
            bool actual = PasswordChecker.validatePassword(password);
            Assert.AreEqual(exepted, actual);
        }
        [TestMethod()]
        public void Check_22Symbols_ReturnsFalse()
        {
            string password = "SAwq21$$DSAweq123$AS111";
            bool exepted = false;
            bool actual = PasswordChecker.validatePassword(password);
            Assert.IsFalse(actual);
        }
        [TestMethod()]
        public void Check_PresenceOfNumbersTrue()
        {  //наличие цифр = presence of numbers
            string password = "DSAweq1$";
            bool exepted = true;
            bool actual = PasswordChecker.validatePassword(password);
            Assert.AreEqual(exepted, actual);
        }
        [TestMethod()]
        public void Check_PresenceOfNumbersFalse()
        {  //наличие цифр = presence of numbers
            string password = "DSAweqDSA$";
            bool exepted = false;
            bool actual = PasswordChecker.validatePassword(password);
            Assert.IsFalse(actual);
        }
        [TestMethod()]
        public void Check_ThePresenceOfSpecialCharactersTrue()
        {  //наличие спецсимволов = the presence of special characters
            string password = "Lewqa321$";
            bool exepted = true;
            bool actual = PasswordChecker.validatePassword(password);
            Assert.AreEqual(exepted, actual);
        }
        [TestMethod()]
        public void Check_ThePresenceOfSpecialCharactersFalse()
        { //наличие спецсимволов = the presence of special characters
            string password = "DSAweq321";
            bool exepted = false;
            bool actual = PasswordChecker.validatePassword(password);
            Assert.IsFalse(actual);
        }
        [TestMethod()]
        public void Check_ThePresenceOfCapitalLettersTrue()
        { //наличие прописных букв = the presence of capital letters
            string password = "Dsaweq321$";
            bool exepted = true;
            bool actual = PasswordChecker.validatePassword(password);
            Assert.AreEqual(exepted, actual);
        }
        [TestMethod()]
        public void Check_ThePresenceOfCapitalLettersFalse()
        { //наличие прописных букв = the presence of capital letters
            string password = "dsaweq321$";
            bool exepted = false;
            bool actual = PasswordChecker.validatePassword(password);
            Assert.IsFalse(actual);
        }
        [TestMethod()]
        public void Check_ThePresenceOfLowercaseLettersTrue()
        { //наличие строчных букв = the presence of capital letters
            string password = "DSAq321$";
            bool exepted = true;
            bool actual = PasswordChecker.validatePassword(password);
            Assert.AreEqual(exepted, actual);
        }
        [TestMethod()]
        public void Check_ThePresenceOfLowercaseLettersFalse()
        { //наличие строчных букв = the presence of capital letters
            string password = "a@s12asdfg";
            bool exepted = false;
            bool actual = PasswordChecker.validatePassword(password);
            Assert.IsFalse(actual);
        }
    }
}
