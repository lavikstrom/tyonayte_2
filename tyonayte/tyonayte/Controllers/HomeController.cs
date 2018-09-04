using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace tyonayte.Controllers
{

    public class HomeController : Controller
    {
        public const String AddAction = "Add";
        public const String PrimeAction = "Prime";
        public const String OtherAction = "Other";
        public const String EmptyMsg = "Merkkijono näyttäisi olevan tyhjä.";
        public const String ParseErrorStart = "Ohjelma ei osaa muuntaa merkkijonoa ";
        public const String ParseErrorEnd = " luvuiksi.";
        public const String PrimeStart = "Luku ";
        public const String ParseErrorResult = "Unable to convert input into number";
        public const String EmptyResult = "No input";

        public static readonly char[] delimiterChars = { ' ', ',', '.', ':', ';' };
        private Models.Calculator calculator = new Models.Calculator();

        public IActionResult Index(String Numbers = "", String Calculate = OtherAction)
        {
            int[] NumbersToSum;
            int Sum;
            bool Prime;

            ViewData["Message1"] = "";
            ViewData["Message2"] = "";
            ViewData["Message3"] = "";
            ViewData["InputNums"] = "";
            ViewData["Result"] = "";
            ViewData["ResultOut"] = "";

            switch (Calculate)
            {
                case AddAction:
                    if (Numbers != null)
                    {
                        try
                        {
                            NumbersToSum = StringToNumbers(Numbers);
                            Sum = calculator.Add(NumbersToSum);
                            ViewData["Message1"] = "Lukujen ";
                            ViewData["InputNums"] = Numbers;
                            ViewData["Message2"] = " summa on ";
                            ViewData["Result"] = Sum;
                            ViewData["ResultOut"] = Sum;
                            ViewData["Message3"] = ".";
                        }
                        catch (FormatException fe)
                        {
                            ViewData["Message1"] = ParseErrorStart;
                            ViewData["InputNums"] = Numbers;
                            ViewData["Message2"] = ParseErrorEnd;
                            ViewData["Result"] = ParseErrorResult;
                        }
                    }
                    else
                    {
                        ViewData["Message1"] = EmptyMsg;
                        ViewData["Result"] = EmptyResult;
                    }
                            break;
                case PrimeAction:
                    if (Numbers != null)
                    {
                        try
                        {
                            NumbersToSum = StringToNumbers(Numbers);
                            Sum = calculator.Add(NumbersToSum);
                            Prime = calculator.IsPrime(Sum);

                            if (Prime)
                            {
                                ViewData["Message1"] = "Luku ";
                                ViewData["InputNums"] = Sum;
                                ViewData["Message2"] = " on alkuluku.";
                                ViewData["Result"] = Prime;
                            }
                            else
                            {
                                ViewData["Message1"] = "Luku ";
                                ViewData["InputNums"] = Sum;
                                ViewData["Message2"] =  " ei ole alkuluku.";
                                ViewData["Result"] = Prime;

                            }
                        }
                        catch (FormatException fe)
                        {
                            ViewData["Message1"] = ParseErrorStart;
                            ViewData["InputNums"] = Numbers;
                            ViewData["Message2"] = ParseErrorEnd;
                            ViewData["Result"] = ParseErrorResult;
                        }
                        
                    }
                    else
                    {
                        ViewData["Message1"] = EmptyMsg;
                        ViewData["Result"] = EmptyResult;
                    }
                    break;
                default:
                    ViewData["Message1"] = "Kirjoita tutkittava luku tai luvut kenttään ja valitse haluamasi toiminto.";
                    break;
            }
            return View();
        }


        public IActionResult Error()
        {
            return View();
        }

        private int[] StringToNumbers(String input)
        {
            String[] NumbersAsStrings;
            int[] Output;
            bool ParseSuccess = true;

            NumbersAsStrings = input.Split(delimiterChars, StringSplitOptions.RemoveEmptyEntries);

            Output = new int[NumbersAsStrings.Length];

            for (int i = 0; i < NumbersAsStrings.Length; i++)
            {
                if (ParseSuccess)
                {
                    ParseSuccess = Int32.TryParse(NumbersAsStrings[i], out Output[i]);
                }
                else
                {
                    i = NumbersAsStrings.Length;
                }
            }
            if (ParseSuccess)
            {
                return Output;
            }
            else
            {
                throw new FormatException("Could not parse string:" + input);
            }
        }
    }
}
