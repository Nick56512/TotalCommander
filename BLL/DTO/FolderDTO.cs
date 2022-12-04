using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BLL.DTO
{
    public class FolderDTO:IDto
    {

        public FolderDTO(string folderPath)
        {
            path = folderPath;
            name = folderPath.Substring(folderPath.LastIndexOf(@"\") + 1);
            date = Directory.GetLastWriteTime(folderPath);
            type = "folder";

            string localPath = Directory.GetCurrentDirectory();
            localPath = localPath.Substring(0, localPath.LastIndexOf(@"\")+1);
            Icon = localPath + @"\icons\folder.png";
        }
        string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
            }
        }
        DateTime date;
        public DateTime Date
        {
            get => date;
            set => date = value;
        }
        string type;
        public string Type
        {
            get => type;
            set => type = value;
        }
        string icon;
        public string Icon
        {
            get => icon;
            set => icon = value;
        }
        string path;
        public string Path 
        { 
            get => path; 
            
            set => path=value; 
        }
    }
}
