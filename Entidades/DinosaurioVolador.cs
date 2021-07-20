using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace JuegoCorredor.Entidades
{
    class DinosaurioVolador : EntidadMovimiento
    {
        private Texture2D Dino1;
        private Texture2D Dino2;
        public DinosaurioVolador(int pantalla_alto, int pantalla_largo, ContentManager cm, SpriteBatch sb, Color color) : base(pantalla_alto, pantalla_largo, cm, sb, color)
        {
            
            var seed = Environment.TickCount;
           
            var rand = new Random(seed);

        
            Dino1 = cm.Load<Texture2D>("Dino1");
            Dino2  = cm.Load<Texture2D>("Dino2");
            this.Imagen = Dino1;
          
            int x = rand.Next(300, 5500);


            int y = 120; // suelo


          
            this.Posicion = new Vector2(x, y);
            this.Init();
        }



        public override void Mover()//funcion mover para el dinosaurio
        {
            this.VELOCIDAD_SPRITE_X = -6;
           
        }

        public override void Dibujar()
        {
            this.Posicion.X += this.VELOCIDAD_SPRITE_X;
            this.Posicion.Y = 10;
            this.X = (int)this.Posicion.X;
            this.Y = (int)this.Posicion.Y;
           
            var seed = Environment.TickCount;
            var rand = new Random(seed);
            if (rand.Next(0, 2) == 0)
            {
                this.Imagen = Dino1;
            }
            else
            {
                this.Imagen = Dino2;
            }
            spriteBatch.Draw(this.Imagen, this.Posicion, this.Color);
           
        }
    }



}
    


