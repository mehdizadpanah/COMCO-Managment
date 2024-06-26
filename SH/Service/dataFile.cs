﻿using System.Text.Json;
using SH.Data.ModelVM.Users;

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

        public List<ProgramGroupVm>? GetProgramGroupVms()
        {
            var fileString = readFromFile("programGroupVm.txt");
            if (fileString == "") return new List<ProgramGroupVm>();
            var result = JsonSerializer.Deserialize<List<ProgramGroupVm>>(fileString);
            return result;
        }

        public void SaveProgramGroupVms(IEnumerable<ProgramGroupVm> programGroupVms)
        {
            DeleteFile("programGroupVm.txt");
            var stringToWrite = JsonSerializer.Serialize(programGroupVms);
            WriteToFile("programGroupVm.txt", stringToWrite);
        }

    }
}
