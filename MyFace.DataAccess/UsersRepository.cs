using System.Collections.Generic;
using Dapper;
using System;

namespace MyFace.DataAccess
{
    public interface IUserRepository
    {
        IEnumerable<string> GetAllUsers();
        void SignUp(User loginViewModel);
        User Login(string username);
    }

    public class UserRepository : IUserRepository
    {

        public IEnumerable<string> GetAllUsers()
        {
            using (var db = ConnectionHelper.CreateSqlConnection())
            {
                return db.Query<string>("SELECT username from user_account");
            }
        }

        public void SignUp(User loginViewModel)
        {
            using (var db = ConnectionHelper.CreateSqlConnection())
            {
                db.Execute($"INSERT INTO user_account (firstname, surname, dob, username, password, email, created_on, last_login) VALUES (@firstname, @surname, @dob, @username, @password, @email, current_timestamp, current_timestamp)", loginViewModel);
            }
        }


        public User Login(string username)
        {
            using (var db = ConnectionHelper.CreateSqlConnection())
            {
                User password = db.QueryFirstOrDefault<User>("SELECT * FROM user_account WHERE username = @username", new { username });

                return password;
            }
        }
    }
}
