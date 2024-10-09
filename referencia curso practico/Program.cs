using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace referencia_curso_practico
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Cliente cliente = new Cliente();

            RegistroClientes.RegistrarCliente(cliente);
            Console.WriteLine("\nInformación del cliente registrado:");
            RegistroClientes.MostrarCliente(cliente);

            Console.ReadKey();
        }
    }

    // Clase Cliente que contiene las propiedades del cliente
    class Cliente
    {
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Nacionalidad { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string HoraRegistro { get; set; }
    }

    // Clase que maneja el registro de clientes
    class RegistroClientes
    {
        static string[] paises = { "Republica Dominicana", "Peru", "Panama", "USA", "España", "Japon" };

        public static void RegistrarCliente(Cliente cliente)
        {
            Console.Write("Ingrese su nombre: ");
            cliente.Nombre = Console.ReadLine();

            cliente.Edad = IngresarEdad();

            cliente.FechaNacimiento = IngresarFechaNacimiento();

            cliente.Nacionalidad = SeleccionarPais();

            cliente.HoraRegistro = DateTime.Now.ToString("HH:mm:ss");
        }

        static int IngresarEdad()
        {
            int edad;
            while (true)
            {
                Console.Write("Ingrese su edad: ");
                string entrada = Console.ReadLine();
                if (int.TryParse(entrada, out edad) && edad > 0)
                {
                    return edad;
                }
                Console.WriteLine("Edad inválida. Inténtelo de nuevo.");
            }
        }

        static DateTime IngresarFechaNacimiento()
        {
            DateTime fechaNacimiento;
            while (true)
            {
                Console.Write("Ingrese su fecha de nacimiento (yyyy-mm-dd): ");
                string entrada = Console.ReadLine();
                if (DateTime.TryParse(entrada, out fechaNacimiento))
                {
                    return fechaNacimiento;
                }
                Console.WriteLine("Fecha inválida. Inténtelo de nuevo.");
            }
        }

        // Método para seleccionar país de la lista
        static string SeleccionarPais()
        {
            Console.WriteLine("Seleccione su nacionalidad:");
            for (int i = 0; i < paises.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {paises[i]}");
            }

            int seleccion;
            while (true)
            {
                Console.Write("Ingrese el número correspondiente a su país: ");
                string entrada = Console.ReadLine();
                if (int.TryParse(entrada, out seleccion) && seleccion > 0 && seleccion <= paises.Length)
                {
                    return paises[seleccion - 1];
                }
                Console.WriteLine("Selección inválida. Inténtelo de nuevo.");
            }
        }

        // Método para mostrar la información del cliente
        public static void MostrarCliente(Cliente cliente)
        {
            Console.WriteLine($"Nombre: {cliente.Nombre}");
            Console.WriteLine($"Edad: {cliente.Edad}");
            Console.WriteLine($"Fecha de Nacimiento: {cliente.FechaNacimiento.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"Nacionalidad: {cliente.Nacionalidad}");
            Console.WriteLine($"Hora de Registro: {cliente.HoraRegistro}");
        }
    }
}