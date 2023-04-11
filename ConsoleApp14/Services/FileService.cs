using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp14.Services
{

    //glöm inte kolla så det sparas ner korrekt innan inlämning!!
    public class FileService
    {
        public string FilePath { get; set; } = string.Empty;


        public void Save(string filePath, string content)
        {
            if (!string.IsNullOrEmpty(FilePath))
            {
                    using (var sw = new StreamWriter(filePath))
                    {
                        sw.WriteLine(content);
                    }
            }
            
        }

        public string Read(string filePath)
        {
            if (!string.IsNullOrEmpty(FilePath))
            {
                try
                {
                    using (var sr = new StreamReader(filePath))
                    {
                        return sr.ReadToEnd();
                    }
                }
                catch { }
            }

            return string.Empty;

        }
    }
}
