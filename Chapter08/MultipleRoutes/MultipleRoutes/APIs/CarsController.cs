﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MultipleRoutes.APIs {

    public class CarsController : ApiController {

        public string[] Get() {

            return new string[] { 
                "Car 1",
                "Car 2",
                "Car 3"
            };
        }
    }
}