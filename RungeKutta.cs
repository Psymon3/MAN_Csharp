using System;

namespace MAN_Project
{

    public class RungeKutta
    {

        public delegate double fonction (double t, double yt);  // Fonction déléguée, permet d'appeler n'importe quelle fonction test en une seule ligne sans passer par un switch.

        public static void Menu ()
        {

            // Déclarations de variables
            string saisie = null;
            double step = 0;
            bool continueWhile = true;
            double a = 0;
            double b = 0;
            fonction f = null;
            double y0 = 0;


            // Récupération du pas saisi par l'utilisateur
            while (continueWhile)
            {
                Console.Write("\nQuel pas souhaitez-vous utilisez ? (double)\nPas = ");
                saisie = Console.ReadLine ();
                    
                if (!double.TryParse (saisie, out step))     // Teste si l'entrée est bien transformable en double et le cas échéant, la transforme.
                {
                    Console.WriteLine ("\nMauvaise entrée, veuillez réessayer.");
                    continue;
                }

                continueWhile = false;
            }

            continueWhile = true;

            // Récupération de l'intervalle saisi par l'utilisateur
            while (continueWhile)
            {
                Console.Write("\nQuel intervalle [a,b] souhaitez-vous utilisez ? (double)\na = ");
                saisie = Console.ReadLine ();
                    
                if (!double.TryParse (saisie, out a))     // Teste si l'entrée est bien transformable en double et le cas échéant, la transforme.
                {
                    Console.WriteLine ("\nMauvaise entrée, veuillez réessayer.");
                    continue;
                }

                Console.Write("\nQuel intervalle [a,b] souhaitez-vous utilisez ? (double)\nb = ");
                saisie = Console.ReadLine ();
                    
                if (!double.TryParse (saisie, out b))     // Teste si l'entrée est bien transformable en double et le cas échéant, la transforme.
                {
                    Console.WriteLine ("\nMauvaise entrée, veuillez réessayer.");
                    continue;
                }

                if ( a >= b )
                {
                    Console.WriteLine ("\nMauvaise entrée, veuillez réessayer.");
                    continueWhile = true;
                }
                else 
                {
                    continueWhile = false;                    
                }
            }

            continueWhile = true;


            // Choix de l'équation différentielle par l'utilisateur
            while(continueWhile)
            {
                int choix = 0;

                // Affichage d'un menu pour choisir l'une des 9 équations différentielles de test.
                Console.WriteLine("\nChoisissez une équation différentielle :");
                Console.WriteLine("========================================\n");
                Console.WriteLine("1. y'(t) = -y²(t) avec y(0) = 1");
                Console.WriteLine("2. y'(t) = -3y(t) avec y(0) = 2");
                Console.WriteLine("3. y'(t) = -2y(t) + 3 avec y(0) = -1");
                Console.WriteLine("4. y'(t) = 2y(t) - 4t avec y(0) = 3");
                Console.WriteLine("5. y'(t) = 2ty(t) avec y(0) = -2");
                Console.WriteLine("6. y'(t) = 2ty(t) - 2t avec y(0) = -2");
                Console.WriteLine("7. y'(t) = (-2t/(1+t²)) y(t) + (1+3t²)/(1+t²) avec y(0) = 5");
                Console.WriteLine("8. y'(t) = y(t)/2 - t²/2 + 5t/2 avec y(0) = -1");
                Console.Write("\nChoix : ");

                saisie = Console.ReadLine();

                if (!int.TryParse (saisie, out choix))  // Teste si l'entrée est bien transformable en int et le cas échéant, la transforme.
                {
                    Console.WriteLine ("\nMauvaise entrée, veuillez réessayer.");
                    continue;
                }
                else
                {
                    switch(choix)       // En fonction du choix de l'utilisateur, on place dans f la méthode correspondante, puis dans y0 la valeur de y(0) correspondante.
                    {
                        case 1:
                            f = f1;
                            y0 = 1;
                            break;
                        case 2:
                            f = f2;
                            y0 = 2;
                            break;
                        case 3:
                            f = f3;
                            y0 = -1;
                            break;
                        case 4:
                            f = f4;
                            y0 = 3;
                            break;
                        case 5:
                            f = f5;
                            y0 = -2;
                            break;
                        case 6:
                            f = f6;
                            y0 = -2;
                            break;
                        case 7:
                            f = f7;
                            y0 = 5;
                            break;
                        case 8:
                            f = f8;
                            y0 = -1;
                            break;
                        default:
                            Console.WriteLine ("\nMauvaise entrée, veuillez réessayer.");
                            continue;
                            
                    }
                }

                continueWhile = false;
            }

            Runge(a, b, y0, step, f ); // Appel de la fonction avec les arguments reçus.

        }

        public static void Runge( double a, double b, double y0, double step, fonction f)
        {
            double t, w, k1, k2, k3, k4;
            t = a;
            w = y0;
            for( int i = 0; i < ( b - a ) / step; i = i + 1 ){
                k1 = step * f( t, w );
                k2 = step * f( t + step / 2, w + k1 / 2 );
                k3 = step * f( t + step / 2, w + k2 / 2 );
                k4 = step * f( t + step, w + k3 );
                w = w + ( k1 + 2 * k2 + 2 * k3 + k4 ) / 6;
                t = a + i * step;
                Console.WriteLine("{0} {1} ",t,w);
               }
        }

        public static double f1 (double t, double yt)
        {
            return -(yt*yt); // Test avec l'équation y'(t)=-y²(t) de solution connue y(t)=1/(1+t)
                             
            /* Résultats exacts (1/1000) :

             * Résulats obtenus :

            */
        }

        public static double f2 (double t, double yt)
        {
            return -3*yt; // Test avec l'équation y'(t)=-3y(t) de solution connue y(t)=2exp(-3t)

            /* Résultats exacts :

             * Résultats obtenus :

            */
        }

        public static double f3 (double t, double yt)
        {
            return -2*yt + 3; // Test avec l'équation y'(t)=-ty(t)+t²+1 de solution connue -(5/2)*exp(-2t) + (3/2)

            /* Résultats exacts (1/1000) :

             * Résultats obtenus :

            */
        }

        public static double f4 (double t, double yt)
        {
            return 2*yt - 4*t; // Test avec l'équation y'(t)=2y(t)-4t de solution connue 2exp(2t) + 2t + 1

            /* Résultats exacts (1/1000) :

             * Résultats obtenus :

            */
        }

        public static double f5 (double t, double yt)
        {
            return 2*t*yt; // Test avec l'équation y'(t)=2ty(t) de solution connue -2exp(t²)

            /* Résultats exacts :

             * Résultats obtenus :

            */
        }

        public static double f6 (double t, double yt)
        {
            return 2*t*yt - 2*t; // Test avec l'équation y'(t) = 2ty(t) - 2t de solution connue -3exp(t²) + 1

            /* Résultats exacts :

             * Résultats obtenus :

            */
        }

        public static double f7 (double t, double yt)
        {
            return -((2*t)/(1+t*t))*yt + (1+3*t*t)/(1+t*t); // Test avec l'équation y'(t) = (-2t/(1+t²)) y(t) + (1+3t²)/(1+t²) de solution connue t + 5/(1+t²)

            /* Résultats exacts :

             * Résultats obtenus :
            */

        }

        public static double f8 (double t, double yt)
        {
            return yt/2 - (t*t)/2 + (5*t)/2; // Test avec l'équation y'(t) = y(t)/2 - t²/2 + 5t/2 de solution connue exp(t/2) + t² - t - 2

            /* Résultats exacts :

             * Résultats obtenus :

            */
        }

    }
}
