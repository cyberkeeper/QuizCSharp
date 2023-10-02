namespace Quiz
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Quiz!");

            Player p1 = new Player("alan", "hart");
            p1.SetDateOfBirth("2001-03-22");
            Console.WriteLine(p1.DateOfBirth);
            Console.WriteLine(p1.GetAge());
            p1.SetDateOfBirth("2001,03,22");
        }
    }
}