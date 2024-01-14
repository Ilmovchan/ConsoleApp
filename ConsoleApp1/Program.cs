namespace ConsoleApp1
{

    class Program
    {

        static void Main()
        {
            Student student = new Student("Biba", "Johnson");

            Console.WriteLine(student.GetFullName());
        }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Student(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }


    static class MyExtensions
    {
        public static string GetFullName(this Student student)
        {
            return student.LastName + " " + student.FirstName;
        }
    }

}