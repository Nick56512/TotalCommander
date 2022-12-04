using BLL.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class FolderService
    {
        public IEnumerable<FolderDTO> GetAll(string path)
        {
            List<FolderDTO> folders = new List<FolderDTO>();
            try
            {
                foreach (var item in Directory.GetDirectories(path))
                {
                    folders.Add(new FolderDTO(item));
                }
            }
            catch { }
            return folders;
        }
    }
}
