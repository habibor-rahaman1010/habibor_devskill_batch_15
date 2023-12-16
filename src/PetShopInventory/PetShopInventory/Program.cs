using PetShopInventory.Account;
using System;
using System.Threading.Channels;

namespace PetShopInventory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            User? user =  context.Users.FirstOrDefault();

            Console.WriteLine("Plese enter your user name: ");
            string? name = Console.ReadLine();

            Console.WriteLine("Plese enter your password");
            string? password = Console.ReadLine();

            if (user != null)
            {
                if (user.Name == name && user.Password == password)
                {
                    Console.WriteLine("\n--------User login successfully--------- \n");
                    Console.WriteLine("""
                        Inpute 1: to Change Password: 
                        Inpute 2: Go To Pet Shop Inventory: 
                         
                        """);
                    int condition = int.Parse(Console.ReadLine());
                    switch (condition)
                    {
                        case 1:
                            Console.WriteLine("--Please give new credeincial for update user name and password---");
                            Console.WriteLine("Enter New User Name: ");
                            string newuserName = Console.ReadLine();
                            Console.WriteLine("Enter New User Name: ");
                            string newPassword = Console.ReadLine();
                            user.Name = newuserName;
                            user.Password = newPassword;
                            context.SaveChanges();
                            break;

                        case 2:
                            Console.WriteLine($"---{user.Name} Hello, You Can Operate In This Below Options----");
                            break;

                        default:
                            Console.WriteLine("Don't match");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("\n--------user name or password don't match, plese tryagain--------\n");
                }
            }
        }
    }
}
