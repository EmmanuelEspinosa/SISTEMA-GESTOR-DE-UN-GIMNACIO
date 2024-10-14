using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace SISTEMA_GESTOR_DE_GIMNACIO
{
    internal class Program
    {
        //VARIABLES
        static void Main(string[] args)
        {
            ClientesStruct[] clientes = new ClientesStruct[0];
            int caso = 0;
            do
            {
                Console.WriteLine("::BIENVENIDO AL SISTEMA GESTOR DEL GIMNACIO IDRA:: \n :::OPRIME EL NUMERO DE LA OPCION DESEADA::: \n 1)Agregar Cliente\n 2)Modificar Cliente\n 3)Eliminar Cliente\n 4)Listar Clientes\n 5)Buscar Clientes\n 6)Manejo De Matrices\n 7)Listas Dinamicas\n 0)Salir del programa.  ");
                caso = int.Parse(Console.ReadLine());
                switch (caso)
                {
                    case 1:
                        //1)AGREGAR CLIENTES

                        clientes = AñadirClientes(clientes);
                        Console.WriteLine("Lista de clientes agregados:");
                        foreach (var cliente in clientes)
                        {
                            Console.WriteLine($"{cliente}");
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        //2)MODIFICAR CLIENTE
                        ModificarClientes(clientes);
                        Console.WriteLine("Lista actualizada:");
                        foreach (var cliente in clientes)
                        {
                            Console.WriteLine($"{cliente}");
                        }
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 0:
                        break;
                    default:
                        break;
                }
            } while (caso != 0);
            Console.ReadKey();
        }
        //FUNCIONES
        //VER CLIENTES


        ///crear el struct va afuera del main y el public es necesario para dsp poder usarlo/
        public struct ClientesStruct
        {
            public string nombreCliente;
            public string apellidoCliente;
            public int dniCliente;
            public string mailCliente;
            public long telefonoCliente;
            public bool estadoCliente;

            ///crear el constructor/
            public ClientesStruct(string nombre, string apellido, int dni, string mail, long telefono, bool estado)
            {
                nombreCliente = nombre;
                apellidoCliente = apellido;
                dniCliente = dni;
                mailCliente = mail;
                telefonoCliente = telefono;
                estadoCliente = estado;
            }
        //Esta funcion sobreescribe los datos en la funcion modificar clientes
        public void ModificarDatos(string nombreNuevo, string apellidoNuevo, string mailNuevo,int dniNuevo, long telefonoNuevo, bool estadoNuevo)
        {
            nombreCliente = nombreNuevo;
            apellidoCliente = apellidoNuevo;
            dniCliente = dniNuevo;
            mailCliente = mailNuevo;
            telefonoCliente = telefonoNuevo;
            estadoCliente = estadoNuevo;
        }
           //Esta funcion sobreescribe el metodo Tostring para asi mostrar los datos del cliente cuando se nesecite
            public override string ToString()
            {
                return $"Nombre: {nombreCliente}, Apellido: {apellidoCliente}, DNI: {dniCliente}, Email: {mailCliente}, Teléfono: {telefonoCliente}, Estado: {(estadoCliente ? "true" : "false")}";
            }

        }
        //funcion agregar
        static ClientesStruct[] AñadirClientes(ClientesStruct[] array)
        {
            Console.WriteLine(" Cuantos clientes quiere añadir");
            int cantidadClientes = int.Parse(Console.ReadLine());

            ClientesStruct[] nuevoArray = new ClientesStruct[array.Length + cantidadClientes];
            int contador = 0;
            for (int j = 0; j < array.Length; j++)
            {
                if (array.Length > 0)
                {
                    nuevoArray[contador] = array[j];
                    contador++;
                }
            }
            for (int i = contador; i < nuevoArray.Length; i++)
            {
                if (i >= array.Length || array.Length == 0)
                {
                    Console.WriteLine($"Ingrese los datos del cliente {i + 1}:");

                    Console.Write("Nombre: ");
                    string nombre = Console.ReadLine();

                    Console.Write("Apellido: ");
                    string apellido = Console.ReadLine();

                    Console.Write("DNI: ");
                   
                    //USAMOS EL TRYPARSE PARA VERIFICAR QUE EL DATO INGRESADO SEA VALIDO Y NO ROMPA EL PROGRAMA
                    int dni;
                    while (!int.TryParse(Console.ReadLine(), out dni))
                    {
                        Console.WriteLine("DNI inválido. Inténtelo de nuevo.");
                    }

                    Console.Write("Email: ");
                    string mail = Console.ReadLine();

                    Console.Write("Teléfono: ");

                    //USAMOS EL TRYPARSE PARA VERIFICAR QUE EL DATO INGRESADO SEA VALIDO Y NO ROMPA EL PROGRAMA
                    long telefono;
                    while (!long.TryParse(Console.ReadLine(), out telefono))
                    {
                        Console.WriteLine("Teléfono inválido. Inténtelo de nuevo.");
                    }

                    //USAMOS EL TRYPARSE PARA VERIFICAR QUE EL DATO INGRESADO SEA VALIDO Y NO ROMPA EL PROGRAMA
                    Console.Write("Estado (true/false): ");
                    bool estado;
                    while (!bool.TryParse(Console.ReadLine(), out estado))
                    {
                        Console.WriteLine("Estado inválido. Debe ser true o false.");
                    }

                    nuevoArray[i] = new ClientesStruct(nombre, apellido, dni, mail, telefono, estado);

                    Console.WriteLine();
                }
            }
            return nuevoArray;
        }
     
        static int BuscarCliente(ClientesStruct[] array , int dni)
        {
            for(int i = 0;i< array.Length; i++)
            {
                if (array[i].dniCliente == dni)
                {
                    return i;
                }
            }
            return -1;
        }
            
        static void ModificarClientes (ClientesStruct[] array)
        {
            char opcionClienteEncontrado = ' ';
            int indice;
            int dniBuscado;
            do
            {
                Console.WriteLine("ingrese el DNI del cliente que quiere modificar");
               
                while (!int.TryParse(Console.ReadLine(), out dniBuscado))
                {
                    Console.WriteLine("Ingreso invalido, por favor ingresar un DNI");
                }
                indice = BuscarCliente(array, dniBuscado);
                if (indice == -1)
                {
                    Console.WriteLine("Cliente no encontrado");
                    return;
                }
                Console.WriteLine($"Cliente Encontrado:{array[indice]}\n¿Este es el cliente que quiere modificar? ");
                Console.WriteLine("¡Ingrese 'S' para continuar o 'N' para buscar otro cliente!");
                opcionClienteEncontrado=char.Parse(Console.ReadLine());
            } while (opcionClienteEncontrado != 'S');
           
            Console.WriteLine($"Ingrese los datos nuevos del cliente: {array[indice]}:");

            Console.Write("Nombre: ");
            string nombreNuevo = Console.ReadLine();

            Console.Write("Apellido: ");
            string apellidoNuevo = Console.ReadLine();

            Console.Write("DNI: ");

            //USAMOS EL TRYPARSE PARA VERIFICAR QUE EL DATO INGRESADO SEA VALIDO Y NO ROMPA EL PROGRAMA
            int dniNuevo;
            while (!int.TryParse(Console.ReadLine(), out dniNuevo))
            {
                Console.WriteLine("DNI inválido. Inténtelo de nuevo.");
            }

            Console.Write("Email: ");
            string mailNuevo = Console.ReadLine();

            Console.Write("Teléfono: ");

            //USAMOS EL TRYPARSE PARA VERIFICAR QUE EL DATO INGRESADO SEA VALIDO Y NO ROMPA EL PROGRAMA
            long telefonoNuevo;
            while (!long.TryParse(Console.ReadLine(), out telefonoNuevo))
            {
                Console.WriteLine("Teléfono inválido. Inténtelo de nuevo.");
            }

            //USAMOS EL TRYPARSE PARA VERIFICAR QUE EL DATO INGRESADO SEA VALIDO Y NO ROMPA EL PROGRAMA
            Console.Write("Estado (true/false): ");
            bool estadoNuevo;
            while (!bool.TryParse(Console.ReadLine(), out estadoNuevo))
            {
                Console.WriteLine("Estado inválido. Debe ser true o false.");
            }

            array[indice].ModificarDatos(nombreNuevo, apellidoNuevo, mailNuevo, dniNuevo, telefonoNuevo, estadoNuevo);

            Console.WriteLine("Cliente modificado exitosamente");

        }
    }
}
