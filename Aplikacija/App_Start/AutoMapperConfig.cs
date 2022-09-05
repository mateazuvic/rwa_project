using Aplikacija.Models.dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Aplikacija.App_Start
{
    public static class AutoMapperConfig
    {
        public static IMapper Mapper { get; set; }

        public static void Init()
        {
            var config = new MapperConfiguration(con =>
            {
                con.CreateMap<Kupac, KupacDto>();
               
            });

            Mapper = config.CreateMapper();
        }
    }
}