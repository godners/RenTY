using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace testc
{
    internal class Program
    {
        static void Main(string[] args)
        {

            String a = RenTY.HASH16.GetHash("edmea");
            Console.WriteLine(a);
            Console.ReadKey();


        }

        static void a()
        {
            Console.WriteLine(888);
            Thread.Sleep(5000);
        }
    }
}
