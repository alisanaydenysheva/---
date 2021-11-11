using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassCalculator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassCalculator.Tests
{
    [TestClass()]
    public class CalcCheckerTests
    {
        [TestMethod()]
        public void Check_Summ_ReturnsTrue()
        {
            double sum1 = 6;
            double sum2 = 4;
            string operation = "+";
            double result = 10;
            double actual = CalcChecker.ValidateCalculator(sum1, sum2, operation);
            Assert.AreEqual(result, actual);
        }
        [TestMethod()]
        public void Check_Raznost_ReturnsTrue()
        {
            double sum1 = 6;
            double sum2 = 2;
            string operation = "-";
            double result = 4;
            double actual = CalcChecker.ValidateCalculator(sum1, sum2, operation);
            Assert.AreEqual(result, actual);
        }
        [TestMethod()]
        public void Check_Proizvedenie_ReturnsTrue()
        {
            double sum1 = 2;
            double sum2 = 2;
            string operation = "*";
            double result = 4;
            double actual = CalcChecker.ValidateCalculator(sum1, sum2, operation);
            Assert.AreEqual(result, actual);
        }
        [TestMethod()]
        public void Check_Divide_ReturnsTrue()
        {
            double sum1 = 4;
            double sum2 = 2;
            string operation = "/";
            double result = 2;
            double actual = CalcChecker.ValidateCalculator(sum1, sum2, operation);
            Assert.AreEqual(result, actual);
        }
        [TestMethod()]
        public void Check_KvKoren_ReturnsTrue()
        {
            double sum1 = 144;
            double sum2 = 0;
            string operation = "sqrt";
            double result = 12;
            double actual = CalcChecker.ValidateCalculator(sum1, sum2, operation);
            Assert.AreEqual(result, actual);
        }
        [TestMethod()]
        public void Check_KvadratChisla_ReturnsTrue()
        {
            double sum1 = 2;
            double sum2 = 2;
            string operation = "pow";
            double result = 4;
            double actual = CalcChecker.ValidateCalculator(sum1, sum2, operation);
            Assert.AreEqual(result, actual);
        }
        [TestMethod()]
        public void Check_Factorial_ReturnsTrue()
        {
            double sum1 = 2;
            double sum2 = 1;
            string operation = "fact";
            double result = 2;
            double actual = CalcChecker.ValidateCalculator(sum1, sum2, operation);
            Assert.AreEqual(result, actual);
        }
    }
}
