//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Homework 1
//	File Name:		Configuration.cs
//	Description:    A web application for Car and Service Record Management
//	Course:			CSCI 3110-001 - Advanced Web Design and Development
//	Author:			Duncan Perkins, perkinsdt@goldmail.etsu.edu, Department of Computing, East Tennessee State University
//	Created:	    Monday, October 13th, 2015
//	Copyright:		Duncan Perkins, 2015
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace MotorCarFleet.DataContexts.MotorFleetMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MotorCarFleet.DataContexts.MotorFleetDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"DataContexts\MotorFleetMigrations";
        }

        protected override void Seed(MotorCarFleet.DataContexts.MotorFleetDb context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
