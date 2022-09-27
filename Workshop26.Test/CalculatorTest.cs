using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace Workshop26.Test
{
    public class CalculatorTest
    {

        [TestCase("")]
        public void ShouldCalcEmptyStrings(string numbers)
        {
            var result = new Calculator();
            Assert.That(result.Add(numbers), Is.EqualTo(0));
        }

        [TestCase(null)]
        public void ShouldCalcNullStrings(string numbers)
        {
            var result = new Calculator();
            Assert.That(result.Add(numbers), Is.EqualTo(0));
        }

        [TestCase("0")]
        public void ShouldCalcZeroStrings(string numbers)
        {
            var result = new Calculator();
            Assert.That(result.Add(numbers), Is.EqualTo(0));
        }

        [TestCase("1")]
        public void ShouldCalcNumStrings(string numbers)
        {
            var result = new Calculator();
            Assert.That(result.Add(numbers), Is.EqualTo(1));
        }

        [TestCase("1,2", 3)]
        [TestCase("3,7,2,1", 13)]
        public void ShouldCalcManyNumbersStrings(string numbers, int result)
        {
            var res = new Calculator();
            Assert.That(res.Add(numbers), Is.EqualTo(result));
        }

        [TestCase("1\n2, 3", 6)]
        public void ShouldCalcManyNumbersAfterCommaStrings(string numbers, int result)
        {
            var res = new Calculator();
            Assert.That(res.Add(numbers), Is.EqualTo(result));
        }

        [TestCase("//[;]\n1;2", 3)]
        public void ShouldCalcManyNumbersWithDelimitersStrings(string numbers, int result)
        {
            var res = new Calculator();
            Assert.That(res.Add(numbers), Is.EqualTo(result));
        }

        [TestCase("-1,-2", -3)]
        public void ShouldCalcManyNumbersMinusStrings(string numbers, int result)
        {
            var res = new Calculator();
            //test
            Assert.That(() => res.Add(numbers), Throws.TypeOf<ArgumentException>().With.Message.EqualTo("negatives not allowed"));
        }

        [TestCase("1000,2", 2)]
        public void ShouldCalcManyNumbersWithDelimitersThousandsStrings(string numbers, int result)
        {
            var res = new Calculator();
            Assert.That(res.Add(numbers), Is.EqualTo(result));
        }

        [TestCase("//[***]\n1***2", 3)]
        public void ShouldCalcManyNumbersWithDelimitersLongStrings(string numbers, int result)
        {
            var res = new Calculator();
            Assert.That(res.Add(numbers), Is.EqualTo(result));
        }

        //[TestCase("//[*][%]\n1*2%3", 6)]
        //public void ShouldCalcManyNumbersWithDelimiters1Strings(string numbers, int result)
        //{
        //    var res = new Calculator();
        //    Assert.That(res.Add(numbers), Is.EqualTo(result));
        //}
    }
}