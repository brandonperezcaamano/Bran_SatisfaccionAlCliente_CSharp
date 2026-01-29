using static System.Runtime.InteropServices.JavaScript.JSType;

internal class Program
{
    private static void Main(string[] args)
    {
        //entrada al usuario
        Encuesta();
        
        Console.WriteLine("Deseas registrarte como empleado? [si/no]");
        string respuesta = Console.ReadLine();
        if (respuesta.ToLower() == "si")
        {
            Empleados("");
        }
        else
        {
            Console.WriteLine("Gracias por participar en la encuesta. ¡Que tenga un buen día!");
            LimpiarPantalla();
        }
        static void Encuesta ()
    {
        Console.WriteLine("Bienvenido a la encuesta de satisfacción al cliente.");
        Console.Write("Por favor, ingrese su nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Por favor, ingrese su edad: ");
        int edad = int.Parse(Console.ReadLine());
            if (edad == 0 || edad >= 120)
            {
                Console.WriteLine("Edad No valida");
                LimpiarPantalla();
            }
            else if (edad < 18)
            {
                Console.WriteLine("Lo siento, debes ser mayor de edad para participar en esta encuesta.");
                LimpiarPantalla();
            }
            else
            {
                Console.WriteLine("¿Que servicio utilizó? (eliga un numero del 1 al 3)");
                Console.WriteLine("1. Compras en Línea");
                Console.WriteLine("2. Atención al cliente");
                Console.WriteLine("3. Entrega a domicilio");
                int servicio = Convert.ToInt32(Console.ReadLine());
                if (servicio < 1 || servicio > 3)
                {
                    Console.WriteLine("Servicio no válido. Por favor, elija un número del 1 al 3.");
                    LimpiarPantalla();
                }
                else
                {
                    Calificar_servicio();
                    Console.WriteLine($"Gracias por completar la encuesta, {nombre}.");
                    Console.WriteLine("Sus respuestas han sido registradas con éxito. A continuacion un breve resumen de sus respuestas");
                    Console.WriteLine($" Nombre: {nombre}");
                    Console.WriteLine($" Edad: {edad}");
                    Console.WriteLine($" Servicio utilizado: {(servicios)servicio}");
                    LimpiarPantalla();
                }
            }
    }
    static void Calificar_servicio()
    {
        Console.WriteLine("por favor responde las siguientes preguntas con una puntuación del 1 al 5.");
        int puntuacionMinima = 1;
        int puntuacionMaxima = 5;
            if (puntuacionMinima < 1 || puntuacionMaxima > 5)
            {
                Console.WriteLine("Puntuación no válida. Por favor, ingrese un número entre 1 y 5.");
            }
            else
            {
                Console.Write("¿Cómo calificaría la calidad de nuestro servicio Compras en linea?");
                int comprasLinea = int.Parse(Console.ReadLine());
                Console.Write("¿Cómo calificaría la atención al cliente? ");
                int atencionCliente = int.Parse(Console.ReadLine());
                Console.Write("¿Cómo calificaría la entrega a domicilio? ");
                int entregasDomicilio = int.Parse(Console.ReadLine());
                Console.WriteLine("¿algun comentario para ayudarnos mejor?");
                string comentarios = Console.ReadLine();
                double promedio = comprasLinea + atencionCliente + entregasDomicilio / 3.0;
                Console.WriteLine($"El promedio que le brinda al empleado es: {promedio}");
                Console.WriteLine("Deseas enviar su opinion? [si/no]");
                string respuesta = Console.ReadLine();
                if (respuesta.ToLower() != "si")
                {
                    Console.WriteLine("Gracias por su tiempo. Su opinión no ha sido enviada.");
                    return;
                }
                else
                {
                    Console.WriteLine("Gracias por enviar su Evaluación.");
                    return;
                }
            }
    }

    static void LimpiarPantalla()
    {
        Console.ReadKey();
        Console.Beep();
        Console.Clear();
    }
    static void Empleados(string nombre)
        {
            string nombredeempleado = Console.ReadLine();
            Console.WriteLine($"Bienvenido {nombredeempleado}");
            Console.WriteLine("Por favor ingrese su area de trabajo: ");
            string areadetrabajo = Console.ReadLine();
            switch (areadetrabajo)
            {
                case "Atencion al cliente":
                    Console.WriteLine("Gracias por su trabajo en Atencion al cliente");
                    break;
                case "Repartidor":
                    Console.WriteLine("Gracias por su trabajo como Repartidor");

                    break;
                case "Soporte tecnico":
                    Console.WriteLine("Gracias por su trabajo en Soporte tecnico");
                    break;
                default:
                    Console.WriteLine("Area de trabajo no reconocida");
                    break;

            }
    }
}
    enum servicios
    {
        Compras_en_Línea = 1,
        Atención_al_cliente = 2,
        Entrega_a_domicilio = 3
    }
}

