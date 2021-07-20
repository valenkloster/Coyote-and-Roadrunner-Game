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
    public class Corredor : EntidadJuego
    {
        #region "Constructores"
        public Corredor()
        {
        }
        public Corredor(int pantalla_alto, int pantalla_largo, ContentManager cm, SpriteBatch sb, Color color) : base(pantalla_alto, pantalla_largo, cm, sb, color)
        {
            this.Init(cm, sb);
        }
        #endregion

       // private SoundEffect _sonidoSalto;
        public bool EstaVivo { get; private set; }
        public void Init(ContentManager cm, SpriteBatch sb)
        {
            //_sonidoSalto = cm.Load<SoundEffect>("button-press");
            this.Imagen = cm.Load<Texture2D>("CorredorInactivo");
            ListaAnimacion.Add(cm.Load<Texture2D>("CorredorInactivo"));//POSICION 0
            ListaAnimacion.Add(cm.Load<Texture2D>("Corriendo1"));//POSICION 1
            ListaAnimacion.Add(cm.Load<Texture2D>("Corriendo2"));//POSICION 2
            ListaAnimacion.Add(cm.Load<Texture2D>("Corredor_colision"));//POSICION 3
            ListaAnimacion.Add(cm.Load<Texture2D>("Salta1"));//POSICION 4
            ListaAnimacion.Add(cm.Load<Texture2D>("Salta2"));//POSICION 5
            ListaAnimacion.Add(cm.Load<Texture2D>("Salta3"));//POSICION 6
            ListaAnimacion.Add(cm.Load<Texture2D>("Corredor_agacharse"));//POSICION 7
           
            this.Posicion = new Vector2(98, 100);
            this.inicio = EntidadJuego.Inicio.BLOQUEADO;
            this.X = (int)this.Posicion.X;
            this.Y = (int)this.Posicion.Y;
            this.Imagen = ListaAnimacion[0];// IMAGEN INACTIVO CUANDO ARRANCA
            this.Ancho = this.Imagen.Width;
            this.Alto = this.Imagen.Height;

        }



        public override void Mover(float velX, float velY, Imagen_mov img)//funcion mover para correr
        {

            this.estado = Estado.CORRIENDO;
            this.Posicion.Y = 100;

            this.Imagen = this.ListaAnimacion[(int)img];
          
           

        } 
       
        public void Mover(float velX, float velY, Imagen_mov img, direccion direccion)//sobre carga le paso direccion arriba o abajo para saltar
        {


            if(direccion== JuegoCorredor.Entidades.EntidadJuego.direccion.ABAJO)//AGACHARSE
            {
                this.estado = Estado.AGACHANDOSE;
                this.Posicion.Y = 150;
                this.Imagen = this.ListaAnimacion[(int)img];
              
            }


            if (direccion == JuegoCorredor.Entidades.EntidadJuego.direccion.ARRIBA)//saltar
            {
                this.estado = Estado.SALTANDO;
                //_sonidoSalto.Play();
                this.Posicion.Y = (int)velY;
             
                this.Imagen = this.ListaAnimacion[(int)img];
            }
        }



        public override void Parar()
        {
            this.VELOCIDAD_SPRITE_X = 0;
            this.VELOCIDAD_SPRITE_Y = 0; 

            this.estado = Estado.MURIO;
            this.Imagen = this.ListaAnimacion[3];
        }

        public override void Dibujar()
        {
       
                this.X = (int)this.Posicion.X;
                this.Y = (int)this.Posicion.Y;
           
                spriteBatch.Draw(this.Imagen, this.Posicion, this.Color);
               
        }
       


    }
}
