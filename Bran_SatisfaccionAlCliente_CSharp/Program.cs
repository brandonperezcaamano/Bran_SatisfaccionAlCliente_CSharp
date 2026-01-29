internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido a la encuesta de satisfacción al cliente.");
        Console.Write("Por favor, ingrese su nombre: ");
        string nombre = Console.ReadLine();
        LimpiarPantalla();
        Console.Write("Por favor, ingrese su edad: ");
        int edad = Convert.ToInt32(Console.ReadLine());
        if (edad < 18)
        {
            Console.WriteLine("Lo siento, esta encuesta es solo para mayores de 18 años.");
        }
        else
        {
            Console.WriteLine("¿Que servicio utilizó? (eliga un numero del 1 al 3)");
            Console.WriteLine("1. Compras en Línea");
            Console.WriteLine("2. Atención al cliente");
            Console.WriteLine("3. Entrega a domicilio");
            int servicio = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Usted eligió el servicio: {(servicios)servicio}");
            if (servicio < 1 || servicio > 3)
            {
                Console.WriteLine("Servicio no válido. Por favor, elija un número del 1 al 3.");
            }
            else
            {
                Console.WriteLine("por favor responde las siguientes preguntas con una puntuación del 1 al 5.");
                Console.Write("¿Cómo calificaría la calidad de nuestro servicio Compras en linea?");
                int comprasLinea = Convert.ToInt32(Console.ReadLine());
                Console.Write("¿Cómo calificaría la atención al cliente? ");
                int atencionCliente = Convert.ToInt32(Console.ReadLine());
                Console.Write("¿Cómo calificaría la entrega a domicilio? ");
                int entregasDomicilio = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("¿algun comentario para ayudarnos mejor?");
                string comentarios = Console.ReadLine();
                Console.WriteLine("Deseas enviar su opinion? [si/no]");
                string respuesta = Console.ReadLine();
                double promedio = (comprasLinea + atencionCliente + entregasDomicilio) / 3.0;
                if (respuesta.ToLower() != "si")
                {
                    Console.WriteLine("Gracias por su tiempo. Su opinión no ha sido enviada.");
                    return;
                }
                else
                {
                    Console.WriteLine("Gracias por enviar su opinión.");
                }

                Console.WriteLine($"Gracias por completar la encuesta, {nombre}.");
            }
            
            Console.WriteLine($"Su puntuación promedio es: { promedio}");



            while (edad == 0 || edad >= 120)
            {
                Console.WriteLine("Edad No valida");

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

