
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
int ContadorAlto=0;
int ContadorMedio=0;
int ContadorBajo=0;
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
        contenido = Console.ReadLine().ToLower();
        while (contenido != "pelicula" && contenido != "serie" && contenido != "documental" && contenido != "evento en vivo")
         {
            Console.Write("Error, ingrese contenido válido: ");
            contenido = Console.ReadLine().ToLower();
         }

        Console.Write("Ingrese duración en minutos: ");
        duracion = int.Parse(Console.ReadLine());
        while (duracion <= 0)
         {
            Console.Write("Duración invalida, ingrese una mayor a 0: ");
            duracion = int.Parse(Console.ReadLine());
         }

        Console.Write("Ingrese clasificación (todo publico, +13, +18): ");
        clasificacion = Console.ReadLine().ToLower();
        while (clasificacion != "todo publico" && clasificacion != "+13" && clasificacion != "+18")
         {
            Console.Write("Error, ingrese clasificación valida: ");
            clasificacion = Console.ReadLine().ToLower();
         }

        Console.Write("Ingrese hora programada (0-23): ");
        hora_programada = int.Parse(Console.ReadLine());
        while (hora_programada < 0 || hora_programada > 23)
        {
            Console.Write("Hora inválida, ingrese otra: ");
            hora_programada = int.Parse(Console.ReadLine());
        }

        Console.Write("Ingrese nivel de producción (bajo, medio, alto): ");
        produccion = Console.ReadLine().ToLower();
        while (produccion != "bajo" && produccion != "medio" && produccion != "alto")
         {
            Console.Write("Error, ingrese un nivel de producción valido: ");
            produccion = Console.ReadLine().ToLower();
         }

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
         Console.WriteLine("Contenido rechazado debido a que no cumple todas las reglas obligatorias.");
         rechazados ++;
        }
        else
        {
         impacto = "";
          if (produccion == "alto" || duracion>120 || (hora_programada >= 20 && hora_programada<=23))
          {
            impacto = "alto";
            ContadorAlto++;
          }
          else if (produccion == "medio" || (duracion>= 60 && duracion <=120) )
          {
            impacto = "medio";
            ContadorMedio++;
          }

          else if (produccion == "bajo" || duracion < 60)
          {
            impacto = "bajo";
            ContadorBajo++;
          }
        }
        if (validez == true && (impacto == "bajo" || impacto=="medio"))
        {
         Console.WriteLine(" Contenido públicado");
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
        MostrarEstadisticas: 
        Console.WriteLine("Total evaluados:" + totalEvaluados);
        Console.WriteLine("Publicados: " + publicados);
        Console.WriteLine("Rechazados: " + rechazados);
        Console.WriteLine("En revisión: " + revision);
        if (ContadorAlto>ContadorMedio && ContadorAlto>ContadorBajo)
        {
         impacto_predominante = "alto";
        }
        else if (ContadorMedio>ContadorAlto && ContadorMedio>ContadorBajo)
        {
         impacto_predominante = "medio";
        }
        else if (ContadorBajo>ContadorAlto && ContadorBajo>ContadorMedio)
        {
         impacto_predominante = "bajo";
        }
        else
        {
         impacto_predominante= "no se puede determinar";
        }
        Console.WriteLine("Impacto predominante: " + impacto_predominante);

        if (totalEvaluados>0)
        {
        porcentajeAprobación = (publicados*100)/totalEvaluados; 
        Console.WriteLine("Porcentaje de aprobación: " + porcentajeAprobación + "%");
        }
        Console.WriteLine("");
        break;

        case 4:
        totalEvaluados=0;
        publicados=0;
        rechazados=0;
        revision=0;
        impacto_predominante="";
        porcentajeAprobación=0;
        ContadorAlto=0;
        ContadorMedio=0;
        ContadorBajo=0;
        Console.WriteLine("Estadisticas reiniciadas");
        break;

        case 5:
        Console.WriteLine("Resumen final: ");
        goto MostrarEstadisticas;
     }

     if (opcion ==5)
     {
      break;
     }

} while (opcion !=5);
