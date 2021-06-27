using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Service.Mapper
{
    public class PostulationMapper : IViewModelMapper<Postulation, PostulationViewModel>
    {
        private JobAdvertisementMapper jobAdvertisementMapper = new JobAdvertisementMapper();

        public PostulationViewModel FromModelToViewModel(Postulation model, PostulationViewModel viewModel)
        {
            viewModel.JobAdvertisementId = model.JobAdvertisementId;
            viewModel.JobAdvertisement = jobAdvertisementMapper.FromModelToViewModel(model.JobAdvertisement, new JobAdvertisementViewModel());
            viewModel.EmployeeId = model.EmployeeId;
            viewModel.Status = model.Status;
            viewModel.Date = model.Date;

            return viewModel;
        }

        public Postulation FromViewModelToModel(PostulationViewModel viewModel, Postulation model)
        {
            model.JobAdvertisementId = viewModel.JobAdvertisementId;
            model.JobAdvertisement = jobAdvertisementMapper.FromViewModelToModel(viewModel.JobAdvertisement, new JobAdvertisement());
            model.EmployeeId = viewModel.EmployeeId;
            model.Status = viewModel.Status;
            model.Date = viewModel.Date;

            return model;
        }
    }
}