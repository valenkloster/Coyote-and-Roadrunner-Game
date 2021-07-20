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
    class Carrito : EntidadMovimiento
    {
        public Carrito(int pantalla_alto, int pantalla_largo, ContentManager cm, SpriteBatch sb, Color color) : base(pantalla_alto, pantalla_largo, cm, sb, color)
        {
            this.Imagen = cm.Load<Texture2D>("Carrito");
        
            var seed = Environment.TickCount;
            var rand = new Random(seed);
            int x = rand.Next(300, 5500);
            int y = 160;

           
            this.Posicion = new Vector2(x, y);
            this.Init();
        }
   

        public override void Mover()
        {
            this.VELOCIDAD_SPRITE_X = -7;
          
        }

        public override void Dibujar()
        {
            this.Posicion.X += this.VELOCIDAD_SPRITE_X;
            this.Posicion.Y = 130;
            this.X = (int)this.Posicion.X;
            this.Y = (int)this.Posicion.Y;
            spriteBatch.Draw(this.Imagen, this.Posicion, this.Color);
        }
    }
}

