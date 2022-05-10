using NUnit.Framework;
using NumberOfDiscIntersections;
using System.Linq;
using System;

namespace NumberOfDiscIntersectionsVariant2.UnitTests
{
    [TestFixture]
    public class MySolutionTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CountIntersections_EmptyInputArray_ExpectedZeroIntersections(
            [Values(new int[0])] int[] A)
        {

            #region Arrange

            int result;

            #endregion

            #region Act

            result = MySolution.CountIntersections(A);

            #endregion

            #region Assert

            Assert.Zero(result);

            #endregion
        }

        #region radius = 0 amount = different

        static object[] ZeroArrayCases =
        {
            new int[1],
            new int[10],
            new int[100],
            new int[1000],
            new int[10000],
            new int[100000]
        };

        
        [TestCaseSource(nameof(ZeroArrayCases))]
        public void CountIntersections_ZeroRadiusInputArray_ExpectedZeroIntersections(int[] A)
        {

            #region Arrange

            int result;

            #endregion

            #region Act

            result = MySolution.CountIntersections(A);

            #endregion

            #region Assert

            Assert.Zero(result);

            #endregion
        }

        #endregion

        #region radius = 1 amount = different

        static object[] UnitArrayCases =
        {
            Enumerable.Repeat(1, 1).ToArray(),
            Enumerable.Repeat(1, 10).ToArray(),
            Enumerable.Repeat(1, 100).ToArray(),
            Enumerable.Repeat(1, 1000).ToArray(),
            Enumerable.Repeat(1, 10000).ToArray(),
            Enumerable.Repeat(1, 100000).ToArray(),
        };


        [TestCaseSource(nameof(UnitArrayCases))]
        public void CountIntersections_OneRadiusInputArray_ExpectedNMinusOneIntersections(int[] A)
        {

            #region Arrange

            int result;
            int expected;
            
            switch (A.Length) 
            {
                case 1: expected = 0; break;
                case 2: expected = 1; break;
                case 3: expected = 3; break;
                default: expected = (A.Length - 3) * 2 + 3; break;
            }


            #endregion

            #region Act

            result = MySolution.CountIntersections(A);

            #endregion

            #region Assert

            Assert.AreEqual(expected, result);

            #endregion
        }

        #endregion
    }
}