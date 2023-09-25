using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SH.Data.ModelVM;
using System.Text.Json;

namespace SH.Service
{
    public class dataFile
    {
        private string Filepath { get; set; } = "c:/temp/";
        private string readFromFile(string fileName)
        {
            var fullPath = Filepath + fileName;
            var result = "";
            if (!File.Exists(fullPath)) return result;
            using (StreamReader reader = new StreamReader(fullPath))
            {
                result = reader.ReadToEnd();
            }
            return result;
        }

        private void WriteToFile(string fileName, string textToWrite)
        {
            var Fullpath = Filepath + fileName;
            using (StreamWriter writer = new StreamWriter(Fullpath))
            {
                writer.Write(textToWrite);
            }
        }

        public void DeleteFile(string fileName)
        {
            if (!File.Exists(fileName)) return;
            File.Delete(Filepath + fileName);
        }

        public List<ProgramUserVm>? GetProgramUserVms()
        {
            var fileString = readFromFile("programUserVm.txt");
            var result = JsonSerializer.Deserialize<List<ProgramUserVm>>(fileString);
            return result;
        }

       
        public void SaveProgramUserVms(IEnumerable<ProgramUserVm> programUserVms )
        {
            DeleteFile("programUserVm.txt");
            var stringToWrite = JsonSerializer.Serialize(programUserVms);
            WriteToFile("programUserVm.txt" , stringToWrite);
        }
    }
}
