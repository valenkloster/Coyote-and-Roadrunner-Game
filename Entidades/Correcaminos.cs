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
    public class Correcaminos : EntidadMovimiento
    {
        private Texture2D Correcaminos1;
        private Texture2D Correcaminos2;
        private Texture2D Correcaminos3;
        public Correcaminos(int pantalla_alto, int pantalla_largo, ContentManager cm, SpriteBatch sb, Color color) : base(pantalla_alto, pantalla_largo, cm, sb, color)
        {
            Correcaminos1 = cm.Load<Texture2D>("Correcaminos1");
            Correcaminos2 = cm.Load<Texture2D>("Correcaminos2");
            Correcaminos3 = cm.Load<Texture2D>("Correcaminos3"); 
            this.Imagen = Correcaminos1;

            int x = 4000;
            int y = 110;

            
            this.Posicion = new Vector2(x, y);
            this.Init();
        }


        public override void Mover()
        {
            this.VELOCIDAD_SPRITE_X = -5;
         
        }

        public override void Dibujar()
        {
            this.Posicion.X += this.VELOCIDAD_SPRITE_X;
            this.Posicion.Y = 110;
            this.X = (int)this.Posicion.X;
            this.Y = (int)this.Posicion.Y;
            var seed = Environment.TickCount;
            var rand = new Random(seed);
            int aleatorio = rand.Next(0, 3);
            if (aleatorio == 0)
            {
                this.Imagen = Correcaminos1;
            }
            else if(aleatorio == 1)
            {
                this.Imagen = Correcaminos2;
            }
            else
            {
                this.Imagen = Correcaminos3;
            }
           
            spriteBatch.Draw(this.Imagen, this.Posicion, this.Color);
        }
    }
}
