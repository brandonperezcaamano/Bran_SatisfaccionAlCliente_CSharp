internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido a la encuesta de satisfacción al cliente.");
        Console.Write("Por favor, ingrese su nombre: ");
        string nombre = Console.ReadLine();
        int edad = Convert.ToInt32(Console.ReadLine());
        if (edad < 18)
        {
            Console.WriteLine("Lo siento, esta encuesta es solo para mayores de 18 años.");
        }
        else
        {
            Console.WriteLine($"Hola {nombre}, por favor responde las siguientes preguntas con una puntuación del 1 al 5.");
            Console.Write("¿Cómo calificaría la calidad de nuestro producto? ");
            int calidadProducto = Convert.ToInt32(Console.ReadLine());
            Console.Write("¿Cómo calificaría la atención al cliente? ");
            int atencionCliente = Convert.ToInt32(Console.ReadLine());
            Console.Write("¿Cómo calificaría la relación calidad-precio? ");
            int relacionCalidadPrecio = Convert.ToInt32(Console.ReadLine());
            double promedio = (calidadProducto + atencionCliente + relacionCalidadPrecio) / 3.0;
            Console.WriteLine($"Gracias por completar la encuesta, {nombre}. Su puntuación promedio es: {promedio:F2}");
        }
    }
}