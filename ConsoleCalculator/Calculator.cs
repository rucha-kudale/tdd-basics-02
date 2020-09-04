using System;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.Runtime;
using System.Collections.ObjectModel;

namespace ConsoleCalculator
{
    public class Calculator : ICalculator
    {
        public StringBuilder DisplayString;
        public decimal Number1, Number2, Answer;
        public char prevOperator;
        public bool newNumber, error;
        public readonly IList<char> allowedChars = new ReadOnlyCollection<char>(new List<char>
                                             { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0',
                                               '.', '-', '+', 'x', 'X', '/', 's', 'S', 'c', 'C', '=' });
        public StringBuilder EnteredString;

        public Calculator()
        {
            DisplayString = new StringBuilder();
            DisplayString.Append("0");
            EnteredString = new StringBuilder();
            Number1 = 0; Number2 = 0; Answer = 0;
            prevOperator = '\0';
            newNumber = true;
            error = false;
        }

        /// <summary>
        /// This method validates key pressed
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>true/false</returns>  
        public bool ValidateKey(char key)
        {
            if (allowedChars.Contains(key))
            {
                EnteredString.Append(char.ToLower(key));
                return true;
            }
            else return false;
        }

        /// <summary>
        /// This method performs Operation based on operator
        /// </summary>
        /// <param name="oper">opeartor</param>
        /// <returns></returns>  
        public void operate(char oper)
        {
            switch (char.ToLower(oper))
            {
                case '+':
                    Answer = Number1 + Number2;
                    break;
                case '-':
                    Answer = Number1 - Number2;
                    break;
                case 'x':
                    Answer = Number1 * Number2;
                    break;
                case '/':
                    if (Number2 == 0)
                    {
                        error = true;
                    }
                    else
                        Answer = Number1 / Number2;
                    break;
            }
            Number2 = 0;
        }

        public bool isOperator(char key)
        {
            if (key.Equals('+') || key.Equals('-') || key.Equals('x') || key.Equals('/'))
                return true;
            else
                return false;
        }

        /// <summary>
        /// This method toggle the sign of the number form.
        /// </summary>
        public void toggleSign()
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

        /// <summary>
        /// This method checks whether entered number is first or second operand
        /// and performs operation based on it
        /// </summary>
        /// <param name="key">key</param>
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
                Number1 = Answer;
                prevOperator = key;
                DisplayString.Clear(); DisplayString.Append(Answer);
            }

        }

        /// <summary>
        /// This method handles key pressed event and verifies its validity
        /// </summary>
        /// <param name="key">key</param>
        public bool SendKeyPress(char key)
        {
            try
            {
                if (ValidateKey(key))
                {
                    switch (char.ToLower(key))
                    {
                        case 'c':
                            DisplayString.Clear(); DisplayString.Append("0");
                            EnteredString.Clear();
                            Number1 = 0; Number2 = 0;
                            break;
                        case 's':
                            toggleSign();
                            break;
                        case '+':
                        case '-':
                        case 'x':
                        case '/':
                            checkAndOperate(key);
                            newNumber = true;
                            break;
                        case '.':
                            if (!DisplayString.ToString().Contains("."))
                                DisplayString.Append('.');
                            break;
                        case '=':                       
                            if (isOperator(EnteredString[EnteredString.Length - 2]))
                                Number2 = Number1;
                            operate(prevOperator);
                            Number1 = 0; Number2 = 0;
                            newNumber = true;
                            prevOperator = '\0';
                            DisplayString.Clear();
                            if (error)
                            {
                                DisplayString.Append("-E-");
                                error = false;
                            }
                            else
                                DisplayString.Append(Answer);
                            break;
                        default:                           
                            if (newNumber || (Number2 == 0 && !DisplayString.ToString().Contains(".")))
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
            catch (Exception e)
            {              
                Console.WriteLine("Exception occurred! " + e.Message);
                return false;
            }
        }
    }
}
