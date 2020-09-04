using System;
using Xunit;
using ConsoleCalculator;
using System.Text;

namespace ConsoleCalculator.Tests
{
    public class CalculatorFixture
    {
        private Calculator calc;
        StringBuilder str = new StringBuilder();
        public CalculatorFixture()
        {
            calc = new Calculator();
        }

        [Fact]
        public void TestForOtherChars()
        {
            StringBuilder str = calc.DisplayString;
            calc.SendKeyPress('a');
            Assert.Equal(calc.DisplayString, str);
        }

        [Fact]
        public void Test_Char_C()
        {

            calc.SendKeyPress('3');
            calc.SendKeyPress('c');
            Assert.Equal("0", calc.DisplayString.ToString());
        }

        [Fact]
        public void TestZeroOnStart()
        {
            Assert.Equal("0", calc.DisplayString.ToString());
        }

        [Fact]
        public void Test_Char_S()
        {
            calc.SendKeyPress('2');
            calc.SendKeyPress('s');
            Assert.Equal("-2", calc.DisplayString.ToString());
        }

        [Fact]
        public void TestForCaseSensivity()
        {
            calc.SendKeyPress('1');
            calc.SendKeyPress('2');
            calc.SendKeyPress('+');
            Assert.Equal("12", calc.DisplayString.ToString());

            calc.SendKeyPress('2');
            calc.SendKeyPress('S');
            Assert.Equal("-2", calc.DisplayString.ToString());
            calc.SendKeyPress('S');
            Assert.Equal("2", calc.DisplayString.ToString());

            calc.SendKeyPress('S');
            calc.SendKeyPress('=');
            Assert.Equal("10", calc.DisplayString.ToString());
        }

        [Fact]
        public void TestForNumbers()
        {
            calc.SendKeyPress('2');
            calc.SendKeyPress('3');
            Assert.Equal("23", calc.DisplayString.ToString());

            calc.SendKeyPress('+');
            Assert.Equal("23", calc.DisplayString.ToString());

            calc.SendKeyPress('2');
            Assert.Equal("2", calc.DisplayString.ToString());

            calc.SendKeyPress('=');
            Assert.Equal("25", calc.DisplayString.ToString());
        }

        [Fact]
        public void TestDivideByZero()
        {
            calc.SendKeyPress('2');
            calc.SendKeyPress('/');
            calc.SendKeyPress('0');
            calc.SendKeyPress('=');
            Assert.Equal("-E-", calc.DisplayString.ToString());
        }

        [Fact]
        public void TestConsecutiveZero()
        {
            calc.SendKeyPress('0');
            calc.SendKeyPress('0');
            calc.SendKeyPress('0');
            Assert.Equal("0", calc.DisplayString.ToString());

            calc.SendKeyPress('.');
            calc.SendKeyPress('0');
            calc.SendKeyPress('0');
            Assert.Equal("0.00", calc.DisplayString.ToString());
        }

        [Fact]
        public void TestDecimalPoints()
        {

            calc.SendKeyPress('0');
            calc.SendKeyPress('0');
            calc.SendKeyPress('0');
            Assert.Equal("0", calc.DisplayString.ToString());
            calc.SendKeyPress('.');
            calc.SendKeyPress('.');
            calc.SendKeyPress('0');
            calc.SendKeyPress('0');
            Assert.Equal("0.00", calc.DisplayString.ToString());
        }
                 
        [Fact]
        public void TestMultipleDecimalPoints()
        {
            calc.SendKeyPress('9');
            calc.SendKeyPress('.');
            calc.SendKeyPress('.');
            calc.SendKeyPress('3');
            calc.SendKeyPress('-');
            calc.SendKeyPress('6');
            calc.SendKeyPress('.');
            calc.SendKeyPress('.');
            calc.SendKeyPress('8');
            calc.SendKeyPress('=');
            Assert.Equal("2.5", calc.DisplayString.ToString());
        }

        [Fact]
        public void TestZerosBeforeDecimalPoint()
        {
            calc.SendKeyPress('0');
            calc.SendKeyPress('0');    
            calc.SendKeyPress('.');
            calc.SendKeyPress('.');
            calc.SendKeyPress('7');
            calc.SendKeyPress('-');
            calc.SendKeyPress('0');
            calc.SendKeyPress('0');
            calc.SendKeyPress('.');
            calc.SendKeyPress('9');
            calc.SendKeyPress('=');
            Assert.Equal("-0.2", calc.DisplayString.ToString());
        }

        [Fact]
        public void TestCombinationNumbers()
        {
            calc.SendKeyPress('1');
            calc.SendKeyPress('4');
            calc.SendKeyPress('9');
            calc.SendKeyPress('-');
            calc.SendKeyPress('4');
            calc.SendKeyPress('5');
            calc.SendKeyPress('.');
            calc.SendKeyPress('8');
            calc.SendKeyPress('=');
            Assert.Equal("103.2", calc.DisplayString.ToString());
        }

        [Fact]
        public void TestAddition()
        {
            calc.SendKeyPress('5');
            calc.SendKeyPress('5');
            calc.SendKeyPress('5');
            calc.SendKeyPress('+');
            calc.SendKeyPress('6');
            calc.SendKeyPress('6');
            calc.SendKeyPress('=');
            Assert.Equal("621", calc.DisplayString.ToString());
        }

        [Fact]
        public void TestSubtraction()
        {
            calc.SendKeyPress('8');
            calc.SendKeyPress('4');
            calc.SendKeyPress('2');
            calc.SendKeyPress('-');
            calc.SendKeyPress('4');
            calc.SendKeyPress('6');
            calc.SendKeyPress('2');
            calc.SendKeyPress('=');
            Assert.Equal("380", calc.DisplayString.ToString());
        }

        [Fact]
        public void TestMultiplication()
        {
            calc.SendKeyPress('7');
            calc.SendKeyPress('x');
            calc.SendKeyPress('6');
            calc.SendKeyPress('=');
            Assert.Equal("42", calc.DisplayString.ToString());
        }

        [Fact]
        public void TestDivision()
        {
            calc.SendKeyPress('2');
            calc.SendKeyPress('4');
            calc.SendKeyPress('/');
            calc.SendKeyPress('3');
            calc.SendKeyPress('=');
            Assert.Equal("8", calc.DisplayString.ToString());
        }

        [Fact]
        public void TestMultipleAddition()
        {
            calc.SendKeyPress('1');
            calc.SendKeyPress('+');
            calc.SendKeyPress('2');
            calc.SendKeyPress('+');
            calc.SendKeyPress('4');
            calc.SendKeyPress('+');
            Assert.Equal("7", calc.DisplayString.ToString());
        }

        [Fact]
        public void TestPlusAssignmentOperator()
        {
            calc.SendKeyPress('1');
            calc.SendKeyPress('+');
            calc.SendKeyPress('2');
            calc.SendKeyPress('+');
            calc.SendKeyPress('3');
            calc.SendKeyPress('+');
            calc.SendKeyPress('=');
            Assert.Equal("12", calc.DisplayString.ToString());
        }

        [Fact]
        public void TestMinusAssignmentOperator()
        {
            calc.SendKeyPress('7');
            calc.SendKeyPress('-');
            calc.SendKeyPress('=');           
            Assert.Equal("0", calc.DisplayString.ToString());
        }

        [Fact]
        public void TestMutlipleMinusAssignmentOperator()
        {
            calc.SendKeyPress('7');
            calc.SendKeyPress('-');
            calc.SendKeyPress('1');
            calc.SendKeyPress('-');
            calc.SendKeyPress('=');
            Assert.Equal("0", calc.DisplayString.ToString());
        }
        [Fact]
        public void TestMultiplicationAssignmentOperator()
        {
            calc.SendKeyPress('2');
            calc.SendKeyPress('x');
            calc.SendKeyPress('2');
            calc.SendKeyPress('x');
            calc.SendKeyPress('=');
            Assert.Equal("16", calc.DisplayString.ToString());
        }
    }
}
