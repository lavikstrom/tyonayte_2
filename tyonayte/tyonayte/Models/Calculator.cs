using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tyonayte.Models
{
    public class Calculator
    {


        public int Add(int[] Numbers)
        {
            //Valmis funktio löytyi
            return Numbers.Sum();
        }

        public bool IsPrime(int Number)
        {
            //Kahta pienemmät luvut eivät ole alkulukuja
            if(Number < 2)
            {
                return false;
            }
            //2 ja 3 ovat alkulukuja
            else if(Number == 2 || Number == 3)
            {
                return true;
            }
            //Niillä jaolliset eivät ole alkulukuja
            else if (Number % 2 == 0|| Number % 3 == 0)
            {
                return false;
            }
            else
            {
                //Riittää, että tarkistetaan luvun neliöjuurta pienemmät luvut
                double SquareRoot = Math.Sqrt(Number);
                int SquareRootInt = (int)Math.Ceiling(SquareRoot);

                //Kaikki luvut voidaan esittää muodossa 6n+k
                //6n+0, 6n+2 ja 6n+4 jaollisia kahdella
                //6n+0 ja 6n+3 jaollisia kolmella
                //Riittää, että tarkistetaan 6n+1 ja 6n+5 (eli 6n-1):
                for(int i = 6; i < SquareRootInt; i+=6)
                {
                    if(Number % (i - 1) == 0|| Number % (i + 1) == 0)
                    {
                        return false;
                    }
                }

                //Jos ei löytynyt, on kyseessä alkuluku
                return true;
            }
        }
    }
}
