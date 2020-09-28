using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Helpers
{
    public class ServiceException : Exception
    {
        public string ExceptionMessage { get; private set; }
       
        public ServiceException(string ExceptionMessage)
        {
            this.ExceptionMessage = ExceptionMessage;
           
        }
    }
}
