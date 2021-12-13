using System;
using System.Threading;

namespace TestsArchitecture
{
    class Program
    {
        static void Main(string[] args)
        {
            Driver.DriverInstance.GetInstance();
            Driver.DriverInstance.CloseBrowser();
        }
    }
}
