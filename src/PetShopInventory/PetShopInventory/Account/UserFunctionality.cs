using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopInventory.Account
{
    public class UserFunctionality
    {
        public void ChangePassword()
        {
            using ApplicationDbContext context = new ApplicationDbContext();
            User? user = context.Users.FirstOrDefault();
            Console.WriteLine("--Please give new credeincial for update user name and password---");
            Console.WriteLine("Enter New User Name: ");
            string newUserName = Console.ReadLine();
            Console.WriteLine("Enter New User Password: ");
            string newPassword = Console.ReadLine();
            user.Name = newUserName;
            user.Password = newPassword;
            context.SaveChanges();
        }
    }
}
