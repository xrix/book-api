using Buku.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buku.Core
{
    public class BukuExceptions : BaseException
    {
        public BukuExceptions(ExceptionCode.BukuExceptionCode code) : base(EnumHelper.GetDescription(code))
        {
            Code = code.ToString();
        }
    }
}
