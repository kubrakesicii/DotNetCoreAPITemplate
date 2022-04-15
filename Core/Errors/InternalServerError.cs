using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Errors
{
    public class InternalServerError : Exception
    {
        public InternalServerError() : base("INTERNALSERVERERROR")
        {
        }
    }
}
