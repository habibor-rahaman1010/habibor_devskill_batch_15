// See https://aka.ms/new-console-template for more information

using Task2;

Student student = new Student
{
    Name = "John Doe",
    DateOfBirth = new DateTime(2000, 5, 15),
};

Teacher teacher = new Teacher
{
    Name = "Jane Smith",
    DateOfBirth = new DateTime(1985, 8, 25),
};

Console.WriteLine(teacher.GenerateId());
Console.WriteLine(student.GenerateId());
