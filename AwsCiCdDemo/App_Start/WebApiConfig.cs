﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace AwsCiCdDemo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "CommitApi",
                routeTemplate: "api/commits",
                defaults: new { controller = "commit" }
            );

            config.Routes.MapHttpRoute(
                name: "PipelineApi",
                routeTemplate: "api/pipeline",
                defaults: new { controller = "pipeline" }
            );
        }
    }
}
