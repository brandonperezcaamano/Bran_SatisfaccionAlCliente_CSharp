using Bran_SatisfaccionAlCliente_CSharp;
using System.Reflection.PortableExecutable;
using static Bran_SatisfaccionAlCliente_CSharp.servicio;
using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static void Main(string[] args)
    {
        //aqui decidi poner mis ejecuciones en el main, tomando en cuenta sus observaciones
        Console.WriteLine("Bienvenido a la encuesta de satisfacción al cliente.");

        string nombre = pedirnombre();
        int edad = PedirEdad();


        if (edad < 18)
        {
            Console.WriteLine("Lo siento, debes ser mayor de edad para participar en la encuesta.");
            LimpiarPantalla();
            return;
        }

        servicios servicioSeleccionado = PedirServicio();
        double promedio = CalificarServicio();

        Console.WriteLine("¿Algún comentario para ayudarnos a mejorar?");
        string comentario = Console.ReadLine();


        Encuesta encuesta = new Encuesta
        {
            Nombre = nombre,
            Edad = edad,
            Servicio = servicioSeleccionado,
            Promedio = promedio,
            Comentario = comentario
        };

        // Resumen
        Console.WriteLine("\nResumen de la encuesta:");
        Console.WriteLine($"Nombre: {encuesta.Nombre}");
        Console.WriteLine($"Edad: {encuesta.Edad}");
        Console.WriteLine($"Servicio utilizado: {encuesta.Servicio}");
        Console.WriteLine($"Promedio: {encuesta.Promedio}");
        Console.WriteLine($"Comentario: {encuesta.Comentario}");

        LimpiarPantalla();
    }
    //Aqui sustitui los if y else por ciclos while para validar las entradas
    //tambien estudiando un poco el recurso que me envio sobre las excepciones lo puse en practica.
    static string pedirnombre()
    {
        string nombre;
        do
        {
            Console.Write("Ingrese su nombre: ");
            nombre = Console.ReadLine();

            try
            {
                //aqui he tenido que investigar un poco mas sobre las excepciones y encontre que ArgumentException es la mas adecuada para este caso
                string.IsNullOrWhiteSpace(nombre);
            }
            catch (ArgumentException empty)
            {
                Console.WriteLine("El nombre no puede estar vacío. Por favor, ingrese un nombre válido.");
            }

        }
        while (string.IsNullOrWhiteSpace(nombre));

        return nombre;
    }

    static int PedirEdad()
    {
        int edad;
        Console.Write("Ingrese su edad: ");
        while (!int.TryParse(Console.ReadLine(), out edad) || edad <= 0 || edad >= 120)
        {
            Console.Write("Edad no válida. Intente nuevamente: ");
        }
        return edad;
    }

    private static servicios PedirServicio()
    {
        Console.WriteLine("¿Qué servicio utilizó?");
        Console.WriteLine("1. Compras en Línea");
        Console.WriteLine("2. Atención al cliente");
        Console.WriteLine("3. Entrega a domicilio");

        //esto es para validar que la opcion sea correcta y el usuario no ingrese letras o caracteres especiales
        int opcion;
        while (!int.TryParse(Console.ReadLine(), out opcion))
        {
            Console.Write("Opción inválida. Intente nuevamente: ");
        }

        switch (opcion)
        {
            case 1:
                return servicios.Compras_en_Línea;
            case 2:
                return servicios.Atención_al_cliente;
            case 3:
                return servicios.Entrega_a_domicilio;
            default:
                Console.WriteLine("Servicio no válido.");
                return servicios.novalido;
        }
    }

    static double CalificarServicio()
    {
        Console.WriteLine("Califique los siguientes aspectos del 1 al 5.");

        int compras = PedirPuntuacion("Compras en línea");
        int atencion = PedirPuntuacion("Atención al cliente");
        int entrega = PedirPuntuacion("Entrega a domicilio");

        return (compras + atencion + entrega) / 3.0;
    }

    static int PedirPuntuacion(string texto)
    {
        int valor;
        Console.Write($"{texto}: ");
        while (!int.TryParse(Console.ReadLine(), out valor) || valor < 1 || valor > 5)
        {
            Console.Write("Valor inválido (1-4 solamente): ");
        }
        return valor;
    }

    static void LimpiarPantalla()
    {
        Console.ReadKey();
        Console.Beep();
        Console.Clear();
    }
}
   

