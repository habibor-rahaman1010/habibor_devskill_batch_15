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
            DateTime startDate = new DateTime(2023, 12, 1);
            DateTime endDate = new DateTime(2023, 1, 31);

            var monthlyPurchases = _context.PetPurchases
                .Where(p => p.PurchaseDate >= startDate && p.PurchaseDate <= endDate)
                .ToList();

            foreach (var purchase in monthlyPurchases)
            {
                Console.WriteLine($"Purchase Id: {purchase.Id}");
                Console.WriteLine($"Seller Name: {purchase.SellerName}");
                Console.WriteLine($"Purchase Date: {purchase.PurchaseDate}");

                Console.WriteLine("Purchased Pets:");
                foreach (var pet in purchase.PurchasedPets)
                {
                    Console.WriteLine($"  - {pet.Name}, {pet.Type}");
                }

                Console.WriteLine();
            }
        }
    }
}
