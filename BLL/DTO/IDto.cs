using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public interface IDto
    {
        string Icon { get; set; }
        string Name { get; set; }
        DateTime Date { get; set; }
        string Type { get; set; }
        string Path { get; set; }
    }
}
