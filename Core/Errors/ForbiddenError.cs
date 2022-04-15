using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Errors
{
    public class ForbiddenError : Exception
    {
        public ForbiddenError() : base("FORBIDDEN")
        {
        }
    }
}
