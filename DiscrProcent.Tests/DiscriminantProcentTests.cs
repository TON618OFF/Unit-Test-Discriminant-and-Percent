using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace DiscrProcent.Tests
{
    [TestClass]
    public class DiscriminantProcentTests
    {
        private static List<double[]> peremenie;
        private static double num;
        private static double procent;
        private static double expectedPercentage;
        private static double delta;

        [ClassInitialize]
        public static void Setup(TestContext context)
        {

            peremenie = new List<double[]>
            {
                new double[] { 1, 2, 5 },
                new double[] { 1, 2, 1 },
                new double[] { 1, -3, 2 }
            };
            num = 100.00;
            procent = 24.999;
            expectedPercentage = 25.00;
            delta = 0.001;
        }

        [TestMethod]
        public void FindSqrt_DiscrLessThanZero_0SqrtReturn()
        {
            // arrange
            // act
            // assert
            CollectionAssert.AreEqual(new double[] { }, 
                DiscriminantProcent.CorniDiscriminanta(peremenie[0][0], peremenie[0][1], peremenie[0][2]), 
                "Ожидалось, что корней нет (D < 0) для a = {0}, b = {1}, c = {2}", peremenie[0][0], peremenie[0][1], peremenie[0][2]);

        }

        [TestMethod]
        public void FindSqrt_DiscrAreEqualZero_1SqrtReturn()
        {
            // arrange
            // act
            // assert
            CollectionAssert.AreEquivalent(new double[] { -1 },
                DiscriminantProcent.CorniDiscriminanta(peremenie[1][0], peremenie[1][1], peremenie[1][2]),
                "Ожидалось, что корней нет (D = 0) для a = {0}, b = {1}, c = {2}", peremenie[1][0], peremenie[1][1], peremenie[1][2]);

        }

        [TestMethod]
        public void FindSqrt_DiscrMoreThanZero_2SqrtReturn()
        {
            // arrange
            // act
            double[] corni = DiscriminantProcent.CorniDiscriminanta(peremenie[2][0], peremenie[2][1], peremenie[2][2]);
            // assert
            CollectionAssert.AllItemsAreNotNull(corni);
            CollectionAssert.AllItemsAreUnique(corni);
            CollectionAssert.AreEqual(new double[] { 2, 1 },
                DiscriminantProcent.CorniDiscriminanta(peremenie[2][0], peremenie[2][1], peremenie[2][2]),
                "Ожидалось, что корней нет (D > 0) для a = {0}, b = {1}, c = {2}", peremenie[2][0], peremenie[2][1], peremenie[2][2]);
        }

        [TestMethod]
        public void CalcProcent_ValidInputs_CorrectResultReturn()
        {
            // arrange
            // act
            if (delta == 0)
            {
                Assert.Inconclusive("Тест не может быть выполнен, так как дельта не указана или равна нулю.");
            }
            double result = DiscriminantProcent.CalcProcent(num, procent);
            // assert
            Assert.AreEqual(expectedPercentage, result, delta, "Процент от числа {0} должен быть равен {1}%, вместо {2}%",
            num, expectedPercentage, procent);

        }
    }
}
