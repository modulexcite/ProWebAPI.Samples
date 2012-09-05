﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiControllerInitializeMethodSample.Infrastructure;

namespace ApiControllerInitializeMethodSample.Controllers {

    public class CarsController : ApiControllerBase {

        public string[] Get() {

            return new string[] { 
                "Cars 1",
                "Cars 2",
                "Cars 3"
            };
        }
    }
}