using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    internal class Task2_c_
    {
        public interface IRead
        {
            string LoadText();
        }
        public interface IWrite:IRead
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
        //--------------------------------------------------------------------
        public class ReadOnlySqlFile : IRead
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

            public void SaveText()
            {
                /* Throw an exception when app flow tries to do save. */
                throw new IOException("Can't Save");
            }

        }
    }
}
