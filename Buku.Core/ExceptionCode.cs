using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buku.Core
{

    public abstract class ExceptionCode
    {
        public enum BukuExceptionGeneral
        {
            [Description("An unknown error occured")]
            unhandled_exception = 0
        }

        public enum BukuExceptionCode
        {
            [Description("Buku not found")]
            BukuNotFound = 4001,

            [Description("Buku is invalid")]
            BukuIsInvalid = 4002
        }
    }
}
