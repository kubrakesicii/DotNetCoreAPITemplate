using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Errors
{
    public class ImageError : Exception
    {
        public ImageError() : base("ERRORIMAGE")
        {
        }
    }
}
