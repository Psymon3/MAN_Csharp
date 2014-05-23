using System;

namespace MAN_Project
{

	public class EulerExplicite
	{
		public static void Menu ()
		{

			// Déclarations de variables
			string saisie = null;
			double pas = 0;
			int nbIterations = 0;
			bool continueWhile = true;


			// Résupération du pas saisi par l'utilisateur
			while (continueWhile)
			{
				Console.WriteLine ("Quel pas souhaitez-vous utilisez ? (double)\n");
				saisie = Console.ReadLine ();
					
				if (!double.TryParse (saisie, out pas))		// Teste si l'entrée est bien transformable en double et le cas échéant, la transforme.
				{
					Console.WriteLine ("Mauvaise entrée, veuillez réessayer.\n");
					continue;
				}

				continueWhile = false;
			}

			continueWhile = true;

			while(continueWhile)
			{
				Console.WriteLine ("Combien d'itérations souhaitez-vous observer ? (int)\n");
				saisie = Console.ReadLine ();

				if (!int.TryParse (saisie, out nbIterations))	// Teste si l'entrée est bien transformable en double et le cas échéant, la transforme.
				{
					Console.WriteLine ("Mauvaise entrée, veuillez réessayer.\n");
					continue;
				}

				continueWhile = false;
			}

			EulerExp(pas, nbIterations, 1); // Appel de la fonction avec les arguments reçus. 1 correspond à y(0) pour le test.

		}

		public static void EulerExp (double pas, int nbIterations, double y0)
		{

			// Sécurité
			if ((nbIterations <= 1) || (pas <= 0))		// Cas où l'utilisateur ne rentre pas un nombre d'itérations ou un pas corrects.
			{ 
				Console.WriteLine ("Tu te crois drôle ? Ce pas/nombre d'itérations est irrecevable !\n");
				return;
			}
			if (pas >= 1)			// Cas où l'utilisateur entre une valeur de pas tout à fait inutile : avertissement.
			{
				Console.WriteLine ("Attention : Votre pas est excessivement grand.\n");
			}


			// Déclarations de variables
			int i;							// Variable d'itération
			double[] y = new double[nbIterations+1];		// Tableau contenant les solutions y(0), y(1), etc. à trouver.
			y[0]=y0;


			// Remplissage du tableau y par la méthode d'Euler
			for (i=0; i<nbIterations; i++)
			{
				y[i+1]=y[i]+pas*f(pas*i,y[i]);
			}


			// Affichage des résultats
			Console.WriteLine("Résultat de l'approximation de la solution par la méthode d'Euler explicite\n{0} itérations de pas {1} :\n", nbIterations, pas);
			for (i=0; i<nbIterations; i++)
			{
				Console.WriteLine ("y({0}) = {1}\n", pas*i, y[i]);
				Console.ReadKey (true);
			}

			Console.WriteLine ("Fin de la méthode.\n");
		}

		public static double f (double t, double yt)
		{
			return -(yt*yt); // Test avec l'équation y'(t)=-y²(t) de solution connue y(t)=1/(1+t)
							 // Résultats exacts :
							 // y(0) = 1
							 // y(0,1) = 0,909
							 // y(0,2) = 0,833
							 // y(0,3) = 0,769
							 // Résulats obtenus :
							 // y(0,1) = 0,9
							 // y(0,2) = 0,819
							 // y(0,3) = 0,7519239
		}
	}
}

