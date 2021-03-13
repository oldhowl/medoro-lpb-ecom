using System;

namespace Medoro.Exceptions
{
    public class MedoroException : Exception
    {
        public MedoroException(string? message) : base(message)
        {
        }
    }
}