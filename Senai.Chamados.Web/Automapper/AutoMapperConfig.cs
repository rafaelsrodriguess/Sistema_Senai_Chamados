﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Senai.Chamados.Web.Automapper
{
    public class AutoMapperConfig 
    {
        public static void RegisterMapping ()
        {
            Mapper.Initialize(x =>
           {
               x.AddProfile<DomainToViewModelMappingProfile>();
               x.AddProfile<ViewModelToDomainMappingProfile>();

           });
        }
    }
}