using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoCorredor.Entidades
{
    public class EntidadEstatica:EntidadJuego
    {
        public EntidadEstatica(int pantalla_alto,int pantalla_largo,ContentManager cm,SpriteBatch sb, Color color) : base(pantalla_alto, pantalla_largo, cm, sb, color)
        {

        }
        protected virtual void Init()
        {

            this.X = (int)this.Posicion.X;
            this.Y = (int)this.Posicion.Y;
            this.Ancho = this.Imagen.Width;
            this.Alto = this.Imagen.Height;
        }
    }
}
