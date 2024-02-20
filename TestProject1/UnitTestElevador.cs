using ConsoleAppElevador.Logica;
using ConsoleAppElevador.Logica.Acciones;
using ConsoleAppElevador.Modelo;

namespace TestProject1
{
    public class Tests
    {
        [Test]
        public void Elevador_pisos_1_sube_4()
        {
            Assert.Equals("El elevador se encuentra en el 4 piso", _AccesoPeticiones(1, 5, 1, 4));
        }

        [Test]
        public void Elevador_pisos_5_baja_1()
        {
            Assert.Equals("El elevador se encuentra en el 1 piso", _AccesoPeticiones(2, 5, 5, 1));
        }

        [Test]
        public void Elevador_subir_limite_superior_pisos()
        {
            Assert.Equals("Piso no valido.\n", _AccesoPeticiones(1, 5, 1, 6));
        }

        [Test]
        public void Elevador_bajar_limite_inferior_pisos()
        {
            Assert.Equals("Piso no valido.\n", _AccesoPeticiones(2, 5, 1, -1));
        }

        [Test]
        public void Elevador_iniciar_limite_superior_pisos()
        {
            var _Pisos_Edificio = 5;
            var _Piso_Inicio = 6;
            var ElevadorPrincipal = new _Elevador_Principal(_Pisos_Edificio);
            Assert.Throws<IndexOutOfRangeException>(() => new _Elevador_Detenido(_Piso_Inicio, ElevadorPrincipal));
        }

        public string _AccesoPeticiones(int _Peticion, int _Pisos_Edificio, int _Piso_Inicio, int _Piso_Peticion)
        {
            var resultado = string.Empty;
            var ElevadorPrincipal = new _Elevador_Principal(_Pisos_Edificio);
            var ElevadorDetenido = new _Elevador_Detenido(_Piso_Inicio, ElevadorPrincipal);         
            
            if (_Peticion == 1)
            {
                var ElevadorSube = new _Elevador_Sube(_Piso_Peticion, ElevadorDetenido);
                resultado = ElevadorSube.Elevador_en_Movimiento();
            }
            else if (_Peticion == 2)
            {
                var ElevadorBaja = new _Elevador_Baja(_Piso_Peticion, ElevadorDetenido);
                resultado = ElevadorBaja.Elevador_en_Movimiento();
            }
            else { }
            
            return resultado;
        }
    }
}

