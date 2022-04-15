using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Errors
{
    public class BadRequestError : Exception
    {
        private int StatusCode { get; set; }
        public BadRequestError() : base("BADREQUEST")
        {
            StatusCode = 400;
        }
    }
}
