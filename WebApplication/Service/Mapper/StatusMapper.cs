using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Models;

namespace WebApplication.Service.Mapper
{
    public class StatusMapper : IViewModelMapper<Status, StatusViewModel>
    {
        public StatusViewModel FromModelToViewModel(Status model, StatusViewModel viewModel)
        {
            viewModel.Id = model.Id;
            viewModel.Label = model.Label;

            return viewModel;
        }

        public Status FromViewModelToModel(StatusViewModel viewModel, Status model)
        {
            if (viewModel == null) return null;

            model.Id = viewModel.Id;
            model.Label = viewModel.Label;

            return model;
        }
    }
}