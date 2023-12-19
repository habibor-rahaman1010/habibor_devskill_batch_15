using Microsoft.EntityFrameworkCore;
using PetShopInventory.PetsUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopInventory.FeedingScheduleUtitlity
{
    public class FeedingSchedulFuntionality
    {
        private readonly ApplicationDbContext _context;

        public FeedingSchedulFuntionality(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddFeedSchedul()
        {
            if (_context.PetCages.Count() <= 0)
            {
                Console.WriteLine("""
                    !!You can not create for pet cage feeding schedule because you have not any pet cage. 
                    First of all create a pet cage then cate feeding schedule for there!! 
                    You want to create pet cage "Go To Pet Shop Inventory"
                    """);
            }
            else
            {
                /*Console.WriteLine("Enter Time For Schedul: (format: yyyy-MM-dd HH:mm:ss): ");
                string? dateTime = Console.ReadLine();*/
                Console.WriteLine("Enter Fedding Instruction For Pets Of Cage: ");
                string? instruction = Console.ReadLine();
                Console.WriteLine("\n------Here are available pets cage Id choose From Here-------");
                foreach (PetCage item in _context.PetCages)
                {
                    Console.WriteLine($"id: {item.ID} Cage Name: {item.CageName}");
                }
                Console.WriteLine("\nEnter PetCage Id: ");
                int petcageId = int.Parse(Console.ReadLine());
                
                FeedingSchedule feedingSchedule = new FeedingSchedule();
                feedingSchedule.FeedingTime = DateTime.Now;
                feedingSchedule.SpecialInstructions = instruction;
                feedingSchedule.CageId = petcageId;
                
                _context.FeedingSchedules.Add(feedingSchedule);
                _context.SaveChanges();
            }
        }

        public void ShowFeeingScheduls()
        {
            Console.WriteLine("\n-----Here are my feeding schedule list for my pets of cages------\n");

            List<FeedingSchedule> schedules = _context.FeedingSchedules.ToList();

            foreach(FeedingSchedule schedule in schedules)
            {
                Console.WriteLine($"{schedule.FeedingTime} Pet Cage Id: {schedule.CageId}");
                PetCage? petCage = _context.PetCages.Include(pc => pc.PetsList).Where(x=> x.ID == schedule.CageId).FirstOrDefault();

                if (petCage != null && petCage.PetsList != null)
                {
                    foreach(Pet pet in petCage.PetsList)
                    {
                        Console.WriteLine($"Pet Id: {pet.Id} Pet Name: {pet.Name} {pet.Color} Pet Cage Name: {pet.Cage.CageName}");
                    }
                }
                Console.WriteLine("\n");
            }
        }

        public void UpdateFeeingScheduls()
        {
            Console.WriteLine("\n-----Here your feeding schedule list ------\n");
           
            List<FeedingSchedule> schedules = _context.FeedingSchedules.ToList();
            foreach (FeedingSchedule schedule in schedules)
            {
                Console.WriteLine($"{schedule.FeedingTime} Schedul Id: {schedule.Id}");
            }
            Console.WriteLine("\nWhich one do you update? Enter schedul Id from top of the list: \n");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Spechial Instruction for feeding: ");
            string? instrution = Console.ReadLine();

            FeedingSchedule? feedingSchedule = schedules.Where(x => x.Id == id).FirstOrDefault();
            if (feedingSchedule != null)
            {
                feedingSchedule.FeedingTime = DateTime.Now;
                feedingSchedule.SpecialInstructions = instrution;
            }
            _context.SaveChanges();
        }

        public void DeleteSchedul()
        {
            Console.WriteLine("\n-----Here your feeding schedule list ------\n");

            List<FeedingSchedule> schedules = _context.FeedingSchedules.ToList();
            foreach (FeedingSchedule schedule in schedules)
            {
                Console.WriteLine($"{schedule.FeedingTime} Schedul Id: {schedule.Id}");
            }
            Console.WriteLine("\nWhich one do you Delete? Enter schedul Id from top the lsit: \n");
            int id = int.Parse(Console.ReadLine());

            FeedingSchedule? feedingSchedule = schedules.Where(x => x.Id == id).FirstOrDefault();
            if (feedingSchedule != null)
            {
                _context.FeedingSchedules.Remove(feedingSchedule);
            }
            _context.SaveChanges();
        }
    }
}
