using Microsoft.EntityFrameworkCore;
using PetShopInventory.PetsUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopInventory.SalesRecords
{
    public class SalesRecordsFuntionality
    {
        private readonly ApplicationDbContext _context;

        public SalesRecordsFuntionality(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public void AddSalesRecord()
        {
            Console.WriteLine("\n--------Those Pets Are Available In This Pet Shop Inventory. Which Ones Do You Want to sale?--------\n");
            List<Pet> pets = _context.Pets.ToList();
            foreach (Pet pet in pets)
            {
                Console.WriteLine($"Id: {pet.Id} Name: {pet.Name} PetType: {pet.Type}");
            }

            Console.WriteLine("Select pet id top of the list: ");
            int id = int.Parse(Console.ReadLine());

            Pet selctPet = _context.Pets.Where(x => x.Id == id).FirstOrDefault();
            if (selctPet != null)
            {
                Console.WriteLine("Enter Buyer Name: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Buyer Contact: ");
                string contact = Console.ReadLine();
                Console.WriteLine("Enter Pet Type: ");
                string petType = Console.ReadLine();

                PetSalesRecord record = new PetSalesRecord();
                record.BuyerName = name;
                record.BuyerContact = contact;
                record.TypeOfPet = petType;
                record.SalesDate = DateTime.Now;
                record.SoldPets = record.SoldPets ?? new List<Pet>();
                record.SoldPets.Add(selctPet);
                _context.PetSalesRecords.Add(record);
                _context.SaveChanges();
            }
        }

        public void ShowALLRecords()
        {
            Console.WriteLine("--------Here are my sales record of pet shop inventory--------\n");
            List<PetSalesRecord> records = _context.PetSalesRecords.Include(x => x.SoldPets).ToList();
            foreach (PetSalesRecord record in records)
            {
                if (record.SoldPets != null)
                {
                    foreach (Pet item in record.SoldPets)
                    {
                        Console.WriteLine(item.PetPrice);
                    }
                }
                else
                {
                    Console.WriteLine("Not exist pat");
                }
                Console.WriteLine($"Id: {record.Id} Buyer Nmae: {record.BuyerName} PetType: {record.TypeOfPet} Date: {record.SalesDate}");
            }
            Console.WriteLine("\n");
        }
    }
}
