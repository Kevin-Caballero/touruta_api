using System;

namespace Touruta.Core.Exceptions
{
    public class BusinessException : Exception
    {
        public BusinessException()
        {
            
        }

        public BusinessException(string message) : base(message) 
        {
            
        }
    }
}