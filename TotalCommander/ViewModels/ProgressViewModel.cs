using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TotalCommander.Infrastructure;

namespace TotalCommander.ViewModels
{
    class ProgressViewModel:BaseNotifyPropertyChanged
    {
        long val;
        public long Value 
        { 
            get=>val; 
 
            set
            {
                val = value;
                NotifyOfPopertyChanged();
            }
        }
        long max;
        public long Maximum 
        {
            get=>max;
            set 
            {
                max = value;
                NotifyOfPopertyChanged();
            }
        }
        string percents;
        public string Percents { 
            get=>percents; 
            
            set
            {
                percents = value;
                NotifyOfPopertyChanged();
            }
        }
        public void CalculatePercents(int n)
        {
            Value += n;
            long percents = (100 * Value) / Maximum;
            Percents = $"{percents} %";
        }
    }
}
