using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        class CarCollection
        {
            List<Car> collection;
            public CarCollection()
            {
                collection = new List<Car>();
            }
            public CarCollection(string name, int year)
            {
                collection.Add(new Car(name, year));
            }
            public void AddCar(string name, int year)
            {
                collection.Add(new Car(name, year));
            }
            public int CountOfCars()
            {
                if (collection.Count == 0)
                    return 0;
                else
                    return collection.Count;
            }
            public Car this[int index]
            {
                get
                {
                    if (index < collection.Count && index >= 0)
                    {
                        return collection[index];
                    }
                    else
                    {
                        Console.WriteLine("Нет машины под таким номером");
                        return null;
                    }
                }
            }
        }
        class Car
        {
            public string name { get; }
            int year;
            public Car(string name, int year)
            {
                this.name = name;
                this.year = year;
            }
            public void ShowInfo()
            {
                Console.WriteLine(name);
                Console.WriteLine(year);
            }
        }
        static void Main(string[] args)
        {
            CarCollection cars = new CarCollection();
            
            cars.AddCar("Porshe", 2004);
            cars[0].ShowInfo();
            Console.WriteLine();
            Console.ReadKey();
        }
    }
}
