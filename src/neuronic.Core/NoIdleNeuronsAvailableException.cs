using System;

namespace neuronic.Core
{
    public class NoIdleNeuronsAvailableException : Exception
    {
        public NoIdleNeuronsAvailableException () : base("No idle neurons available.")
        {
        }
    }
}

