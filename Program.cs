using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace Restaurante
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Platos platos = new Platos();

            /*Mesa 1:
             Cuatro entradas, cuatro platos fuertes y cuatro postres*/
            platos.Entrada(1);
            platos.Entrada(1);
            platos.Entrada(1);
            platos.Entrada(1);

            platos.Fuerte(1);
            platos.Fuerte(1);
            platos.Fuerte(1);
            platos.Fuerte(1);

            platos.Postre(1);
            platos.Postre(1);
            platos.Postre(1);
            platos.Postre(1);
            /*Mesa 2:
             Cuatro platos fuertes y cuatro postres*/
            platos.Fuerte(2);
            platos.Fuerte(2);
            platos.Fuerte(2);
            platos.Fuerte(2);

            platos.Postre(2);
            platos.Postre(2);
            platos.Postre(2);
            platos.Postre(2);
            
            /*Mesa 3:
             Dos platos fuertes */

            platos.Fuerte(3);
            platos.Fuerte(3);

            Console.ReadKey();

        }
    }

    public class Platos
    {
        int cubierto = 5;
        int cuchara = 6;
        int cucharaPostre = 4;
        int cuchillo = 6;

        public async void Entrada(int numeroMesa)
        {
            
            await Task.Run(() =>
            {
                PonerUtensilioDeEntradaEnMesa();
                Console.WriteLine("Entrada servida en mesa " + numeroMesa + ". ");

                VerUtensiliosDisponibles();

                Thread.Sleep(5000);

                RecogerUtensilioDeEntradaDeMesa();
                Console.WriteLine("Entrada Terminada de servir en mesa " + numeroMesa + ".");
                

            });
            
        }

        private void PonerUtensilioDeEntradaEnMesa()
        {
            cuchara--;
            cuchillo--;
        }

        private void RecogerUtensilioDeEntradaDeMesa()
        {
            cuchara++;
            cuchillo++;
        }

        public async void Fuerte(int numeroMesa)
        {

            await Task.Run(() =>
            {
                PonerUtensilioDePlatoFuerteEnMesa();
                Console.WriteLine("Plato Fuerte servido en mesa " + numeroMesa + ".");

                VerUtensiliosDisponibles();

                Thread.Sleep(5000);

                RecogerUtensilioDePlatoFuerteDeMesa();
                Console.WriteLine("Plato Fuerte Terminada de servir en mesa " + numeroMesa + ".");

            });
            
        }

        private void PonerUtensilioDePlatoFuerteEnMesa()
        {
            cubierto--;
            cuchillo--;
        }

        private void RecogerUtensilioDePlatoFuerteDeMesa()
        {
            cubierto++;
            cuchillo++;
        }

        public async void Postre(int numeroMesa)
        {

            await Task.Run(() =>
            {
                PonerUtensilioDePostreEnMesa();
                Console.WriteLine("Postre servido en mesa " + numeroMesa + ".");

                VerUtensiliosDisponibles();

                Thread.Sleep(5000);

                RecogerUtensilioDePostreDeMesa();
                Console.WriteLine("Postre Terminada de servir en mesa " + numeroMesa + ".");


            });

            
        }

        private void PonerUtensilioDePostreEnMesa()
        {
            cucharaPostre--;
        }

        private void RecogerUtensilioDePostreDeMesa()
        {
            cucharaPostre++;
        }

        private void VerUtensiliosDisponibles()
        {
            Console.WriteLine("Cuchara = " + cuchara + ", Cubierto = " + cubierto +", Cuhara de postre = " + cucharaPostre +", Cuchillo = " + cuchillo);
        }
    }
}
