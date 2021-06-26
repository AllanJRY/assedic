using BusinessLayer;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Service.Mapper;

namespace WebApplication.Controllers
{
    public class JobAdvertisementController : Controller
    {
        private BusinessManager businessManager = BusinessManager.Instance();

        private JobAdvertisementMapper jobAdvertisementMapper = new JobAdvertisementMapper();

        public ActionResult Index()
        {
            List<JobAdvertisementViewModel> jobAdvertisementViewModels = new List<JobAdvertisementViewModel>();
            List<JobAdvertisement> jobAdvertisements = businessManager.GetAllJobAdvertisements();

            foreach(JobAdvertisement jobAdvertisement in jobAdvertisements)
            {
                jobAdvertisementViewModels.Add(jobAdvertisementMapper.FromModelToViewModel(jobAdvertisement, new JobAdvertisementViewModel()));
            }

            return View(jobAdvertisementViewModels);
        }

        // GET: JobAdvertisement/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: JobAdvertisement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: JobAdvertisement/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: JobAdvertisement/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: JobAdvertisement/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: JobAdvertisement/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: JobAdvertisement/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
