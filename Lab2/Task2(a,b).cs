using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Task2
    {
        public interface IFile
        {
            string LoadText();
            string SaveText();
        }

        public class SqlFile : IFile
        {
            public string FilePath { get; set; }
            public string FileText { get; set; }

            public string LoadText()
            {
                if (File.Exists(FilePath))
                {
                    FileText = File.ReadAllText(FilePath);
                    return FileText;
                }
                return string.Empty;
            }

            public string SaveText()
            {
                File.WriteAllText(FilePath, FileText);
                return FileText;
            }
        }
//--------------------------------------------------------------------
        public class SqlFileManager
        {
            public List<IFile> lstSqlFiles { get; set; }

            public string GetTextFromFiles()
            {
                StringBuilder objStrBuilder = new StringBuilder();
                foreach (var file in lstSqlFiles)
                {
                    objStrBuilder.AppendLine(file.LoadText());
                }
                return objStrBuilder.ToString();
            }

            public void SaveTextIntoFiles()
            {
                foreach (var file in lstSqlFiles)
                {
                    file.SaveText();
                }
            }
        }
   
    }

}

