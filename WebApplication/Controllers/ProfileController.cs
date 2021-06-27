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
    public class ProfileController : Controller
    {
        private BusinessManager businessManager = BusinessManager.Instance();

        private PostulationMapper postulationMapper = new PostulationMapper();
        public ActionResult Index()
        {
            List<PostulationViewModel> postulationViewModels = new List<PostulationViewModel>();
            List<Postulation> postulations = businessManager.GetPostulationByEmployeeId(1);

            foreach(Postulation postulation in postulations)
            {
                postulationViewModels.Add(postulationMapper.FromModelToViewModel(postulation, new PostulationViewModel()));
            }

            return View(postulationViewModels);
        }
    }
}