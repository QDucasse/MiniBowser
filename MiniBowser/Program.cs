using System;
namespace MiniBowser
{
    class Program
    {
        public static void Main(string[] args)
        {
            MiniBowser mb = new MiniBowser();
            mb.Store();
            Console.WriteLine(Serializer.pathHistory);
        }
    }
    
}
