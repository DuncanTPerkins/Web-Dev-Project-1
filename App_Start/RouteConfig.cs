
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Homework 1
//	File Name:		RouteConfig.cs
//	Description:    A web application for Car and Service Record Management
//	Course:			CSCI 3110-001 - Advanced Web Design and Development
//	Author:			Duncan Perkins, perkinsdt@goldmail.etsu.edu, Department of Computing, East Tennessee State University
//	Created:	    Monday, October 13th, 2015
//	Copyright:		Duncan Perkins, 2015
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MotorCarFleet
{
    /// <summary>
    /// class for routing to controllers 
    /// </summary>
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //controller route for Service Record Views
            routes.MapRoute(
                name: "Records",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Record", action = "Index", id = UrlParameter.Optional }
            );

            //controller route for Main Car Views
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );


        }
    }
}
