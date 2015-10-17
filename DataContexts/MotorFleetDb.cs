//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Homework 1
//	File Name:		MotorFleetDb.cs
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
using System.Data.Entity;
using MotorCarFleet.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace MotorCarFleet.DataContexts
{
    /// <summary>
    /// Data context class for Database connection
    /// </summary>
    [NotMapped]
    public class MotorFleetDb : DbContext
    {
        /// <summary>
        /// Default constructor for Database context class
        /// </summary>
        public MotorFleetDb()
            :base("name=DefaultConnection")
        {
            Database.SetInitializer<MotorFleetDb>(new CreateDatabaseIfNotExists<MotorFleetDb>());

        }

        /// <summary>
        /// Overriding for the purpose of on cascade delete and foreign key relationships
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasMany(c => c.ServiceRecords)
                .WithOptional()
                .HasForeignKey(c => c.CarID)
                .WillCascadeOnDelete(true);
        }


        public DbSet<Car> Cars { get; set; }
        public DbSet<ServiceRecord> ServiceRecords { get; set; }
    }
}