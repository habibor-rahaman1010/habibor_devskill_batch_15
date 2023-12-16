using Microsoft.EntityFrameworkCore;
using PetShopInventory.Account;
using PetShopInventory.PetsUtility;
using System;
using System.Threading.Channels;

namespace PetShopInventory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using ApplicationDbContext context = new ApplicationDbContext();
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
                            string newUserName = Console.ReadLine();
                            Console.WriteLine("Enter New User Name: ");
                            string newPassword = Console.ReadLine();
                            user.Name = newUserName;
                            user.Password = newPassword;
                            context.SaveChanges();
                            break;

                        case 2:
                            Console.WriteLine($"---{user.Name} Hello, You Can Operate In This Below Options----");
                            Console.WriteLine("""
                            Inpute 1: Add Pets In Store:  
                            Inpute 2: Show All Pets Are Available:  
                            """);
                            int condition2 = int.Parse(Console.ReadLine());
                            switch (condition2)
                            {
                                case 1:
                                    PetCage casePets = new PetCage
                                    {
                                        CageName = "Devon Rex Cage",
                                        CageType = "Platinum",
                                        PetsList = new List<Pet>
                                        {
                                            new Pet { Name = "Devon Rex Cat", Description = "This is pluggi cat", Color = "Balck", Type = "Turkish Van" }
                               
                                        }
                                    };
                                    context.PetCages.Add(casePets);
                                    context.SaveChanges();
                                    break;

                                case 2:
                                    Console.WriteLine("----------Thouse Cate Are Available In This Pet Shop Inventory---------");
                                    List<PetCage> petCagesWithPets = context.PetCages.Include(c => c.PetsList).ToList();
                                    foreach (PetCage cage in petCagesWithPets)
                                    {
                                        Console.WriteLine($"---------This Pets Are Cage The '{cage.CageName}' ---------");
                                        Console.WriteLine($"Cage Id: {cage.ID} Cage Name: {cage.CageName} Cage Type: {cage.CageType}");
                                        foreach (Pet pet in cage.PetsList)
                                        {
                                            Console.WriteLine($"Pet Id: {pet.Id} Nama: {pet.Name} Description: {pet.Description} Color: {pet.Color} Type: {pet.Type}");
                                        }
                                        Console.WriteLine();
                                    }

                                    break;
                                    
                                default:

                                    break;
                            }
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
