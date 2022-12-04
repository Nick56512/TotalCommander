using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using TotalCommander.Infrastructure;
using TotalCommander.Views;

namespace TotalCommander.ViewModels
{
    class MainViewModel 
    {
        public UserControl panel1 { get; set; }
        public UserControl panel2 { get; set; }

        public MainViewModel()
        {
            panel1 = new ListFilesAndDirectoriesView();
            panel2 = new ListFilesAndDirectoriesView();
            (panel1.DataContext as ListFilesAndDirectoriesViewModel).Panel2 = panel2;
            (panel2.DataContext as ListFilesAndDirectoriesViewModel).Panel2 = panel1;
        }  
    }
}
