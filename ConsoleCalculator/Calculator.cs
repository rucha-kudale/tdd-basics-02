using System;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.Runtime;
namespace ConsoleCalculator
{
    public class Calculator
    {
        public StringBuilder DisplayString;
        
        public decimal Number1;
        public decimal Number2;
        public char prevOperator;
        public bool newNumber;
        public bool error;
        public Calculator()
        {
            DisplayString = new StringBuilder();
            DisplayString.Append("0");          
            Number1 = 0;
            Number2 = 0;
            prevOperator = '\0';
            newNumber = true;
            error = false;
        }
        // Perform Operation based on operator
        public void operate(char oper)
        {
            switch (oper)
            {
                case '+':
                    Number2 = Number1 + Number2;
                    break;
                case '-':
                    Number2 = Number1 - Number2;
                    break;
                case 'x':
                case 'X':
                    Number2 = Number1 * Number2;
                    break;
                case '/':
                    if (Number2 == 0)
                    {
                        error = true;
                    }
                    else
                        Number2 = Number1 / Number2;
                    break;
            }
            Number1 = 0;
        }
        public void toggleCase()
        {
            if (!DisplayString.Equals("-E-"))
            {
                if (Number2 < 0)
                    DisplayString.Remove(0, 1);
                else
                    DisplayString.Insert(0, '-');
                Number2 = Number2 * -1;
            }
        }
    public void checkAndOperate(char key)
        {
            if (Number1 == 0)
            {
                Number1 = Number2;
                Number2 = 0;
                prevOperator = key;
                DisplayString.Clear(); DisplayString.Append(Number1);
            }
            else
            {
                operate(prevOperator);
                prevOperator = key;
                DisplayString.Clear(); DisplayString.Append(Number2);
            }

        }
        public bool SendKeyPress(char key)
        {
            List<char> list = new List<char>() { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '.', '-', '+', 'x','X', '/', 's','S', 'c','C', '=' };

            if (list.Contains(key))
            {
                switch (key)
                {
                    case 'c':
                    case 'C':
                        DisplayString.Clear(); DisplayString.Append("0");
                        Number1 = 0;
                        Number2 = 0;                        
                        break;

                    case 'S':                      
                    case 's':
                        toggleCase();
                        break;

                    case '+':
                    case '-':
                    case 'X':
                    case 'x':
                    case '/':
                        checkAndOperate(key);
                        newNumber = true;
                        break;

                    case '.':
                        if(!DisplayString.ToString().Contains("."))
                            DisplayString.Append('.');
                        break;

                    case '=':
                        operate(prevOperator);
                        newNumber = true;
                        prevOperator = '\0';
                        if (error)
                        {
                            DisplayString.Clear(); DisplayString.Append("-E-");
                            error = false;
                        }
                        else
                        {                           
                            DisplayString.Clear(); DisplayString.Append(Number2);
                        }
                        break;

                    default:
                        if ( newNumber || (Number2 == 0 && !DisplayString.ToString().Contains(".")))
                            DisplayString.Clear();
                        newNumber = false;
                        DisplayString.Append(key);
                        decimal.TryParse(DisplayString.ToString(), out Number2);
                        break;
                }
            }
            Console.WriteLine(DisplayString);
            return true;
        }
    }
}
