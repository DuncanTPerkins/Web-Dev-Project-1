//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Homework 1
//	File Name:		RecordController.cs
//	Description:    A web application for Car and Service Record Management
//	Course:			CSCI 3110-001 - Advanced Web Design and Development
//	Author:			Duncan Perkins, perkinsdt@goldmail.etsu.edu, Department of Computing, East Tennessee State University
//	Created:	    Monday, October 13th, 2015
//	Copyright:		Duncan Perkins, 2015
//
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
using MotorCarFleet.DataContexts;
using MotorCarFleet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MotorCarFleet.Controllers
{
    /// <summary>
    /// Class for controlling the views related to the Service Record objects.
    /// </summary>
    public class RecordController : Controller
    {
        //database object
        private MotorFleetDb _db = new MotorFleetDb();

        /// <summary>
        /// method for database disposing maintenance
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// Get method for loading view for Adding record to Car
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Car object to he added to</returns>
        [HttpGet]
        public ActionResult AddRecord(int id)
        {
            Car car = _db.Cars.Find(id);
            return View(car);
        }

      /// <summary>
      /// Get method for loading view for editing Service Records
      /// </summary>
      /// <param name="id"></param>
      /// <returns>Service Record Object</returns>
        [HttpGet]
        public ActionResult EditRecord(int id)
        {
            ServiceRecord Record = _db.ServiceRecords.Find(id);
            return View(Record);
        }

        /// <summary>
        /// Post method for processing Record to be edited
        /// </summary>
        /// <param name="Record"></param>
        /// <returns>Redirection to View page</returns>
        [HttpPost]
        public ActionResult EditRecord(ServiceRecord Record)
        {
            _db.Entry(Record).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("View");
        }

        /// <summary>
        /// Post method for processing record to be added 
        /// </summary>
        /// <param name="carId"></param>
        /// <param name="Record"></param>
        /// <returns>redirection to main index page</returns>
        [HttpPost]
        public ActionResult AddRecord(int carId, ServiceRecord Record)
        {
            Car car = _db.Cars.Find(carId);
            car.ServiceRecords.Add(Record);
            car.TimesServiced++;
            car.NextService = Record.NextService;
            car.LastService = Record.DateServiced;
            _db.Entry(car).State = EntityState.Modified;

            Record.Car = car;
            _db.ServiceRecords.Add(Record);
            _db.SaveChanges();
            return RedirectToAction("/../home/");
        }

        /// <summary>
        /// Get method for loading view for deleting service record.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Record to be deleted</returns>
        [HttpGet]
        public ActionResult DeleteRecord(int id = 0)
        {
            ServiceRecord Record = _db.ServiceRecords.Find(id);
            if (Record == null)
            {
                return HttpNotFound();
            }
            return View(Record);
        }

        /// <summary>
        /// Post method for actual deletion of Service Record object
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Redirection to view page after deletion</returns>
        [HttpPost, ActionName("DeleteRecord")]
        public ActionResult DeleteRecordConfirmed(int id)
        {
            ServiceRecord Record = _db.ServiceRecords.Find(id);
            Record.Car.TimesServiced--;
            Car CarReference = Record.Car;
            _db.ServiceRecords.Remove(Record);
            _db.SaveChanges();
            return RedirectToAction("/../home/view/" + CarReference.Id);
        }

    }
}