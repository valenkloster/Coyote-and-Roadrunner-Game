using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace JuegoCorredor.Entidades
{
    public class TableroPuntaje : EntidadEstatica
    {
        private SpriteFont fuente;
        public int Puntaje { get; set; }

        public TableroPuntaje(int pantalla_alto, int pantalla_largo, ContentManager cm,SpriteBatch sb,Color color) : base(pantalla_alto, pantalla_largo, cm, sb, color)
        {
            this.fuente = cm.Load<SpriteFont>("Font");
            this.Puntaje  =  0;
            this.Init();
        }

        protected override void Init()
        {
           
        }

        public override void Dibujar()
        {
            spriteBatch.DrawString(fuente, "Puntaje: " + this.Puntaje.ToString()+" / 200", new Vector2(680, 24), this.Color);           
        }

        public void Dibujar(string mensaje)//Cuando gana
        {
            spriteBatch.DrawString(fuente, mensaje.ToString(), new Vector2(601, 99), this.Color);

        }
       

        public override void Mover(float velX, float velY, Imagen_mov dir)
        {
            velX = 0;
            velY = 0;
        }
    }
}
