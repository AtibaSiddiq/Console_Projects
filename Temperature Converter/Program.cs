using System;

namespace Temperature_Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string greetings = "\n \t  temperature converter app\n";
            string greet = greetings.ToUpper();
            System.Console.WriteLine(greet);
           Menu();
        }
        static void Menu()
        {
            bool exit = false;
            while (!exit)
            {
                System.Console.WriteLine("Kindly select the operation to perform\n1. \t Convert Celcius to Farenheit\n2. \t Convert Farenheit to Celcius\n0. \t Exit");
                int opt = int.Parse(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        System.Console.WriteLine("Input value to convert to farenheit");
                        double celcius = double.Parse(Console.ReadLine());
                        double farenheitResult = ConvertToFarenheit(celcius);
                        System.Console.WriteLine($"{celcius}C in farenheit is: {farenheitResult}F");
                        break;
                    case 2:
                    System.Console.WriteLine("Input value to convert to celcius");
                        double farenheit = double.Parse(Console.ReadLine());
                        double celciusResult = ConvertToCelcius(farenheit);
                        System.Console.WriteLine($"{farenheit}F in celcius is: {celciusResult}C");
                        break;
                    case 0:
                        exit = true;
                        System.Console.WriteLine("Thank you for using our Temerature Converter App");
                        break;
                    default:
                        System.Console.WriteLine("Wrong Input");
                        break;
                }
            }
        }
        static double ConvertToCelcius(double farenheit)
        {
            return (farenheit - 32) * 0.56;
        }
        static double ConvertToFarenheit(double celcius)
        {
            return (celcius * 1.8) + 32;
            
        }
    }
}
