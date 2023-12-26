using Microsoft.EntityFrameworkCore;
using PetShopInventory.PetsPurchaseUtility;
using PetShopInventory.PetsUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopInventory.ShopReports
{
    public class RepotsFuntionality
    {
        private readonly ApplicationDbContext _context;

        public RepotsFuntionality(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public void ShowMonthlyPurchase()
        {
            Console.WriteLine("\n-------This is my monthly Reports of pet shop Inventory--------\n");

            DateTime startDate = new DateTime(2023, 12, 1);
            DateTime endDate = new DateTime(2023, 12, DateTime.DaysInMonth(2023, 12));

            List<PetPurchase> monthlyPurchases = _context.PetPurchases.Where(p => p.PurchaseDate >= startDate && p.PurchaseDate <= endDate).Include(x => x.PurchasedPets).ToList();

            foreach (PetPurchase purchase in monthlyPurchases)
            {
                Console.WriteLine("Hello programmer");
                Console.WriteLine($"Purchase Id: {purchase.Id}");
                Console.WriteLine($"Seller Name: {purchase.SellerName}");
                Console.WriteLine($"Purchase Date: {purchase.PurchaseDate}");

                Console.WriteLine("Purchased Pets:");
                if (purchase.PurchasedPets != null)
                {
                    foreach (Pet pet in purchase.PurchasedPets)
                    {
                        Console.WriteLine($"  - {pet.Name}, {pet.Type}");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
