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

        public ActionResult Details(int id)
        {
            JobAdvertisement jobAdvertisement = businessManager.GetJobAdvertisementById(id);
            JobAdvertisementViewModel jobAdvertisementViewModel = jobAdvertisementMapper.FromModelToViewModel(jobAdvertisement, new JobAdvertisementViewModel());

            return View(jobAdvertisementViewModel);
        }

        public ActionResult Create()
        {
            JobAdvertisementViewModel jobAdvertisementViewModel = new JobAdvertisementViewModel();

            jobAdvertisementViewModel.AppStatusList = new SelectList(businessManager.GetAllStatus(), "Id", "Label");

            return View(jobAdvertisementViewModel);
        }

        [HttpPost]
        public ActionResult Create(JobAdvertisementViewModel jobAdvertisementViewModel)
        {
            if(ModelState.IsValid)
            {
                JobAdvertisement newJobAdvertisement = jobAdvertisementMapper.FromViewModelToModel(jobAdvertisementViewModel, new JobAdvertisement());
                int id = businessManager.AddJobAdvertisement(newJobAdvertisement);
                return RedirectToAction("Details", new { id = id });
            }

            return View(jobAdvertisementViewModel);
        }

        public ActionResult Edit(int id)
        {
            JobAdvertisement jobAdvertisement = businessManager.GetJobAdvertisementById(id);
            JobAdvertisementViewModel jobAdvertisementViewModel = jobAdvertisementMapper.FromModelToViewModel(jobAdvertisement, new JobAdvertisementViewModel());

            jobAdvertisementViewModel.AppStatusList = new SelectList(businessManager.GetAllStatus(), "Id", "Label");

            return View(jobAdvertisementViewModel);
        }

        [HttpPost]
        public ActionResult Edit(int id, JobAdvertisementViewModel jobAdvertisementViewModel)
        {
            if (ModelState.IsValid)
            {
                JobAdvertisement newJobAdvertisementData = jobAdvertisementMapper.FromViewModelToModel(jobAdvertisementViewModel, new JobAdvertisement());
                businessManager.UpdateJobAdvertisement(newJobAdvertisementData);
                return RedirectToAction("Details", new { id = id });
            }

            return View("Edit", jobAdvertisementViewModel);
        }

        public ActionResult Delete(int id)
        {
            JobAdvertisement jobAdvertisement = businessManager.GetJobAdvertisementById(id);
            JobAdvertisementViewModel jobAdvertisementViewModel = jobAdvertisementMapper.FromModelToViewModel(jobAdvertisement, new JobAdvertisementViewModel());

            return View(jobAdvertisementViewModel);
        }

        [HttpPost]
        public ActionResult Delete(int id, JobAdvertisementViewModel jobAdvertisementViewModel)
        {
            businessManager.DeleteJobAdvertisement(id);
            return RedirectToAction("Index");
        }
        public ActionResult Search(string s)
        {
            List<JobAdvertisementViewModel> jobAdvertisementViewModels = new List<JobAdvertisementViewModel>();
            List<JobAdvertisement> jobAdvertisements = businessManager.SearchForJobAdvertisement(s);

            foreach (JobAdvertisement jobAdvertisement in jobAdvertisements)
            {
                jobAdvertisementViewModels.Add(jobAdvertisementMapper.FromModelToViewModel(jobAdvertisement, new JobAdvertisementViewModel()));
            }

            return View("Index", jobAdvertisementViewModels);
        }

        [HttpPost]
        public ActionResult Apply(int id)
        {
            businessManager.NewPostulation(id, 1);
            return RedirectToAction("Index", "Profile");
        }

    }
}
