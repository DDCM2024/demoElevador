using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppElevador.Logica.Acciones;
using ConsoleAppElevador.Modelo;

namespace ConsoleAppElevador.Logica
{
    public class _Elevador_Principal
    {
        public _Elevador_Estado estado;
        private readonly int No_Pisos;

        public _Elevador_Principal(int no_Pisos)
        {
            No_Pisos = no_Pisos;
            // El primer piso es el Lobby
            estado = new _Elevador_Detenido(1, this);
        }

        public void Iniciar_Peticion()
        {
            while (true)
                Console.WriteLine(estado.Elevador_en_Movimiento());
        }

        public int Obtener_Pisos()
        {
            return No_Pisos;
        }

        public int Valida_Peticion()
        {
        _Peticion:
            var entrada = Console.ReadLine();

            if (entrada == "0")
                Environment.Exit(0);

            if (!int.TryParse(entrada, out int resultado))
            {
                Console.WriteLine("La consola solo acepta numeros, favor de introducir el piso solicitado: \n");
                goto _Peticion;
            }
            else if (resultado < 1 || resultado > No_Pisos)
            {
                Console.WriteLine($"El elevador va del 1º al {No_Pisos}º nivel. Favor de introducir el piso solicitado.");
                goto _Peticion;
            }

            return resultado;
        }
    }
}
