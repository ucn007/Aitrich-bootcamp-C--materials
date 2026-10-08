using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestSample.Tests
{
    
        public class EvenOrOddNumberTests
        {
            [Fact]
            public void ReturnsEvenOrOddNumber_Input8_ReturnsEvenNumber()
            {
                // Arrange
                int num = 8;

                EvenOrOddNumber service =
                    new EvenOrOddNumber();

                // Act
                string result = service.ReturnsEvenOrOddNumber(num);

                // Assert
                Assert.Equal("Even Number", result);
            }
        }
    }

