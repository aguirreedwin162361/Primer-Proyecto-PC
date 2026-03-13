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
     Console.WriteLine("");

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

        break;

        case 2:
        Console.WriteLine("Reglas de clasificación y horario:");
        Console.WriteLine("Todo público: cualquier hora");
        Console.WriteLine("+13: entre 6 y 22 horas");
        Console.WriteLine("+18: entre 22 y 5 horas");
        Console.WriteLine("");

        Console.WriteLine("Reglas de duración por tipo:");
        Console.WriteLine("Película: 60-180 minutos");
        Console.WriteLine("Serie: 20-90 minutos");
        Console.WriteLine("Documental: 30-120 minutos");
        Console.WriteLine("Evento en vivo: 30-240 minutos");
        Console.WriteLine("");

        Console.WriteLine("Reglas de producción:");
        Console.WriteLine("Producción baja solo válida para Todo público o +13");
        Console.WriteLine("Producción media o alta válida para cualquier clasificación ");
        Console.WriteLine("");
        break;
     }

} while (opcion !=5);

int numero;