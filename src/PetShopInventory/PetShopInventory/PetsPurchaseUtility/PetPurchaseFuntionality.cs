using Microsoft.EntityFrameworkCore;
using PetShopInventory.PetsUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopInventory.PetsPurchaseUtility
{
    public class PetPurchaseFuntionality
    {
        private readonly ApplicationDbContext _context;

        public PetPurchaseFuntionality(ApplicationDbContext _context)
        {
            this._context = _context;
        }

        public void AddPetParchaseInfo()
        {
            Console.WriteLine("\n--------Thouse Pets Are Available In This Pet Shop Inventory Which One Do Yor Purchase--------\n");
            List<PetCage> petCagesWithPets = _context.PetCages.Include(c => c.PetsList).ToList();
            foreach (PetCage cage in petCagesWithPets)
            {
                Console.WriteLine($"---------This Pets Cage Are The '{cage.CageName}' Here Are Available Cats Are These' ---------");
                Console.WriteLine($"Cage Id: {cage.ID} Cage Name: {cage.CageName} Cage Type: {cage.CageType}");
                foreach (Pet pet in cage.PetsList)
                {
                    Console.WriteLine($"Pet Id: {pet.Id} Nama: {pet.Name} Description: {pet.Description} Color: {pet.Color} Price: {pet.PetPrice} Type: {pet.Type}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nEnter Your CageId Top Of The List: ");
            int cageId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Your Pet Id Top Of The List In Selacted Cage: ");
            int petId = int.Parse(Console.ReadLine());

            PetCage? petCage = _context.PetCages.FirstOrDefault(x => x.ID == cageId);

            if (petCage != null)
            {
                Pet? pet = _context.Pets.FirstOrDefault(p => p.Id == petId && p.CageId == cageId);

                if (pet != null)
                {
                    Console.WriteLine("Enter Saller Name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter her Email: ");
                    string email = Console.ReadLine();
                    Console.WriteLine("Enter her Conatact Number: ");
                    string conatct = Console.ReadLine();

                    PetPurchase purchase = new PetPurchase();
                    purchase.SellerName = name;
                    purchase.Email = email;
                    purchase.SellerContact = conatct;
                    purchase.PurchaseDate = DateTime.Now;
                    purchase.PurchasedPets = purchase.PurchasedPets ?? new List<Pet>();
                    purchase.PurchasedPets.Add(pet);

                    _context.PetPurchases.Add(purchase);
                    _context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Pet not found in the specified cage.");
                }
            }
            else
            {
                Console.WriteLine("Cage not found.");
            }
        }



        public void AddPetPurchaseInfo()
        {
            Console.WriteLine("\n--------Those Pets Are Available In This Pet Shop Inventory. Which Ones Do You Want to Purchase?--------\n");

            List<PetCage> petCagesWithPets = _context.PetCages.Include(c => c.PetsList).ToList();

            foreach (PetCage cage in petCagesWithPets)
            {
                Console.WriteLine($"---------Pets in Cage '{cage.CageName}' ---------");
                Console.WriteLine($"Cage Id: {cage.ID} Cage Name: {cage.CageName} Cage Type: {cage.CageType}");

                foreach (Pet pet in cage.PetsList)
                {
                    Console.WriteLine($"Pet Id: {pet.Id} Name: {pet.Name} Description: {pet.Description} Color: {pet.Color} Price: {pet.PetPrice} Type: {pet.Type}");
                }

                Console.WriteLine();
            }

            Console.WriteLine("\nEnter Your CageId Top Of The List: ");
            int cageId = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Multiple Pet Id's (comma separated): Select Top Of The list In Selacted Cage: ");
            string petIdsInput = Console.ReadLine();

            int[] petIds = petIdsInput.Split(',').Select(int.Parse).ToArray();

            PetCage petCage = _context.PetCages.Include(c => c.PetsList).FirstOrDefault(x => x.ID == cageId);

            if (petCage != null)
            {
                List<Pet> selectedPets = _context.Pets.Where(p => petIds.Contains(p.Id) && p.CageId == cageId).ToList();

                if (selectedPets.Any())
                {
                    Console.WriteLine("Enter Saller Name:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter her Email:");
                    string email = Console.ReadLine();
                    Console.WriteLine("Enter her Contact Number:");
                    string contact = Console.ReadLine();

                    PetPurchase purchase = new PetPurchase
                    {
                        SellerName = name,
                        Email = email,
                        SellerContact = contact,
                        PurchaseDate = DateTime.Now,
                        PurchasedPets = selectedPets
                    };

                    _context.PetPurchases.Add(purchase);
                    _context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("No valid pets found with the specified Id's in the cage.");
                }
            }
            else
            {
                Console.WriteLine("Cage not found.");
            }
        }




        public void ShowAllPurchases()
        {
            Console.WriteLine("--------Here Are My ALl Purchases List Inforamtion--------");

            List<PetPurchase> petPurchaseWoner = _context.PetPurchases.Include(x => x.PurchasedPets).ToList();

            foreach (PetPurchase item in petPurchaseWoner)
            {
                Console.WriteLine($"Id {item.Id} | Name:{item.SellerName} | Purchase Date: {item.PurchaseDate}");

                if (item.PurchasedPets != null)
                {
                    foreach (Pet pet in item.PurchasedPets)
                    {
                        Console.WriteLine($"PetID: {pet.Id} Name: {pet.Name} Price: {pet.PetPrice} Type: {pet.Type} CageID: {pet.CageId}");
                    }
                }
                Console.WriteLine("\n");
            }
        }
    }
}
