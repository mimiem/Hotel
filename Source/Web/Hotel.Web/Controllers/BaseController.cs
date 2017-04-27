﻿namespace Hotel.Web.Controllers
{
    using AutoMapper;
    using Infrastructure.Mapping;
    using System.Web.Mvc;

    public class BaseController : Controller
    {
        protected IMapper Mapper
        {
            get
            {
                return AutoMapperConfig.Configuration.CreateMapper();
            }
        }
    }
}