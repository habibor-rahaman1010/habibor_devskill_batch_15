using Microsoft.EntityFrameworkCore;
using PetShopInventory.Account;
using PetShopInventory.DbContextUtility;
using PetShopInventory.FeedingScheduleUtitlity;
using PetShopInventory.PetsCURDoperation;
using PetShopInventory.PetsPurchaseUtility;
using PetShopInventory.PetsUtility;
using PetShopInventory.SalesRecords;
using PetShopInventory.ShopReports;
using System;
using System.Threading.Channels;

namespace PetShopInventory
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool terminate = true;

            while (terminate)
            {
                string connection = ConnectionInfo.ConnectionString;

                using ApplicationDbContext context = new ApplicationDbContext(connection);

                User? user = context.Users.FirstOrDefault();

                Console.WriteLine("Plese enter your user name: ");
                string? name = Console.ReadLine();

                Console.WriteLine("Plese enter your password");
                string? password = Console.ReadLine();

                bool run = true;

                if (user != null)
                {
                    if (user.Name == name && user.Password == password)
                    {
                        PetsFunctionality petsFunctionality = new PetsFunctionality(context);
                        UserFunctionality userFunctionality = new UserFunctionality(context);
                        FeedingSchedulFuntionality feedingSchedulFuntionality = new FeedingSchedulFuntionality(context);
                        PetPurchaseFuntionality petPurchaseFuntionality = new PetPurchaseFuntionality(context);
                        SalesRecordsFuntionality salesRecordsFuntionality = new SalesRecordsFuntionality(context);
                        RepotsFuntionality repotsFuntionality = new RepotsFuntionality(context);

                        Console.WriteLine("\n--------User login successfully--------- \n");

                        while (run)
                        {
                            Console.WriteLine("""
                        ------------This Is Your Pet Shop Inventory Key Funtionality!-------------  

                        Inpute 1: Admin Can Change Password: 
                        Inpute 2: Go To Pet Shop Inventory: 
                        Input 3: Here Feeding Schedule For Pet: 
                        Input 4: Pet Purchases Information Add Shop Owner: 
                        Input 5: Pets Sales Record Add Shop Owner: 
                        Input 6: Logout In Pet Shop Inventory:
                        Input 7: Show Monthly Purchas Ans Sells Reports: 
                        """);
                            int condition = int.Parse(Console.ReadLine());

                            switch (condition)
                            {
                                case 1:
                                    userFunctionality.ChangePassword();
                                    break;

                                case 2:
                                    Console.WriteLine($"---{user.Name} Hello, You Can Operate In This Below Options----");
                                    Console.WriteLine("""
                            Inpute 1: Add Cage And Pets In Store:  
                            Inpute 2: Show All Pets Are Available:
                            Input 3: Update To A Pet:
                            Input 4: Update To A Pet Cage:
                            Input 5: Delete A Pet:
                            Inpute 6: Delete A PetCage:
                            Input 7: Add Only Pet In A Cage: 
                            Input 8: Add A PetCage:
                            Input 9: Delete Pet In A PetCage:
                            """);
                                    int condition2 = int.Parse(Console.ReadLine());
                                    switch (condition2)
                                    {
                                        case 1:
                                            //Add Pet cage and pets...
                                            petsFunctionality.AddCageAndPet();
                                            break;

                                        case 2:
                                            //Show All My Cage Of Pets...
                                            petsFunctionality.ShowCageOfPets();
                                            break;

                                        case 3:
                                            petsFunctionality.UpdatePets();
                                            break;

                                        case 4:
                                            petsFunctionality.UpdateCage();
                                            break;

                                        case 5:
                                            petsFunctionality.DeletePet();
                                            break;

                                        case 6:
                                            petsFunctionality.DeletePetCage();
                                            break;

                                        case 7:
                                            petsFunctionality.AddOnlyPets();
                                            break;

                                        case 8:
                                            petsFunctionality.CreatePetCage();
                                            break;

                                        case 9:
                                            petsFunctionality.DeletePetInCage();
                                            break;

                                        default:
                                            Console.WriteLine("Don't Mach Any Case. Put in Right Case");
                                            break;
                                    }
                                    break;

                                case 3:
                                    Console.WriteLine("-----This is my pet feeding schedul based on the pet cage-----");
                                    Console.WriteLine("""
                                Input 1: Add Feeding Schedule For A Peta Of Cage:
                                Input 2: Show All Feeding Schedules For Pets Of Cage:
                                Input 3: Update Schedule For Pets Of Aage Schedule: 
                                Input 4: Delete Schedule: 
                                """);
                                    int condition3 = int.Parse(Console.ReadLine());
                                    switch (condition3)
                                    {
                                        case 1:
                                            feedingSchedulFuntionality.AddFeedSchedul();
                                            break;

                                        case 2:
                                            feedingSchedulFuntionality.ShowFeeingScheduls();
                                            break;

                                        case 3:
                                            feedingSchedulFuntionality.UpdateFeeingScheduls();
                                            break;

                                        case 4:
                                            feedingSchedulFuntionality.DeleteSchedul();
                                            break;

                                        default:
                                            Console.WriteLine("Don't Mach Any Case. Put in Right Case");
                                            break;
                                    }
                                    break;

                                case 4:
                                    Console.WriteLine("-----Here Shop Owner See Availabe Pet Purchases Funtionality-----");
                                    Console.WriteLine("""
                                Input 1: Add Pet Purchase Inforamtion: 
                                Input 2: Show All Pet Purchase Informations: 
                                Input 3: Add Multiplr Pet Purchase Information: 
                                """);
                                    int condition4 = int.Parse(Console.ReadLine());
                                    switch (condition4)
                                    {
                                        case 1:
                                            petPurchaseFuntionality.AddPetParchaseInfo();
                                            break;

                                        case 2:
                                            petPurchaseFuntionality.ShowAllPurchases();
                                            break;

                                        case 3:
                                            petPurchaseFuntionality.AddPetPurchaseInfo();
                                            break;

                                        default:
                                            Console.WriteLine("Don't Mach Any Case. Put in Right Case");
                                            break;
                                    }
                                    break;

                                case 5:
                                    Console.WriteLine("""
                                Input 1: Add Sales Record: 
                                Input 2: Show All Records: 
                                """);
                                    int condition5 = int.Parse(Console.ReadLine());
                                    switch (condition5)
                                    {
                                        case 1:
                                            salesRecordsFuntionality.AddSalesRecord();
                                            break;

                                        case 2:
                                            salesRecordsFuntionality.ShowALLRecords();
                                            break;

                                        default:
                                            Console.WriteLine("Don't Mach Any Case. Put in Right Case");
                                            break;
                                    }
                                    break;

                                case 6:
                                    Console.WriteLine("\n----------Logout has been succesfully--------\n");
                                    run = false;
                                    break;

                                case 7:
                                    Console.WriteLine("""
                                     Input 1: Show Monthy Purchas Report: 
                                     Input 2: Show Monthly Sales Report: 
                                     Input 3: Show Mothly Sales And Purchase Report And Loss/Profit: 
                                     """);
                                    int condition6 = int.Parse(Console.ReadLine());
                                    switch (condition6)
                                    {
                                        case 1:
                                            repotsFuntionality.ShowMonthlyPurchase();
                                            break;
                                        case 2:
                                            repotsFuntionality.ShowMonthlySales();
                                            break;
                                        case 3:
                                            repotsFuntionality.ProfitAndLoss();
                                            break;
                                        default:
                                            Console.WriteLine("Don't Mach Any Case. Put in Right Case");
                                            break;
                                    }
                                    break;

                                default:
                                    Console.WriteLine("Don't Mach Any Case. Put in Right Case");
                                    break;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n--------user name or password don't match, plese tryagain--------\n");
                        run = false;
                    }
                }
            }
        }
    }
}
