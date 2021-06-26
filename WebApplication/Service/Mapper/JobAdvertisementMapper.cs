using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Service.Mapper
{
    public class JobAdvertisementMapper : IViewModelMapper<JobAdvertisement, JobAdvertisementViewModel>
    {
        private StatusMapper statusMapper = new StatusMapper();

        public JobAdvertisementViewModel FromModelToViewModel(JobAdvertisement model, JobAdvertisementViewModel viewModel)
        {
            viewModel.Id = model.Id;
            viewModel.Title = model.Title;
            viewModel.Description = model.Description;
            viewModel.Salary = model.Salary;
            viewModel.Status = statusMapper.FromModelToViewModel(model.Status, new StatusViewModel());
            viewModel.StatusId = model.StatusId;
            viewModel.Manager= model.Manager;

            return viewModel;
        }

        public JobAdvertisement FromViewModelToModel(JobAdvertisementViewModel viewModel, JobAdvertisement model)
        {
            model.Id = viewModel.Id;
            model.Title = viewModel.Title;
            model.Description = viewModel.Description;
            model.Salary = viewModel.Salary;
            model.Status = statusMapper.FromViewModelToModel(viewModel.Status, new Status());
            model.StatusId = viewModel.StatusId;
            model.Manager = viewModel.Manager;

            return model;
        }
    }
}