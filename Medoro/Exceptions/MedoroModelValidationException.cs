using System;

namespace Medoro.Exceptions
{
    public class MedoroModelValidationException : Exception
    {
        public MedoroModelValidationException(string argName, string message) : base(
            $"Wrong parameter: {argName}. {message}")
        {
        }
        
        public MedoroModelValidationException(string message) : base(message)
        {
        }
    }
}