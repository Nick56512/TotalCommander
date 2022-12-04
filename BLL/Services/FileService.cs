using BLL.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BLL.Services
{
    public class FileService
    {
        public IEnumerable<FileDTO> GetAll(string path)
        {
            List<FileDTO> files = new List<FileDTO>();
            try
            {
                foreach (var item in Directory.GetFiles(path))
                {
                    files.Add(new FileDTO(item));
                }
            }
            catch(Exception ex) {

                MessageBox.Show(ex.Message);
            }
            return files;
        }
        public long GetSizeFileInBytes(string path)
        {
            FileStream file = new FileStream(path,FileMode.Open, FileAccess.Read);
            long size = (long)file.Length;
            file.Close();
            return size;
        }
        public Task Copy(string from,string to,Action<int>calc=null)
        {
            return Task.Run(() =>
            {
                int n = 0;
                
                    FileStream fs1 = new FileStream(from, FileMode.Open, FileAccess.Read);
                    FileStream fs2 = new FileStream(to, FileMode.Create);
                    byte[] bytes = new byte[8192];
                    while ((n = fs1.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        calc?.Invoke(n);
                        fs2.Write(bytes, 0, n);
                    }

                    fs1.Close();
                    fs2.Close();
               
              

            });
        }
        public Task Move(string from,string to)
        {
            return Task.Run(() =>
            {
              
                    File.Move(from, to);
               

            });
           
        }
    }
}
