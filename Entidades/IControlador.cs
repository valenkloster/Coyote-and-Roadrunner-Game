using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoCorredor.Entidades
{
    public interface IControlador
    {
        void BorrarEntidad();
        
        void Actualizar();

        void Dibujar();
    }
}
