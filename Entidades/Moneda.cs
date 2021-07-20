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
    public class Moneda : EntidadMovimiento
    {
        public Moneda(int pantalla_alto, int pantalla_largo, ContentManager cm, SpriteBatch sb, Color color) : base(pantalla_alto, pantalla_largo, cm, sb, color)//llamo al contrucor de la base
        {
            this.Imagen = cm.Load<Texture2D>("Moneda");
          
            var seed = Environment.TickCount;
            var rand = new Random(seed);
            int x = rand.Next(300,4000) ;

            int y = rand.Next(0, 3);
            if (y == 0)
            {
                y = 148; 
            }
            if (y == 1)
            {
                y = 85;
            }
            
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
            this.Posicion.Y += this.VELOCIDAD_SPRITE_Y;
            this.X = (int)this.Posicion.X;
            this.Y = (int)this.Posicion.Y;
            spriteBatch.Draw(this.Imagen, this.Posicion, this.Color);
        }
    }
}
