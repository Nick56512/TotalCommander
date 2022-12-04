using BLL.Modules;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalCommander.ViewModels;

namespace TotalCommander.Infrastructure
{
    class ServiceLocator
    {
        IKernel kernel;
        public ServiceLocator()
        {
            kernel = new StandardKernel(new TotalCommanderModule());
        }
        public ListFilesAndDirectoriesViewModel ListFilesAndDirectoriesViewModel => kernel.Get<ListFilesAndDirectoriesViewModel>();
        
    }
}
