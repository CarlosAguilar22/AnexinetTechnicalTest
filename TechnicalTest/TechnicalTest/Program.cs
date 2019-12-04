using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnicalTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please select an option:");
            Console.WriteLine("1.- Leap year function.");
            Console.WriteLine("2.- Repeated strings.");
            Console.WriteLine("3.- String compression.");
            Console.WriteLine("4.- Closed Brackets.");
            Console.WriteLine("5.- Bounding box area.");
            string selectedoption = Console.ReadLine();
            int intselectedoption = 0;
            bool success = Int32.TryParse(selectedoption, out intselectedoption);
            // Verify if the user's option is valid
            if (success)
            {
                if (intselectedoption >= 1 && intselectedoption <= 5)
                {
                    ExerciseFunctions ef = new ExerciseFunctions();

                    switch (intselectedoption)
                    {
                        case 1:
                            {
                                Console.WriteLine("Please privides a valid date:");
                                string stringDate = Console.ReadLine();
                                try
                                {
                                    bool isLeapYear = ef.leapYear(stringDate);
                                    if (isLeapYear)
                                        Console.WriteLine("The year provided is a Leap Year");
                                    else
                                        Console.WriteLine("The year provided is NOT a Leap Year");
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("The string provided is not a valid date");
                                }
                                Console.ReadLine();
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Please provide 2 strings without duplicate characteres:");
                                Console.WriteLine("Please input the first string:");
                                string firstString = Console.ReadLine();
                                Console.WriteLine("Please input the second string:");
                                string secondString = Console.ReadLine();
                                try
                                {
                                    Char[] repeatedCharacters = ef.repeatedStrings(firstString, secondString);
                                    Console.WriteLine("These are the repeated characters found in both provided scripts: ");
                                    foreach (Char currentCharacter in repeatedCharacters)
                                    {
                                        Console.Write(currentCharacter + ",");
                                    }                                    
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                Console.ReadLine();
                                break;
                            }
                        case 3:
                            {                                
                                Console.WriteLine("Please input the original string:");
                                string originalString = Console.ReadLine();
                                String compressedString = ef.compressedString(originalString);
                                Console.WriteLine("This is the compressed string: " + compressedString);
                                Console.ReadLine();
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("Please provide the string with brackets:");
                                string bracketsString = Console.ReadLine();
                                try
                                {
                                    bool isValid = ef.closedBrackets(bracketsString);
                                    if(isValid)
                                        Console.WriteLine("The string provided has brackets properly closed");
                                    else
                                        Console.WriteLine("The string provided has NOT brackets properly closed");
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                Console.ReadLine();
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine("Please privide how many cartesian points you will provide:");
                                string strCartesianPoints = Console.ReadLine();
								int cartesianPoints = 0;
								bool success2 = Int32.TryParse(strCartesianPoints, out cartesianPoints);
								if(success2)
								{
									try
									{
										List<CartesianPoint> lstCartesianPoints = new List<CartesianPoint>();
										Console.WriteLine("Please provide the cartesian points separate by comma.");
										for(int x=0; x<cartesianPoints;x++)
										{
											Console.WriteLine("Please input the cartesian point number: " + x);
											string strCP = Console.ReadLine();										
											String[] arrayCartesianPoint = strCP.Split(',');
											CartesianPoint cartesianPoint = new CartesianPoint();
											cartesianPoint.X = Int32.Parse(arrayCartesianPoint[0]);
											cartesianPoint.Y = Int32.Parse(arrayCartesianPoint[1]);
											lstCartesianPoints.Add(cartesianPoint);
										}										
										int smallestArea = ef.smallestArea(lstCartesianPoints);
										Console.WriteLine("The smallest bounding box area of the provided cartesian points is: " + smallestArea);
									}
									catch (Exception ex)
									{
										Console.WriteLine(ex.Message);
									}
								}
								else
									Console.WriteLine("Please input a valid number of cartesian points:");
								
                                Console.ReadLine();
                                break;
                            }
                    }
                }
                else
                {
                    Console.WriteLine("The input option is valid, please try again.");
                    Console.ReadLine();
                }
            }
            else
            {
                Console.WriteLine("The input option is not a number, please try again.");
                Console.ReadLine();
            }
        }
    }
}
