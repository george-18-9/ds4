using System;

namespace Laboratorio2
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            //Ejemplo utilizando la variable de instancia de clase
            client.Firstname = "george";
            client.Lastname = "Worrell";
            client.Age = 19;
            client.Id = 1;

            Console.WriteLine(client.GetFullName());
        }
    }


    public class Client
    {
        //Declarando variables de intancia en clase
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public ushort Age { get; set; }

        public string GetFullName()
        {
            //utilizando variables de instancia dentro de metodos de la clase.
            return Firstname + " " + Lastname;
        }

    }

}