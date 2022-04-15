using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Results
{
    public class SuccessResult : Result
    {
        public SuccessResult() : base(true, "OK") { }
        public SuccessResult(string message) : base(true, message) { }
    }
}
