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

        string nombre = Pedirnombre();
        int edad = PedirEdad();
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
    public static string Pedirnombre()
    {
        //lee la entrada del usuario
        string nombre;
        Console.Write("Por Favor Ingrese su nombre: ");
        nombre = Console.ReadLine();

        //aqui tuve que volver con el if, porque con el bucle while permitia los espacios en blanco infinitamente
        //el objetivo es que el usuario ingrese un nombre valido, no solo espacios o un caracter
        if (string.IsNullOrWhiteSpace(nombre))
        {
            Console.WriteLine("Error: el nombre no puede estar vacío ni contener solo espacios.");
            LimpiarPantalla();
        }
        else if (nombre.Trim().Length == 1)
        {
            Console.WriteLine("Error: el nombre debe tener más de un carácter.");
            LimpiarPantalla();
        }
        else
        {
           return nombre;
        }
        return Pedirnombre();
    }
        static int PedirEdad()
    {
        int edad;
        Console.Write("Ingrese su edad: ");
        while (!int.TryParse(Console.ReadLine(), out edad) || edad <= 0 || edad >= 120)
        {
            Console.Write("Edad no válida. Edad debe ser mayor a 0 y menor a 120");
            LimpiarPantalla();

            Console.Write("Ingrese su edad nuevamente: ");
            edad = int.Parse(Console.ReadLine());
            if (edad < 18)
            {
                Console.WriteLine("Lo siento, debes ser mayor de edad para participar en la encuesta.");
                LimpiarPantalla();
            }

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

    //este es mi hermoso metodo mata aplicaciones / mata usuario
    static void LimpiarPantalla()
    {
        Console.ReadKey();
        Console.Beep();
        Console.Clear();
    }
}
   

