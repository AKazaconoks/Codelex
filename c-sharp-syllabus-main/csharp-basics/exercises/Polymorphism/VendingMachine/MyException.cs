using System;

namespace VendingMachine
{
    public class VendingMachineExceptions : Exception
    {
        public  VendingMachineExceptions(string message) : base(message)
        {
        }
    }
}