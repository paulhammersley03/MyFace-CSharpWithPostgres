using System.Collections.Generic;

namespace MyFace.Models.ViewModels
{
    public class UserListViewModel
    {
        public string UserName { get; }
        public IEnumerable<string> ListOfUsers { get; }

        public UserListViewModel(string userName, IEnumerable<string> listOfUsers)
        {
            UserName = userName;
            ListOfUsers = listOfUsers;
        }
    }
}