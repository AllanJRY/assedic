using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Service.Mapper
{
    interface IViewModelMapper<T, V>
    {
        V FromModelToViewModel(T model, V viewModel);
        T FromViewModelToModel(V viewModel, T model);
    }
}
