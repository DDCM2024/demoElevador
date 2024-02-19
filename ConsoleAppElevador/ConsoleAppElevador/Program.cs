// See https://aka.ms/new-console-template for more information
using ConsoleAppElevador;
using ConsoleAppElevador.Logica;

int No_Pisos = 5;

var _iniciar = new _Elevador_Principal(No_Pisos);

Console.WriteLine("****************************************************************************************************");
Console.WriteLine("****************************************************************************************************\n");
Console.WriteLine("B I E N V E N I D O ! ! ! \n");
Console.WriteLine("Para salir de la aplicacion digite 0.\n");
Console.WriteLine($"Considerar que el edificio tiene {No_Pisos} pisos.\n");
Console.WriteLine("****************************************************************************************************");
Console.WriteLine("****************************************************************************************************\n");

_iniciar.Iniciar_Peticion();
