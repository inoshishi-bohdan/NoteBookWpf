using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfTrainApp1.Models;

namespace WpfTrainApp1.Services
{
    public class FileIOServices
    {
        private readonly string PATH;
        public FileIOServices(string path)
        { 
            PATH = path;    
        }
        public BindingList<ToDoModel> LoadData()
        {
            var fileexists = File.Exists(PATH);
            if (!fileexists)
            {
                File.CreateText(PATH).Dispose();
                return new BindingList<ToDoModel>();
            }
            using (var reader  = File.OpenText(PATH))
            {
                var fileText = reader.ReadLine();
                return JsonConvert.DeserializeObject<BindingList<ToDoModel>>(fileText); 
            }
        }
        public void SaveData(object ToDoDataList)
        {
            using (StreamWriter writer = File.CreateText(PATH))
            {
                string output = JsonConvert.SerializeObject(ToDoDataList);
                writer.Write(output);
            }
        }
    }
}
