using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_The_task_to_check_myself_.Infrastructure.Exceptions
{
   public class IncorrectParametersCountException : Exception
    {
        public IncorrectParametersCountException(string message = "Incorrect parameters count.") : base(message) { }
    }
}
