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
    public abstract class EntidadJuego
    {
        #region "Enumeradores"
        public enum Estado
        {
            INACTIVO = 0,
            CORRIENDO = 1,
            SALTANDO = 2,
            AGACHANDOSE = 3,
            COLISION = 4,
            SUMAR_PTS =5,
            MURIO=6,
            GANO=7

        }
        public enum Inicio
        {
            BLOQUEADO=0,
            DESBLOQUEADO=1
        }


        public enum Imagen_mov
        {
            INACTIVO = 0,
            CORRE1 = 1,
            CORRE2 = 2,
            SALTO1 = 4,
            SALTO2 = 5,
            SALTO3 = 6,
            AGACHARSE = 7,
           
        }
        public enum direccion
        {
            ARRIBA = 4,
            ABAJO = 5
        }
       

        #region "Variables"
        public float VELOCIDAD_SPRITE_X = 0;
        public float VELOCIDAD_SPRITE_Y = 0;
        protected Vector2 Posicion;
        protected int PANTALLA_ALTO = 0;
        protected int PANTALLA_LARGO = 0;
        protected List<Texture2D> ListaAnimacion = new List<Texture2D>();
        protected SpriteBatch spriteBatch;
        protected Texture2D Img_Colision;
        #endregion



        #region "Propiedades"
        public int X { get; set; }
        public int Y { get; set; }
        public int Ancho { get; set; }
        public int Alto { get; set; }
        public Texture2D Imagen { get; set; }
        public Estado estado { get; set; }
        public Inicio inicio { get; set; }
        public Color Color { get; set; }

        #endregion

        #region "Constructores"
        public EntidadJuego()
        {
        }
        public EntidadJuego(int pantalla_alto, int pantalla_largo, ContentManager cm, SpriteBatch sb, Color color)
        {
            this.estado = Estado.INACTIVO;
            this.spriteBatch = sb;
            this.PANTALLA_ALTO = pantalla_alto;
            this.PANTALLA_LARGO = pantalla_largo;
            this.Color = color;


        }
        #endregion



        public virtual void Dibujar()
        {
          
            this.Posicion.X += this.VELOCIDAD_SPRITE_X;
            this.Posicion.Y += this.VELOCIDAD_SPRITE_Y;
            this.X = (int)this.Posicion.X;
            this.Y = (int)this.Posicion.Y;


           spriteBatch.Draw(this.Imagen, this.Posicion, this.Color);
        }

        public virtual void Mover(float velX, float velY, Imagen_mov img)
        {
            this.estado = Estado.CORRIENDO;

            //Izquierda-Derecha
            if (this.estado == Estado.CORRIENDO)
            {
                this.VELOCIDAD_SPRITE_X = velX;
                this.VELOCIDAD_SPRITE_Y = velY;
            }
            while (this.estado != Estado.COLISION)
            {
                this.Imagen = this.ListaAnimacion[1];
                this.Imagen = this.ListaAnimacion[2];// los sprites que simulan que corre 
            }

        }
        


        public virtual void Parar()
        {
            this.VELOCIDAD_SPRITE_X = 0;
            this.VELOCIDAD_SPRITE_Y = 0;
            this.estado = Estado.INACTIVO;
            this.Imagen = ListaAnimacion[0];
        }
    }
}
#endregion