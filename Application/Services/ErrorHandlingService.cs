using Application.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ErrorHandlingService : IErrorHandlingService
    {
        public string HandleError(Exception e)
        {
            if(e.Message.Contains("See the inner exception for details"))
            {
                if (e.InnerException.Message.Contains("conflicted with the REFERENCE")) 
                {
                    return "There is reference to another table.";
                }
            }
            else
            {
                return e.Message;
            }
            return e.Message;
        }
    }
}
