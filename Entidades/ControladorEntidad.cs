using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
/*
 
Corrobaron el codigo y comentar 
Cambiar Diagrama de clases 

 */
namespace JuegoCorredor.Entidades
{
    public class ControladorEntidad : IControlador
    {
        int PANTALLA_ALTO;
        int PANTALLA_LARGO;
        SpriteBatch spriteBatch;
        ContentManager content;
        TableroPuntaje tablero;
        int cont = 0;
        int cont1 = 0;
        EntidadEstatica fondo;
        private SoundEffect sonidomoneda;
        private SoundEffect perdedor;
        private SoundEffect ganador;
        public Song sonido;
        public Dictionary<int, EntidadMovimiento> EntidadesMovimiento { get; set; }
        public Dictionary<int, EntidadJuego> EntidadesEstaticas { get; set; }

        public Corredor Corredor { get; set; }

        public ControladorEntidad(int pantalla_alto, int pantalla_largo, ContentManager cm, SpriteBatch sb)
        {
            this.PANTALLA_ALTO = pantalla_alto;
            this.PANTALLA_LARGO = pantalla_largo;
            this.spriteBatch = sb;
            this.content = cm;
            this.EntidadesMovimiento = new Dictionary<int, EntidadMovimiento>();
            this.EntidadesEstaticas = new Dictionary<int, EntidadJuego>();
            tablero = new TableroPuntaje(this.PANTALLA_ALTO, this.PANTALLA_LARGO, content, this.spriteBatch, Color.Black);
           this. sonidomoneda = cm.Load<SoundEffect>("Sonido-Moneda");
            this.perdedor = cm.Load<SoundEffect>("game over");
            this.ganador = cm.Load<SoundEffect>("winner");
            this.sonido = cm.Load<Song>("Sonido-Fondo");
           

            AgregarEntidades();
        }
        

        private void AgregarEntidades()
        {
            this.Corredor = new JuegoCorredor.Entidades.Corredor(PANTALLA_ALTO, PANTALLA_LARGO, content, spriteBatch, Color.White);

            EntidadEstatica objeto;
            objeto = new Desierto(PANTALLA_ALTO, PANTALLA_LARGO, content, spriteBatch, Color.White);
            this.EntidadesEstaticas.Add(0, objeto);
            
            fondo = new Presentacion(PANTALLA_ALTO, PANTALLA_LARGO, content, spriteBatch, Color.White);

            
            int i;

            EntidadMovimiento monedas;
            for ( i = 0; i < 20; i++)
            {

                System.Threading.Thread.Sleep(10);
                monedas = new JuegoCorredor.Entidades.Moneda(PANTALLA_ALTO, PANTALLA_LARGO, content, spriteBatch, Color.White);

                this.EntidadesMovimiento.Add(i, monedas);

            } 

            EntidadMovimiento Carrito;

            for ( i = 20; i < 25; i++)
            {
                System.Threading.Thread.Sleep(10);
                Carrito = new JuegoCorredor.Entidades.Carrito(PANTALLA_ALTO, PANTALLA_LARGO, content, spriteBatch, Color.White);

                this.EntidadesMovimiento.Add(i, Carrito);

            }
            EntidadMovimiento Bala;

            for ( i = 25; i < 35; i++)
            {
                System.Threading.Thread.Sleep(10);
                Bala = new JuegoCorredor.Entidades.Bala(PANTALLA_ALTO, PANTALLA_LARGO, content, spriteBatch, Color.White);

                this.EntidadesMovimiento.Add(i, Bala);

            }

            EntidadMovimiento Dino;

            for ( i = 35; i < 38; i++)
            {
                System.Threading.Thread.Sleep(10);
                Dino = new JuegoCorredor.Entidades.DinosaurioVolador(PANTALLA_ALTO, PANTALLA_LARGO, content, spriteBatch, Color.White);

                this.EntidadesMovimiento.Add(i, Dino);

            }

            
            EntidadMovimiento correcaminos;

                System.Threading.Thread.Sleep(10);
                correcaminos = new JuegoCorredor.Entidades.Correcaminos(PANTALLA_ALTO, PANTALLA_LARGO, content, spriteBatch, Color.White);

                this.EntidadesMovimiento.Add(i, correcaminos);

            

        }



        public void BorrarEntidad()
        {
            
                List<int> Colisiones = new List<int>();
                foreach (var m in this.EntidadesMovimiento.Keys)
                {
                    if (this.EntidadesMovimiento[m].estado == EntidadJuego.Estado.COLISION) // Colision moneda
                    {
                        tablero.Puntaje += 10;
                        Colisiones.Add(m);
                    }
                    if (this.EntidadesMovimiento[m].estado == EntidadJuego.Estado.MURIO) // Colision obstaculo
                    {
                        Colisiones.Add(m);
                    }

                }

                foreach (int p in Colisiones)
                {

                    this.EntidadesMovimiento.Remove(p);
                }

           


        }

        public void Actualizar()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
            {
                this.Corredor.inicio = EntidadJuego.Inicio.DESBLOQUEADO;
                MediaPlayer.Play(sonido);
                System.Threading.Thread.Sleep(100);
            }

            if(this.Corredor.inicio == EntidadJuego.Inicio.DESBLOQUEADO)
            {
            
              if ((this.Corredor.estado != EntidadJuego.Estado.MURIO ) && (this.Corredor.estado != EntidadJuego.Estado.GANO))
               {

                        if (Keyboard.GetState().IsKeyDown(Keys.Space))//Salto intermedio
                        {
                           //Se va a ir cambiando la imagen con ayuda de un contador, para que garantiza la "secuencia" del salto
                            if (cont1 == 0)
                            {
                                this.Corredor.Mover(0f, 60f, JuegoCorredor.Entidades.Corredor.Imagen_mov.SALTO1, JuegoCorredor.Entidades.Corredor.direccion.ARRIBA);
                                cont1++;
                            }
                            else if (cont1 == 1)
                            {
                                this.Corredor.Mover(0f, 50f, JuegoCorredor.Entidades.Corredor.Imagen_mov.SALTO2, JuegoCorredor.Entidades.Corredor.direccion.ARRIBA);
                                cont1++;
                            }
                            else if (cont1 == 2)
                            {
                                this.Corredor.Mover(0f, 60f, JuegoCorredor.Entidades.Corredor.Imagen_mov.SALTO3, JuegoCorredor.Entidades.Corredor.direccion.ARRIBA);
                                cont1 = 0;
                            }

                        }
                        else if(Keyboard.GetState().IsKeyDown(Keys.Up))//Salto Doble
                        {
                        //Se va a ir cambiando la imagen con ayuda de un contador, para que garantiza la "secuencia" del salto
                                if (cont1 == 0)
                                {
                                    this.Corredor.Mover(0f, 0f, JuegoCorredor.Entidades.Corredor.Imagen_mov.SALTO1, JuegoCorredor.Entidades.Corredor.direccion.ARRIBA);
                                    cont1++;
                                }
                                else if (cont1 == 1)
                                {
                                    this.Corredor.Mover(0f, -10f, JuegoCorredor.Entidades.Corredor.Imagen_mov.SALTO2, JuegoCorredor.Entidades.Corredor.direccion.ARRIBA);
                                    cont1++;
                                }
                                else if (cont1 == 2)
                                {
                                    this.Corredor.Mover(0f, 0f, JuegoCorredor.Entidades.Corredor.Imagen_mov.SALTO3, JuegoCorredor.Entidades.Corredor.direccion.ARRIBA);
                                    cont1 = 0;
                                }
                        }
                        else if (Keyboard.GetState().IsKeyDown(Keys.Down))
                        {
                            this.Corredor.Mover(0f, -2f, JuegoCorredor.Entidades.Corredor.Imagen_mov.AGACHARSE, JuegoCorredor.Entidades.Corredor.direccion.ABAJO);

                        }
                        else
                        {
                           //Se va a ir cambiando la imagen con ayuda de un contador, para que garantize que se cumple la alteracion de imagenes en la secuencia de correr
                           if (cont % 2 == 0)
                            {
                                this.Corredor.Mover(0f, 0f, JuegoCorredor.Entidades.Corredor.Imagen_mov.CORRE1);
                            }
                            else
                            {
                                this.Corredor.Mover(0f, 0f, JuegoCorredor.Entidades.Corredor.Imagen_mov.CORRE2);
                            }
                            cont++;
                        }



                Rectangle r_Corredor = new Rectangle(this.Corredor.X, this.Corredor.Y, this.Corredor.Ancho, this.Corredor.Alto);
                this.BorrarEntidad();

                //Muevo todas los obstaculos
               foreach (var l in this.EntidadesMovimiento.Values)
                {
                    l.Mover();
                }


                //controlo si los obstaculos colisionaron con el corredor
                foreach (var n in this.EntidadesMovimiento.Keys)
                {
                    //creamos el rect para el obstaculo
                    Rectangle r_obstaculo = new Rectangle(this.EntidadesMovimiento[n].X, this.EntidadesMovimiento[n].Y, this.EntidadesMovimiento[n].Ancho, this.EntidadesMovimiento[n].Alto);


                    if (r_obstaculo.Intersects(r_Corredor))
                    {

                        //chequeo si es moneda
                        if (this.EntidadesMovimiento[n] is Moneda)
                        {
                            this.EntidadesMovimiento[n].estado = EntidadJuego.Estado.COLISION;
                            this.Corredor.estado = EntidadJuego.Estado.COLISION;
                             sonidomoneda.Play();

                            }// suma puntos
                        else if (this.EntidadesMovimiento[n] is Correcaminos)
                        {
                            this.EntidadesMovimiento[n].estado = EntidadJuego.Estado.COLISION;
                            this.Corredor.estado = EntidadJuego.Estado.GANO;
                                MediaPlayer.Stop();
                                ganador.Play();

                            }  //Gana el juego                      
                        else 
                        {
                                this.EntidadesMovimiento[n].Colision();
                                this.Corredor.Parar();
                                MediaPlayer.Stop();
                                perdedor.Play();
                            }//perdio

                    }

 

                }
              }
            }
        }

        public void Dibujar()
        {
            

            if (this.Corredor.inicio == EntidadJuego.Inicio.BLOQUEADO)
            {
                fondo.Dibujar();
             

            }//Esto se va  a ejecutar como "pantalla de inicio" hasta que no se desbloquee con enter
            else
            {

                System.Threading.Thread.Sleep(50);
                //dibujamos los elementos estaticos
                foreach (var l in this.EntidadesEstaticas.Values)
                {
                    l.Dibujar();
                }

                foreach (var l in this.EntidadesMovimiento.Values)
                {
                    l.Dibujar();
                }

                this.Corredor.Dibujar();
                //Dibujamos el tablero
                this.tablero.Dibujar();

                //gana si atrapa al correcaminos
                if (this.Corredor.estado == EntidadJuego.Estado.GANO)
                {
                    
                    tablero.Dibujar("F E L I C I T A C I O N E S !!!");
                    foreach (var m in this.EntidadesMovimiento.Keys)
                    {
                        this.EntidadesMovimiento[m].VELOCIDAD_SPRITE_X = 0;
                        this.EntidadesMovimiento[m].VELOCIDAD_SPRITE_Y = 0;
                    }

                }
                else if (this.Corredor.estado == EntidadJuego.Estado.MURIO)
                {
                    
                    tablero.Dibujar("G A M E  O V E R!!!");
                    foreach (var m in this.EntidadesMovimiento.Keys)
                    {
                        this.EntidadesMovimiento[m].VELOCIDAD_SPRITE_X = 0;
                        this.EntidadesMovimiento[m].VELOCIDAD_SPRITE_Y = 0;
                        
                    }

                }
            }


        }

    }
}

        


       