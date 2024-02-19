using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppElevador.Modelo;

namespace ConsoleAppElevador.Logica.Acciones
{
    public class _Elevador_Detenido : _Elevador_Estado
    {
        public _Elevador_Detenido(_Elevador_Estado estado) : this(estado.Piso_Actual, estado.Elevador)
        {
        }

        public _Elevador_Detenido(int _Piso_Actual, _Elevador_Principal elevador)
        {
            Piso_Actual = _Piso_Actual;
            Elevador = elevador;
            Acciones = new bool[elevador.Obtener_Pisos() + 1];

            Acciones[_Piso_Actual] = true;
        }

        public override string Elevador_en_Movimiento()
        {
            Console.WriteLine(" ");
            Console.WriteLine($"¿A que piso quieres ir?");

            var _Piso_Solicitado = Elevador.Valida_Peticion();

            if (Piso_Actual < _Piso_Solicitado)
            {
                Elevador.estado = new _Elevador_Sube(_Piso_Solicitado, this);
                return "Subiendo...";
            }
            else if (Piso_Actual > _Piso_Solicitado)
            {
                Elevador.estado = new _Elevador_Baja(_Piso_Solicitado, this);
                return "Bajando...";
            }
            else
                return "El elevador se encuentra en el primer piso";
        }
    }
}
