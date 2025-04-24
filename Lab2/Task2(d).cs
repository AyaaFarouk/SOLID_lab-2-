using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Lab2.Task2_c_;

namespace Lab2
{
    internal class Task2_d_
    {
        public interface IRead
        {
            string LoadText();
        }
        public interface IWrite : IRead
        {
            string SaveText();
        }

        public class SqlFile : IWrite
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
 //--------------------------------------------------------------------------
        public class SqlFileManager
        {
            public List<IRead> lstSqlFiles { get; set; }

            public string GetTextFromFiles()
            {
                StringBuilder objStrBuilder = new StringBuilder();
                foreach (var objFile in lstSqlFiles)
                {
                    objStrBuilder.Append(objFile.LoadText());
                }
                return objStrBuilder.ToString();
            }

            public void SaveTextIntoFiles()
            {
                foreach (var objFile in lstSqlFiles)
                {
                    //Check whether the current file object is read-only or not.If yes, skip calling it's  
                    // SaveText() method to skip the exception.
                      if (objFile is IWrite writableFile)
                      {
                        writableFile.SaveText();
                      }

                    else if (objFile is SqlFile sqlFile)
                    {
                        Console.WriteLine($"Skipping save for read-only file: {sqlFile.FilePath}");

                    } 

                }
            }
        }
    }
}
