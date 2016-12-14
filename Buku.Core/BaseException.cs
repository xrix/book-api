using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buku.Core
{
    public class BaseException : Exception
    {
        public string Code { get; set; }

        public BaseException(string description)
            : base(description)
        {
            if (description == null) throw new ArgumentNullException("description");
            Code = description;
        }
    }
}
