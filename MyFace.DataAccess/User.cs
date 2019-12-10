using System;

namespace MyFace.DataAccess
{
    public class User
    {
        public string user_id { get; set; }
        public string firstname { get; set; }
        public string surname { get; set; }
        public DateTime dob { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string created_on { get; set; }
        public string last_login { get; set; }
    }
}