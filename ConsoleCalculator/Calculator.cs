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
        
        
        public Calculator()
        {
            DisplayString = new StringBuilder();
            
        }
    
        public bool SendKeyPress(char key)
        {
           
            return true;
        }
    }
}
