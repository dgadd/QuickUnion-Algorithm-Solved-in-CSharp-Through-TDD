using System.Collections.Generic;
using System.Linq;
using System.Text;
using Gaddzeit.Kata.Util;
using NBehave.Spec.NUnit;
using NUnit.Framework;

namespace Gaddzeit.Kata.Tests.Unit
{
    [TestFixture]
    public class QuickUnionBuilderTests
    {
        [Test]
        public void ConnectMethod_StartEndIntFirstTimeInput_ArrayChangesStartValueToRootOfTreeValue()
        {
            const int startPointValue = 3;
            const int endPointValue = 4;
            var intArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var expectedResult = new int[] { 0, 1, 2, 4, 4, 5, 6, 7, 8, 9 };

            var sut = new QuickUnionBuilder(intArray);
            sut.Connect(startPointValue, endPointValue);

            intArray[startPointValue].ShouldEqual(endPointValue);
            intArray.ShouldEqual(expectedResult);
        }

        [Test]
        public void ConnectMethod_StartEndIntSecondTimeInput_ArrayChangesStartValueToRootOfTreeValue()
        {
            const int startPointValue = 4;
            const int endPointValue = 9;
            var intArray = new int[] { 0, 1, 2, 4, 4, 5, 6, 7, 8, 9 };
            var expectedResult = new int[] { 0, 1, 2, 4, 9, 5, 6, 7, 8, 9 };

            var sut = new QuickUnionBuilder(intArray);
            sut.Connect(startPointValue, endPointValue);

            intArray[startPointValue].ShouldEqual(endPointValue);
            intArray.ShouldEqual(expectedResult);
        }

        [Test]
        public void ConnectMethod_StartEndIntThirdTimeInput_ArrayChangesStartValueToRootOfTreeValue()
        {
            const int startPointValue = 8;
            const int endPointValue = 0;
            var intArray = new int[] { 0, 1, 2, 4, 9, 5, 6, 7, 8, 9 };
            var expectedResult = new int[] { 0, 1, 2, 4, 9, 5, 6, 7, 0, 9 };

            var sut = new QuickUnionBuilder(intArray);
            sut.Connect(startPointValue, endPointValue);

            intArray[startPointValue].ShouldEqual(endPointValue);
            intArray.ShouldEqual(expectedResult);
        }

        [Test]
        public void ConnectMethod_StartEndIntFourthTimeInput_ArrayChangesStartValueToRootOfTreeValue()
        {
            const int startPointValue = 2;
            const int endPointValue = 3;
            var intArray = new int[] { 0, 1, 2, 4, 9, 5, 6, 7, 0, 9 };
            var expectedResult = new int[] { 0, 1, 9, 4, 9, 5, 6, 7, 0, 9 };

            var sut = new QuickUnionBuilder(intArray);
            sut.Connect(startPointValue, endPointValue);

            intArray[startPointValue].ShouldEqual(sut.RootOfTreeFor(endPointValue));
            intArray.ShouldEqual(expectedResult);
        }

        [Test]
        public void ConnectMethod_EntireSequenceOfStartPointInputs_EndPointValuesPointToTraversableRootValues()
        {
            var intArray = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var sut = new QuickUnionBuilder(intArray);
            sut.Connect(3, 4);
            intArray.ShouldEqual(new int[] { 0, 1, 2, 4, 4, 5, 6, 7, 8, 9 });
            sut.Connect(4, 9);
            intArray.ShouldEqual(new int[] { 0, 1, 2, 4, 9, 5, 6, 7, 8, 9 });
            sut.Connect(8, 0);
            intArray.ShouldEqual(new int[] { 0, 1, 2, 4, 9, 5, 6, 7, 0, 9 });
            sut.Connect(2, 3);
            intArray.ShouldEqual(new int[] { 0, 1, 9, 4, 9, 5, 6, 7, 0, 9 });
            sut.Connect(5, 6);
            intArray.ShouldEqual(new int[] { 0, 1, 9, 4, 9, 6, 6, 7, 0, 9 });
            sut.Connect(2, 9);
            intArray.ShouldEqual(new int[] { 0, 1, 9, 4, 9, 6, 6, 7, 0, 9 });
            sut.Connect(5, 9);
            intArray.ShouldEqual(new int[] { 0, 1, 9, 4, 9, 6, 9, 7, 0, 9 });
            sut.Connect(7, 3);
            intArray.ShouldEqual(new int[] { 0, 1, 9, 4, 9, 6, 9, 9, 0, 9 });
            sut.Connect(4, 8);
            intArray.ShouldEqual(new int[] { 0, 1, 9, 4, 9, 6, 9, 9, 0, 0 });
            sut.Connect(5, 6);
            intArray.ShouldEqual(new int[] { 0, 1, 9, 4, 9, 6, 9, 9, 0, 0 });
            sut.Connect(0, 2);
            intArray.ShouldEqual(new int[] { 0, 1, 9, 4, 9, 6, 9, 9, 0, 0 });
            sut.Connect(6, 1);
            intArray.ShouldEqual(new int[] { 1, 1, 9, 4, 9, 6, 9, 9, 0, 0 });
            sut.Connect(5, 8);
            intArray.ShouldEqual(new int[] { 1, 1, 9, 4, 9, 6, 9, 9, 0, 0 });
        }

    }
}
