using Newtonsoft.Json.Linq;
using SeleniumCsharpSpecflow.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCsharpSpecflow.Support
{
    public interface IJsonHelper
    {
        JObject GetTestDataJsonObject();
        User GetUser(string userKey);
    }
    public class JsonHelper: IJsonHelper
    {

        public JObject GetTestDataJsonObject()
        {
            string solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string registrationDataPath = Path.Combine(solutionDirectory, "Support");
            var jsonFilePath = registrationDataPath + "/registration.data.json";

   
            JObject jObject = JObject.Parse(File.ReadAllText(jsonFilePath));
            return jObject;
        }

        public User GetUser(string userKey)
        {
            JObject jsonData = GetTestDataJsonObject();
            JObject userData = (JObject)jsonData[userKey];
            return userData.ToObject<User>();
        }


    }
}
