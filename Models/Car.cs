
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Homework 1
//	File Name:		Car.cs
//	Description:    A web application for Car and Service Record Management
//	Course:			CSCI 3110-001 - Advanced Web Design and Development
//	Author:			Duncan Perkins, perkinsdt@goldmail.etsu.edu, Department of Computing, East Tennessee State University
//	Created:	    Monday, October 13th, 2015
//	Copyright:		Duncan Perkins, 2015
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MotorCarFleet.Models
{
    /// <summary>
    /// Class for Car entities
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Default constructor for showing something in the tables before Service Records are entered.
        /// </summary>
        public Car()
        {
            LastService = "N/A";
            NextService = "N/A";
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string VIN { get; set; }
        public string License { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int TimesServiced
        {
            get; set;
        }
        public string LastService { get; set; }
        public string NextService { get; set; }

        //collection for ServiceRecords relationships
        public virtual ICollection<ServiceRecord> ServiceRecords { get; set; }
    }
}