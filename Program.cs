using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangMan
{
    class Program
    {
        static void Main()
        {            
            string[] palabras = new string[10];
            string[] palabras1 = new string[10] { "oro", "sol", "moco", "mesa", "pila", "libro", "raton", "planta", "tiza", "boli"};
            string[] palabras2 = new string[10] { "abecedario", "camisa", "ceramica", "pizarra", "teclado", "calendario", "tejado", "planeta", "rozadura", "emergencia" };
            string[] palabras3 = new string[10] { "jazmin", "ajedrez", "astigmatismo", "catapulta", "blasfemia", "merendola", "particion", "hemorragia", "circuncision", "barbiturico" };
            Console.WriteLine("Bienvenido!");
            string respuesta = Console.ReadLine();

            while(respuesta != "s" && respuesta != "n")
            {
                Console.WriteLine("Estás listo para empezar?!");
                Console.WriteLine("Presiona -> 's' para Empezar");
                Console.WriteLine("Presiona -> 'n' para Salir");
                respuesta = Console.ReadLine();
            }
            

            if(respuesta == "s")
            {
                while (respuesta != "1" && respuesta != "2" && respuesta != "3")
                {
                    Console.Clear();
                    Console.WriteLine("Escoge Dificultad!");
                    Console.WriteLine("Presiona 1 ----> nivel fácil");
                    Console.WriteLine("Presiona 2 ----> nivel medio");
                    Console.WriteLine("Presiona 3 ----> nivel difícil");
                    respuesta = Console.ReadLine();
                }
                switch (respuesta)
                {
                    case "1":
                        palabras = palabras1;
                        break;
                    case "2":
                        palabras = palabras2;
                        break;
                    case "3":
                        palabras = palabras3;
                        break;
                }
                EmpezarJuego(palabras);
            }
            else
            {
                Console.WriteLine("Hasta Pronto!");
                Console.ReadLine();
            }
        }

        static void EmpezarJuego(string[] palabras)
        {
            Console.Clear();
            int vidas = 10;
            Random random = new Random();
            int randomIndex = random.Next(1, palabras.Length);
            string randomWord = palabras[randomIndex];
            //Console.WriteLine(randomWord);
            string[] secretWord = new string[randomWord.Length];
            bool acierto = false;
            bool gameOver = false;

            for (int i = 0; i < randomWord.Length; i++)
            {
                secretWord[i] = " - ";
                Console.Write(secretWord[i]);
            }

            while (vidas > 0 && !gameOver)
            {
                Console.WriteLine("//Te quedan ----->" + vidas + " Vidas<-----");
                vidas--;
                string respuesta =  Console.ReadLine();
                char letra = respuesta[0];
                
                //comprobar letra
                for (int i = 0; i < randomWord.Length; i++)
                {
                    if (letra == randomWord[i])
                    {
                        secretWord[i] = letra.ToString();
                        acierto = true;
                    }
                    Console.Write(secretWord[i]);
                }

                if (acierto)
                {
                    vidas++;
                }

                acierto = false;
                if (checkWord(secretWord))
                {
                    gameOver = true;
                }
            }
            if(vidas > 0)
            {
                string seguirjugando = "";
                Console.Clear();
                Console.WriteLine("Felicidades!! es corecto, la palabra era " + randomWord);
                do
                {
                    Console.WriteLine("Presiona 'r' Para volver a jugar o 's' para salir.");
                    seguirjugando = Console.ReadLine();
                }
                while (seguirjugando != "s" && seguirjugando != "r");
                if(seguirjugando == "r")
                {
                    Main();
                }
                
            }
            else
            {
                Console.Clear();
                Console.WriteLine("GAME OVER!  La palabra era ------------>" + randomWord);
                Console.ReadLine();
            }            
            
        }

        static bool checkWord(string[] secretWord)
        {
            int terminado = 0;
            foreach(string letra in secretWord){
                if(letra == " - ")
                {
                    terminado++;
                }
            }

            if(terminado == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
