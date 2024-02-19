using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppElevador.Logica;

namespace ConsoleAppElevador.Modelo
{
    public abstract class _Elevador_Estado
    {
        public _Elevador_Principal Elevador { get; set; }
        public int Piso_Actual { get; set; }
        public bool[] Acciones { get; set; }
        public abstract string Elevador_en_Movimiento();

        public string Detener_Elevador(int Piso_Solicitado)
        {
            Acciones[Piso_Actual] = false;
            Acciones[Piso_Solicitado] = true;
            Piso_Actual = Piso_Solicitado;

            return $"El Elevador se detuvo en el piso {Piso_Solicitado}º.";
        }
    }
}