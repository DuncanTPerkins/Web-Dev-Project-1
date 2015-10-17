
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Homework 1
//	File Name:		ServiceRecord.cs
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
    /// class for Service Record entities 
    /// </summary>
    public class ServiceRecord
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string DateServiced { get; set; }
        public string IssuesFound { get; set; }
        public string NextService { get; set; }
        public string CostOfService { get; set; }

        [ForeignKey("Car")]
        public virtual int CarID { get; set; }
        
        /// <summary>
        /// virtual connection for foreign key relationship
        /// </summary>
        public virtual Car Car { get; set; }
    }
}