using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleAppElevador.Modelo;

namespace ConsoleAppElevador.Logica.Acciones
{
    public class _Elevador_Baja : _Elevador_Estado
    {
        private readonly int _Piso_Solicitado;

        public _Elevador_Baja(int Piso_Solicitado, _Elevador_Estado estado) : this(estado.Piso_Actual, estado.Acciones, estado.Elevador)
        {
            _Piso_Solicitado = Piso_Solicitado;
        }

        private _Elevador_Baja(int _Piso_Actual, bool[] accion, _Elevador_Principal elevador)
        {
            Piso_Actual = _Piso_Actual;
            Acciones = accion;
            Elevador = elevador;
        }

        public override string Elevador_en_Movimiento()
        {
            var _mensaje = string.Empty;

            if (_Piso_Solicitado < 1 || _Piso_Solicitado > Elevador.Obtener_Pisos())
                return "Piso no valido.\n";

            for (int i = Piso_Actual; i >= 1; i--)
            {
                if (Acciones[i])
                {
                    _mensaje = Detener_Elevador(_Piso_Solicitado);
                    Elevador.estado = new _Elevador_Detenido(this);
                    break;
                }
                else
                    continue;
            }

            return _mensaje ?? "Piso no disponible!\n";
        }
    }
}
