using Microsoft.EntityFrameworkCore;
using PetShopInventory.PetsUtility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopInventory.PetsCURDoperation
{
    public class PetsFunctionality
    {
        private readonly ApplicationDbContext _context;
        public PetsFunctionality(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public void AddCageAndPet()
        {
            Console.WriteLine("---First Of All You Have To Create A PeT Case Then You Can Add A Pet In The PetCage---");
            Console.WriteLine("Enter Pets Cage Name: ");
            string? petcageName = Console.ReadLine();
            Console.WriteLine("Enter Cage Type: ");
            string? cageType = Console.ReadLine();

            Console.WriteLine("How many pets are add in cage? ");
            int numberOfPet = int.Parse(Console.ReadLine());

            List<Pet> listOfPets = new List<Pet>();
            
            for (int i = 0; i < numberOfPet; i++)
            {
                Pet pet = new Pet();
                Console.WriteLine($"Insert Data For Number Of Item - {i + 1}");
                Console.WriteLine("Enter Pet Name: ");
                pet.Name = Console.ReadLine();
                Console.WriteLine("Enter pet description: ");
                pet.Description = Console.ReadLine();
                Console.WriteLine("Enter pet color: ");
                pet.Color = Console.ReadLine();
                Console.WriteLine("Enter pet type: ");
                pet.Type = Console.ReadLine();
                listOfPets.Add(pet);
            }

            PetCage casePets = new PetCage
            {
                CageName = petcageName,
                CageType = cageType,
                PetsList = listOfPets
            };
            Console.WriteLine($"New Added {listOfPets.Count()} Items In {petcageName}");
           _context.PetCages.Add(casePets);
           _context.SaveChanges();
        }

        public void ShowCageOfPets()
        {
            Console.WriteLine("----------Thouse Cate Are Available In This Pet Shop Inventory---------");
            List<PetCage> petCagesWithPets =_context.PetCages.Include(c => c.PetsList).ToList();
            foreach (PetCage cage in petCagesWithPets)
            {
                Console.WriteLine($"---------This Pets Cage Are The '{cage.CageName}' Here Are Available Cats Are These' ---------");
                Console.WriteLine($"Cage Id: {cage.ID} Cage Name: {cage.CageName} Cage Type: {cage.CageType}");
                foreach (Pet pet in cage.PetsList)
                {
                    Console.WriteLine($"Pet Id: {pet.Id} Nama: {pet.Name} Description: {pet.Description} Color: {pet.Color} Type: {pet.Type}");
                }
                Console.WriteLine();
            }
        }

        public void UpdatePets()
        {
            Console.WriteLine("Enter Pet Id For To Update Pet: ");
            int petId = int.Parse(Console.ReadLine()); 
            Console.WriteLine("Enter pet new name: ");
            string newName = Console.ReadLine();
            Console.WriteLine("Enter pet description: ");
            string newDescription = Console.ReadLine();
            Console.WriteLine("Enter pet color: ");
            string petColor = Console.ReadLine();
            Console.WriteLine("Enter pet type");
            string petType = Console.ReadLine();

            Pet? pet =_context.Pets.Where(x => x.Id == petId).FirstOrDefault();
            if (pet != null)
            {
                pet.Name = newName;
                pet.Description = newDescription;
                pet.Color = petColor;
                pet.Type = petType;
            }
           _context.SaveChanges();
        }

        public void UpdateCage()
        {
            Console.WriteLine("Enter PetCage Id For To Update Cage: ");
            int cageId = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter New PetCage Name: ");
            string newCageName = Console.ReadLine();
            Console.WriteLine("Enter New PetCage type");
            string newCageType = Console.ReadLine();

            PetCage? cage =_context.PetCages.Where(x => x.ID == cageId).FirstOrDefault();
            if (cage != null)
            {
                cage.CageName = newCageName;
                cage.CageType = newCageType;
            }
           _context.SaveChanges();
        }

        public void DeletePet()
        {   
            Console.WriteLine("Enter The Pet Id Which Will Be Delete: ");
            int id = int.Parse(Console.ReadLine());

            Pet? pet = _context.Pets.Where(x => x.Id == id).FirstOrDefault();
            if (pet != null)
            {
                _context.Remove(pet);
            }
            _context.SaveChanges();
        }

        public void DeletePetCage()
        {
            Console.WriteLine("Enter The PetCage Id Which Will Be Delete: ");
            int id = int.Parse(Console.ReadLine());

            PetCage? petCage = _context.PetCages.Where(x => x.ID == id).FirstOrDefault();
            if(petCage != null)
            {
                _context.Remove(petCage);
            }
            _context.SaveChanges();
        }

        public void AddOnlyPets()
        {
            Console.WriteLine("------Here are available pets cage-------");
            foreach (PetCage item in _context.PetCages)
            {
                Console.WriteLine($"id: {item.ID} Cage Name: {item.CageName}");
            }
        
            if (_context.PetCages.Count() <= 0)
            {
                Console.WriteLine("--Your does not have exist any pet cage please first of all create a cage then add pet---");
                Console.WriteLine($"Pet Cage Count: {_context.PetCages.Count()}");
            }
            else
            {
                Console.WriteLine("\nWhich Cage Do you add these pets? ");
                Console.WriteLine("Enter Cage Id: ");
                int petCageId = int.Parse(Console.ReadLine());

                Console.WriteLine("How many pets are add in this cage? ");
                int numberOfPet = int.Parse(Console.ReadLine());

                List<Pet> listOfPets = new List<Pet>();

                for (int i = 0; i < numberOfPet; i++)
                {
                    Pet pet = new Pet();
                    Console.WriteLine($"Insert Data For Number Of Item - {i + 1}");
                    Console.WriteLine("Enter Pet Name: ");
                    pet.Name = Console.ReadLine();
                    Console.WriteLine("Enter pet description: ");
                    pet.Description = Console.ReadLine();
                    Console.WriteLine("Enter pet color: ");
                    pet.Color = Console.ReadLine();
                    Console.WriteLine("Enter pet type: ");
                    pet.Type = Console.ReadLine();
                    pet.CageId = petCageId;
                    listOfPets.Add(pet);
                }
                PetCage? petsCage = _context.PetCages.Where(x => x.ID == petCageId).FirstOrDefault();
                if (petsCage != null)
                {
                    petsCage.PetsList = petsCage.PetsList ?? new List<Pet>();
                    petsCage.PetsList.AddRange(listOfPets);
                }
                _context.SaveChanges();
            }
        }

        public void CreatePetCage()
        {
            Console.WriteLine("----Create Your Pet Cage----");
            Console.WriteLine("Enter yor pet cage name: ");
            string? cageName = Console.ReadLine();
            Console.WriteLine("Enter your pet cage type: ");
            string? petCageType = Console.ReadLine();

            PetCage petCage = new PetCage();
            petCage.CageName = cageName;
            petCage.CageType = petCageType;
            _context.PetCages.Add(petCage);
            _context.SaveChanges();
        }
    }
}
