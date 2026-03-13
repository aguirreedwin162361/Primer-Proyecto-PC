int opcion;
string contenido = "";
int duracion;
string clasificacion = "";
int hora_programada;
string produccion = "";
int totalEvaluados = 0;
int publicados = 0;
int rechazados = 0;
int revision = 0;

do
{
    Console.WriteLine("MENÚ");
    Console.WriteLine("1.Evaluar nuevo contenido");
    Console.WriteLine("2.Mostrar Reglas del Sistema");
    Console.WriteLine("3.Mostrar estadísticas de la sesión");
    Console.WriteLine("4.Reiniciar estadísticas");
    Console.WriteLine("5.Salir");

     Console.Write("Seleccione una opción: ");
     opcion = int.Parse(Console.ReadLine());

     switch (opcion)
     {
        case 1:
        Console.Write("Ingrese tipo de contenido (película, serie, documental, evento en vivo): ");
        contenido = Console.ReadLine();

        Console.Write("Ingrese duración en minutos: ");
        duracion = int.Parse(Console.ReadLine());

        Console.Write("Ingrese clasificación (todo público, +13, +18): ");
        clasificacion = Console.ReadLine();

        Console.Write("Ingrese hora programada (0-23): ");
        hora_programada = int.Parse(Console.ReadLine());

        Console.Write("Ingrese nivel de producción (bajo, medio, alto): ");
        produccion = Console.ReadLine();

     }

} while (opcion !=5);

int numero;