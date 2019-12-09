using System.Collections.Generic;
using MyFace.DataAccess;

namespace MyFace.Models.ViewModels
{
    public class UserListViewModel
    {
        public string Username { get; }
        public IEnumerable<string> ListOfUsers { get; }

        public UserListViewModel(string username, IEnumerable<string> listOfUsers)
        {
            Username = username;
            ListOfUsers = listOfUsers;
        }
    }
}


         
        
       
