using Microsoft.EntityFrameworkCore;
using PetShopInventory.PetsPurchaseUtility;
using PetShopInventory.PetsUtility;
using PetShopInventory.SalesRecords;
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

        public decimal ShowMonthlyPurchase()
        {
            Console.WriteLine("\n-------This is my monthly Purchaes Reports of pet shop Inventory--------\n");

            DateTime startDate = new DateTime(2023, 12, 1);
            DateTime endDate = new DateTime(2023, 12, DateTime.DaysInMonth(2023, 12));

            List<PetPurchase> monthlyPurchases = _context.PetPurchases.Where(p => p.PurchaseDate >= startDate && p.PurchaseDate <= endDate).Include(x => x.PurchasedPets).ToList();
            decimal totalPurchaseAmount = default(decimal);
            foreach (PetPurchase purchase in monthlyPurchases)
            {
                Console.WriteLine($"Purchase Id: {purchase.Id}");
                Console.WriteLine($"Seller Name: {purchase.SellerName}");
                Console.WriteLine($"Purchase Date: {purchase.PurchaseDate}");

                Console.WriteLine("Purchased Pets:");
                if (purchase.PurchasedPets != null)
                {   
                    foreach (Pet pet in purchase.PurchasedPets)
                    {
                        Console.WriteLine($"date: {purchase.PurchaseDate} price: {pet.PetPrice}, PetType: {pet.Type}");
                    }
                    totalPurchaseAmount += purchase.PurchasedPets.Sum(x => x.PetPrice);
                    Console.WriteLine();
                }
            }
            Console.WriteLine($"TotalPurchaseAmount: {totalPurchaseAmount}");
            return totalPurchaseAmount;
        }

        public decimal ShowMonthlySales()
        {
            Console.WriteLine("\n-------This is my monthly Sales Reports of pet shop Inventory--------\n");

            DateTime startDate = new DateTime(2023, 12, 1);
            DateTime endDate = new DateTime(2023, 12, DateTime.DaysInMonth(2023, 12));

            List<PetSalesRecord> monthlySales = _context.PetSalesRecords.Where(p => p.SalesDate >= startDate && p.SalesDate <= endDate).Include(x => x.SoldPets).ToList();
            decimal totalSalesAmount = default(decimal);
            foreach (PetSalesRecord sales in monthlySales)
            {
                Console.WriteLine($"Sale Id: {sales.Id}");
                Console.WriteLine($"Buyer Name: {sales.BuyerName}");
                Console.WriteLine($"Sales Date: {sales.SalesDate}");

                Console.WriteLine("Purchased Pets:");
                if (sales.SoldPets != null)
                {
                    foreach (Pet pet in sales.SoldPets)
                    {
                        Console.WriteLine($"date: {sales.SalesDate} price: {pet.PetPrice}, PetType: {pet.Type}");
                    }
                    totalSalesAmount += sales.SoldPets.Sum(x => x.PetPrice);

                    Console.WriteLine();
                }
            }
            Console.WriteLine($"TotalSalesAmount: {totalSalesAmount}");
            return totalSalesAmount;
        }

        public void ProfitAndLoss()
        {
            decimal purcase =  ShowMonthlyPurchase();
            decimal sale = ShowMonthlySales();
            Console.WriteLine("\n---------Pet Shop Inventory Profit And Loss Result Here--------\n");
            if (sale > purcase)
            {
                Console.WriteLine($"Total Profit: {sale - purcase}");
            }
            else{
                Console.WriteLine($"Total Loss: {purcase - sale}");
            }
            Console.WriteLine("\n");
        }
    }
}
