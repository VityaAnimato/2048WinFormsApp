using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace _2048WinFormsApp
{
    public static class UserManager
    {
        public static string path = "results.json";

        public static List<User> GetAll()
        {
            if (FileProvider.Exists(path))
            {
                var jsonData = FileProvider.Get(path);
                return JsonConvert.DeserializeObject<List<User>>(jsonData);
            }
            else
            {
                return new List<User>();
            }
        }

        public static void Add(User newUser)
        {
            var users = GetAll();
            users.Add(newUser);

            var jsonData = JsonConvert.SerializeObject(users);

            FileProvider.Write(path, jsonData);
        }
    }

}
