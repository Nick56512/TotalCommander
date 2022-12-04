using BLL.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Modules
{
    public class TotalCommanderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<FileService>().To<FileService>();
            Bind<FolderService>().To<FolderService>();
        }
    }
}
