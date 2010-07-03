using System;

namespace Gaddzeit.Kata.Util
{
    public class QuickUnionBuilder
    {
        private readonly int[] _intArray;

        public QuickUnionBuilder(int[] intArray)
        {
            _intArray = intArray;
        }

        public void Connect(int startPointValue, int endPointValue)
        {
            //FirstVersionOfAlgorithm(startPointValue, endPointValue);
            //SecondVersionOfAlgorithm(startPointValue, endPointValue);
            ThirdVersionOfAlgorithm(startPointValue, endPointValue);
        }

        private void FirstVersionOfAlgorithm(int startPoint, int endPoint)
        {
            _intArray[startPoint] = endPoint;
        }

        private void SecondVersionOfAlgorithm(int startPoint, int endPoint)
        {
            _intArray[startPoint] = RootOfTreeFor(endPoint);
        }

        private void ThirdVersionOfAlgorithm(int startPoint, int endPoint)
        {
            _intArray[RootOfTreeFor(startPoint)] = RootOfTreeFor(endPoint);
        }

        public int RootOfTreeFor(int index)
        {
            var valueFromIndex = _intArray[index];
            while (valueFromIndex != _intArray[valueFromIndex])
            {
                valueFromIndex = _intArray[valueFromIndex];
            }
            return valueFromIndex;
        }
    }
}