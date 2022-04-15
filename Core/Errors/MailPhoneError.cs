using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Errors
{
    public class MailPhoneError : Exception
    {
        public MailPhoneError() : base("ERRORMAILORPHONE")
        {
        }
    }
}
