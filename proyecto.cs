
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
string impacto = "";
string impacto_predominante = "";
double porcentajeAprobación;

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
        Console.Write("Ingrese tipo de contenido (pelicula, serie, documental, evento en vivo): ");
        contenido = Console.ReadLine();

        Console.Write("Ingrese duración en minutos: ");
        duracion = int.Parse(Console.ReadLine());

        Console.Write("Ingrese clasificación (todo publico, +13, +18): ");
        clasificacion = Console.ReadLine();

        Console.Write("Ingrese hora programada (0-23): ");
        hora_programada = int.Parse(Console.ReadLine());

        Console.Write("Ingrese nivel de producción (bajo, medio, alto): ");
        produccion = Console.ReadLine();

        contenido = contenido.ToLower();
        clasificacion = clasificacion.ToLower();
        produccion = produccion.ToLower();
        impacto = impacto.ToLower();

        bool validez = true;
        if (contenido == "pelicula")
        {
            if (duracion<60 || duracion>180)
            {
               validez = false;
            }
        }

        if (contenido == "serie")
        {
         
             if (duracion<20|| duracion>90)
            {
               validez = false;
            }     
        }
        if (contenido == "documental")
        {
         
             if (duracion<30|| duracion>120)
            {
               validez = false;
            }     
        }

        if (contenido == "evento en vivo")
        {
         
             if (duracion<30|| duracion>240)
            {
               validez = false;
            }     
        }  
        if (clasificacion == "+13")
        {
         if (hora_programada<6 || hora_programada>22)
         {
            validez = false;
         }
        }
        if (clasificacion == "+18")
        {
         if (hora_programada>=6 && hora_programada<=21)
         {
            validez = false;
         }
        }        
        if (produccion=="bajo" && clasificacion=="+18")
        {
         validez = false;
        }
        totalEvaluados++;      

        if (validez == false)
        {
         Console.WriteLine("Contenido rechazado");
         rechazados ++;
        }
        else
        {
          if (produccion == "alto" || duracion>120 || (hora_programada >= 20 && hora_programada<=23))
          {
            impacto = "alto";
          }
          else if (produccion == "medio" || (duracion>= 60 && duracion <=120) )
          {
            impacto = "medio";
          }

          else if (produccion == "bajo" || duracion < 60)
          {
            impacto = "bajo";
          }
        }
        if (validez == true && (impacto == "bajo" || impacto=="medio"))
        {
         Console.WriteLine("Públicado");
         publicados++;
        }
        else if (validez == true && impacto =="alto")
        {
         Console.WriteLine("Enviado a revisión");
         revision++;
        }
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

        case 3:
        Console.WriteLine("Total evaluados:" + totalEvaluados);
        Console.WriteLine("Publicados: " + publicados);
        Console.WriteLine("Rechazados: " + rechazados);
        Console.WriteLine("En revisión: " + revision);
        Console.WriteLine("Impacto predominante: " + impacto_predominante);
        if (totalEvaluados>0)
        {
        porcentajeAprobación = (publicados*100/totalEvaluados); 
        Console.WriteLine("Porcentaje de aprobación: " + porcentajeAprobación + "%");
        }

        break;

        case 4:
        totalEvaluados=0;
        publicados=0;
        rechazados=0;
        revision=0;
        impacto_predominante="";
        porcentajeAprobación=0;
        Console.WriteLine("Estadisticas reiniciadas");
        break;
     }

} while (opcion !=5);

