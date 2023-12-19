using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopInventory.Account
{
    public class UserFunctionality
    {
        private readonly ApplicationDbContext _context;

        public UserFunctionality(ApplicationDbContext context) {
            _context = context;
        }
        public void ChangePassword()
        {
            User? user = _context.Users.FirstOrDefault();
            Console.WriteLine("--Please give new credeincial for update user name and password---");
            Console.WriteLine("Enter New User Name: ");
            string newUserName = Console.ReadLine();
            Console.WriteLine("Enter New User Password: ");
            string newPassword = Console.ReadLine();
            user.Name = newUserName;
            user.Password = newPassword;
            _context.SaveChanges();
        }
    }
}
