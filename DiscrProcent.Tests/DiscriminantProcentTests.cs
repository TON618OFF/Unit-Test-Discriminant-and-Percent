using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace DiscrProcent.Tests
{
    [TestClass]
    public class DiscriminantProcentTests
    {
        private static double a;
        private static double b;
        private static double c;
        private static double expectedPercentage;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {
            a = 2;
            b = 3;
            c = 6;
            expectedPercentage = 25; 
        }

        [TestMethod]
        public void FindSqrt_DiscrLessThanZero_0SqrtReturn()
        {
            // arrange
            // act
            // assert
            CollectionAssert.AreEqual(new double[0], DiscriminantProcent.CorniDiscriminanta(a, b, c), "Ожидалось, что корней нет (D < 0) для a = {0}, b = {1}, c = {2}", a, b, c);
        }

        [TestMethod]
        public void FindSqrt_DiscrAreEqualZero_1SqrtReturn()
        {
            // arrange
            double a = 1, b = 2, c = 1;
            // act
            // assert
            CollectionAssert.AreEqual(new double[] { -1 }, DiscriminantProcent.CorniDiscriminanta(a, b, c), "Ожидалось, что корень один (D = 0) для a = {0}, b = {1}, c = {2}", a, b, c);
        }

        [TestMethod]
        public void FindSqrt_DiscrMoreThanZero_2SqrtReturn()
        {
            // arrange
            double a = 1, b = -3, c = 2;
            // act
            // assert
            CollectionAssert.AreEqual(new double[] { 2, 1 }, DiscriminantProcent.CorniDiscriminanta(a, b, c), "Ожидалось, что корней два (D > 0) для a = {0}, b = {1}, c = {2}", a, b, c);
        }

        [TestMethod]
        public void CalcProcent_ValidInputs_CorrectResultReturn()
        {
            // arrange
            double num = 100;
            double procent = 25;
            double delta = 0.0001;

            // act
            double result = DiscriminantProcent.CalcProcent(num, procent);

            // assert
            Assert.AreEqual(25, result, delta, "Процент от числа {0} должен быть равен {1}%, вместо {2}%", num, expectedPercentage, procent);
        }
    }
}
