using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            runAll();
            Console.ReadLine();
        }

        public static async void runAll()
        {
            await MakePizza(); // This await will make sure not to execute next methords until Pizza is get ready.
            cookRice();
            BoilMilk();

           
        }

        public static async void cookRice()
        {
            // This Task.Run() ensures that it executes parallelly 
            await Task.Run(()=> {
                Thread.Sleep(2500);
                Console.WriteLine("Rice Cooked");
            });          
        }

        public static async void BoilMilk()
        {
            await Task.Run(() =>
            {
                Thread.Sleep(2000);
                Console.WriteLine("Milk Boiled");
            });          
        }

        public static async Task<bool> MakePizza()
        {
            bool result = false;
            await Task.Run(() =>
            {   
                Thread.Sleep(3000);
                Console.WriteLine("Pizza cooked");
                result = true;
            });
            return result;
        }
    }
}
