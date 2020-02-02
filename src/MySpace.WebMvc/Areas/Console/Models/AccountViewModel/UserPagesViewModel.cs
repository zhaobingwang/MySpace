using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySpace.WebMvc.Areas.Console.Models.AccountViewModel
{
    public class UserPagesViewModel
    {
        public int TotalCount { get; set; }
        public List<UserListViewModel> Users { get; set; }
    }
    public class UserListViewModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public string Avatar { get; set; }
    }
}
