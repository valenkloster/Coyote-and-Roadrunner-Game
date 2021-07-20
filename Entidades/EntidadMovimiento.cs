using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JuegoCorredor.Entidades
{
    public class EntidadMovimiento : EntidadJuego
    {
       
        TableroPuntaje tablero;
        ContentManager content;
        public EntidadMovimiento(int pantalla_alto, int pantalla_largo, ContentManager cm, SpriteBatch sb, Color color) : base(pantalla_alto, pantalla_largo, cm, sb, color)
        {
            this.Color = color;
            this.estado = Estado.CORRIENDO;
            this.spriteBatch = sb;
            this.content = cm;
            Img_Colision = cm.Load<Texture2D>("Corredor_colision");
            tablero = new TableroPuntaje(this.PANTALLA_ALTO, this.PANTALLA_LARGO, content, this.spriteBatch, Color.White);

        }

        protected void Init()
        {
            this.X = (int)this.Posicion.X;      
            this.Y = (int)this.Posicion.Y;
            this.Ancho = this.Imagen.Width;
            this.Alto = this.Imagen.Height;
        }

        public void Colision()
        {
            this.estado = Estado.MURIO;
          

        }


        public virtual void Mover()
        {
            this.VELOCIDAD_SPRITE_X = 8;
            this.X = (int)this.Posicion.X;
            this.Y = (int)this.Posicion.Y;
        }
    }
}
