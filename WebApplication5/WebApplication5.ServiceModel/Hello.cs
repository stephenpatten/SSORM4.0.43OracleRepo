﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack;

namespace WebApplication5.ServiceModel
{
    [Route("/hello/{Name}")]
    public class Hello : IReturn<HelloResponse>
    {
        public string Name { get; set; }
    }

    public class HelloResponse
    {
        public string Result { get; set; }
        public ResponseStatus ResponseStatus { get; set; }
    }
}