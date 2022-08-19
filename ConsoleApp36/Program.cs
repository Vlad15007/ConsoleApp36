using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp36
{
    public class Myclass
    {
        public delegate void EventDelegate();

        public event EventDelegate myEvent = null;


        public void InvokeMetod()
        {
            if(myEvent != null)
            {
                myEvent.Invoke();
            }
        }
    }

    internal class Program
    {
        static void other()
        {
            Console.WriteLine(123);
        }

        static void Main(string[] args)
        {
            Myclass kletka = new Myclass();

            kletka.myEvent += other;
            kletka.myEvent += Statics.Metod;




            Console.ReadKey();


            kletka.InvokeMetod();

            Console.ReadKey();
        }
    }

    static class Statics
    {
        public static void Metod()
        {
            Console.WriteLine(123);
        }
    }
}
