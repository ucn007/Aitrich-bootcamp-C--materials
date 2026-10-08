using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSample.Test
{
    public class EvenOrOddNumberTest
    {
        //Naming Convention - ClassName_MethodName_ExpectedResult
        public static void EvenOrOddNumber_ReturnsEvenOrOddNumber_ReturnEvenNumber()
        {
            
                //Arrange - Go get your variables, whatever you need your classes, get functions
                int num = 8;
          
                EvenOrOddNumber evenOrOddNumber = new EvenOrOddNumber();

                //Act - Executes the function
                string Result = evenOrOddNumber.ReturnsEvenOrOddNumber(num);

                //Assert - Whatever is returned is it what you want
                if (Result == "Even Number")
                {
                    Console.WriteLine("Passed");
                }
                else
                {
                    Console.WriteLine("Fail");
                }
            }
            
        }
    
}

