using FakerLibrary;
using System;

namespace FakerTest
{
    class ConsoleTest
    {
        static void Main(string[] args)
        {
            Faker faker = new Faker();

            //int number = faker.Create<int>();
            //string line = faker.Create<string>();
            //DateTime dateTime = faker.Create<DateTime>();

            //Console.WriteLine(number + "\n\n" + line + "\n\n" + dateTime + "\n");

            //byte[] array = faker.Create<byte[]>();
            //for (int i = 0; i < array.Length; i++)
            //{
            //    Console.Write(array[i] + " ");
            //}

            Foo foo = faker.Create<Foo>();

            Console.WriteLine(foo.ToString());

            Console.ReadKey();
        }
    }
}
