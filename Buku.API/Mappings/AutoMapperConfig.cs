using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Buku.API.Mappings
{
    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<BukuAPIMapper>();
            });
        }
    }
}