
//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//
//	Project:	    Homework 1
//	File Name:		HomeController.cs
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
    /// class for controlling the main views relating to Cars
    /// </summary>
    public class HomeController : Controller
    {
        //database context object
        private MotorFleetDb _db = new MotorFleetDb();

        /// <summary>
        /// method for maitenance of database disposing
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }

        /// <summary>
        /// method for main index view
        /// </summary>
        /// <returns>list of Car objects</returns>
        public ActionResult Index()
        {
            return View(_db.Cars);
        }

        /// <summary>
        /// method for creating view for creating new Car objects
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// method for controlling data submitted from Create view for creating car object
        /// </summary>
        /// <param name="Car"></param>
        /// <returns>Car object to be created</returns>
        [HttpPost]
        public ActionResult Create(Car Car)
        {
            _db.Cars.Add(Car);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        /// <summary>
        /// Get call for loading view for editing car objects
        /// </summary>
        /// <param name="id"></param>
        /// <returns>single car object</returns>
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Car car = _db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        /// <summary>
        /// Method for making edit operation to the database with data submitted from Edit view
        /// </summary>
        /// <param name="car"></param>
        /// <returns>Edited car object</returns>
        [HttpPost]
        public ActionResult Edit(Car car)
        {
            _db.Entry(car).State = EntityState.Modified;
            _db.SaveChanges();

            return Redirect("/Home");
        }

        /// <summary>
        /// Get method for loading View method for viewing one specific car object and its related service records
        /// </summary>
        /// <param name="id"></param>
        /// <returns>single car object</returns>
        [HttpGet]
        public ActionResult View(int id)
        {
            return View(_db.Cars.Find(id));
        }

        /// <summary>
        /// Get method for loading delete view for deleting car objects
        /// </summary>
        /// <param name="id"></param>
        /// <returns>car object</returns>
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            Car car = _db.Cars.Find(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        /// <summary>
        /// Post method confirming deletion of car object
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Redirection to index after deletion</returns>
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Car car = _db.Cars.Find(id);
            _db.Cars.Remove(car);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}