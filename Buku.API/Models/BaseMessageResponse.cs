using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buku.API.Models
{
    public class BaseMessageResponse
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public BaseMessageResponse()
        {
            Code = 1;
            Message = "Success";
        }
    }
}