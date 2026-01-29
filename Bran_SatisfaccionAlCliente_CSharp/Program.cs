internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido a la encuesta de satisfacción al cliente.");
        Console.Write("Por favor, ingrese su nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Por favor, ingrese su edad: ");
        int edad = Convert.ToInt32(Console.ReadLine());
        if (edad < 18)
        {
            Console.WriteLine("Lo siento, esta encuesta es solo para mayores de 18 años.");
        }
        else
        {
            Console.WriteLine("¿Que servicio utilizó? (eliga un numero del 1 al 3)");
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
                int calidadProducto = Convert.ToInt32(Console.ReadLine());
                Console.Write("¿Cómo calificaría la atención al cliente? ");
                int atencionCliente = Convert.ToInt32(Console.ReadLine());
                Console.Write("¿Cómo calificaría la entrega a domicilio? ");
                int relacionCalidadPrecio = Convert.ToInt32(Console.ReadLine());
                double promedio = (calidadProducto + atencionCliente + relacionCalidadPrecio) / 3.0;
                Console.WriteLine($"Gracias por completar la encuesta, {nombre}. Su puntuación promedio es: {promedio:F2}");
            }
         
           while (edad == 0 || edad >= 120)
            { Console.WriteLine("Edad No valida"); }
        }
    }
    enum servicios
    {
        Compras_en_Linea = 1,
        Atencion_al_cliente = 2,
        Entrega_a_domicilio = 3,
    }
}
