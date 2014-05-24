using System;

/* Implémentation de la méthode d'Euler explicite
 * 
 * Date : Jeudi 22 mai 2014
 * 
 * Auteur : Nicolas Buecher
 * 
 * Objectif : Approximation numérique des valeurs de y(t), solution de l'équation différentielle y'(t) = f(t, y(t)).
 * 
 * État actuel : Méthode d'Euler implémentée. Elle fonctionne pour f(t, y(t)) fixe et y(0) fixe (au choix parmi 8 fonctions), ainsi que pour un
 * 				 pas et un nombre d'itérations au choix de l'utilisateur.
 * 				 La solution particulière pourrait être laissée au choix de l'utilisateur, mais cela n'a aucun intérêt dans le cadre de ce projet
 * 				 car on ne pourrait vérifier l'exactitude des résultats sans de fastidieux calculs. (En effet, la solution exacte ne serait pas
 * 				 connue. Je la donne en commentaire dans chaque fonction f1, f2, etc.)
 * 
 * Reste à faire : Laisser l'utilisateur choisir f(t, y(t)). (Trouver un moyen de "lire" une fonction entrée par l'utilisateur.
 * 				   Plutôt long et complexe. Projet abandonné.)
 * 
 * Variables :
 * 			 saisie	= string contenant les entrées de l'utilisateur.
 * 				pas	= double contenant la distance entre deux points voulue par l'utilisateur lors la méthode d'Euler.
 * 	   nbIterations	= int contenant le nombre de valeurs y(t) voulu par l'utilisateur à l'issue de la méthode d'Euler.
 * 	  continueWhile	= bool contenant l'instruction de sortie de boucle lors de demandes de saisie à l'utilisateur.
 * 			  choix = int contenant le choix de l'utilisateur lors du choix de l'équation différentielle.
 * 		  		 y0 = double contenant la valeur de la solution particulière y(0). 
 * 	 			  i	= int contenant la variable d'itération.
 * 				y[]	= tableau de double contenant les valeurs de y(t) à l'issue de la méthode d'Euler.
 * 				  f = delegate fonction contenant le nom de la méthode à appeler lors de la méthode d'Euler, méthode correspondant
 * 					  à la fonction choisie par l'utilisateur.
 * 
 * Fonctions :
 * 		
 * 		Menu()
 * 			Arguments : /
 * 			Retourne : /
 * 			Synopsis : Demande à l'utilisateur de saisir le pas, le nombre d'itérations une équation différentielle au choix, puis appelle
 * 					   la fonction EulerExp() avec les données reçues.
 * 		
 * 		EulerExp()
 * 			Arguments :
 * 					 double pas	= Valeur du pas à utiliser dans la méthode d'Euler.
 * 			   int nbIterations	= Nombre d'itérations à effectuer dans la méthode d'Euler.
 * 				  	 fonction f = Méthode correspondant à l'équation différentielle.
 * 					  double y0	= Valeur de la solution particulière y(0).
 * 			Retourne : /
 * 			Synopsis : Vérifie les valeurs reçues en entrée, remplit le tableau y[] par la méthode d'Euler, puis affiche le
 * 					   contenu de ce tableau avant de se terminer.
 * 		
 * 		***** fonctions de test *****
 * 		De type f1, f2, f3, etc.
 * 			Arguments :
 * 					   double t	= Valeur de la variable t.
 * 					  double yt	= Valeur de la fonction y en t.
 * 			Retourne : un double contenant la valeur de f(t, y(t)).
 * 			Synopsis : Calcule et retourne immédiatement la valeur de f(t, y(t)) à partir des valeurs reçues en entrée.
*/

namespace MAN_Project
{

	public class EulerExplicite
	{

		public delegate double fonction (double t, double yt);  // Fonction déléguée, permet d'appeler n'importe quelle fonction test en une seule ligne sans passer par un switch.

		public static void Menu ()
		{

			// Déclarations de variables
			string saisie = null;
			double pas = 0;
			int nbIterations = 0;
			bool continueWhile = true;
			fonction f = null;
			double y0 = 0;


			// Récupération du pas saisi par l'utilisateur
			while (continueWhile)
			{
				Console.Write("\nQuel pas souhaitez-vous utilisez ? (double)\nPas = ");
				saisie = Console.ReadLine ();
					
				if (!double.TryParse (saisie, out pas))		// Teste si l'entrée est bien transformable en double et le cas échéant, la transforme.
				{
					Console.WriteLine ("\nMauvaise entrée, veuillez réessayer.");
					continue;
				}

				continueWhile = false;
			}

			continueWhile = true;


			// Récupération du nombre d'itérations saisi par l'utilisateur
			while(continueWhile)
			{
				Console.Write("\nCombien d'itérations souhaitez-vous observer ? (int)\nNombre d'itérations = ");
				saisie = Console.ReadLine ();

				if (!int.TryParse (saisie, out nbIterations))	// Teste si l'entrée est bien transformable en int et le cas échéant, la transforme.
				{
					Console.WriteLine ("\nMauvaise entrée, veuillez réessayer.");
					continue;
				}

				continueWhile = false;
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

				if (!int.TryParse (saisie, out choix)) 	// Teste si l'entrée est bien transformable en int et le cas échéant, la transforme.
				{
					Console.WriteLine ("\nMauvaise entrée, veuillez réessayer.");
					continue;
				}
				else
				{
					switch(choix) 		// En fonction du choix de l'utilisateur, on place dans f la méthode correspondante, puis dans y0 la valeur de y(0) correspondante.
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

			EulerExp(pas, nbIterations, f, y0); // Appel de la fonction avec les arguments reçus.

		}

		public static void EulerExp (double pas, int nbIterations, fonction f, double y0)
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
			int i = 0;							// Variable d'itération
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

		public static double f1 (double t, double yt)
		{
			return -(yt*yt); // Test avec l'équation y'(t)=-y²(t) de solution connue y(t)=1/(1+t)
							 
			/* Résultats exacts (1/1000) :
			 * 		y(0) = 1
			 * 		y(0,1) = 0,909
			 * 		y(0,2) = 0,833
			 *		y(0,3) = 0,769
			 * Résulats obtenus :
			 * 		y(0,1) = 0,9
			 * 		y(0,2) = 0,819
			 * 		y(0,3) = 0,752
			*/
		}

		public static double f2 (double t, double yt)
		{
			return -3*yt; // Test avec l'équation y'(t)=-3y(t) de solution connue y(t)=2exp(-3t)

			/* Résultats exacts :
			 * 		y(0) = 2
			 * 		y(0,1) = 1,48163644136
			 * 		y(0,2) = 1,09762327219
			 * 		y(0,3) = 0.81313931948
			 * Résultats obtenus :
			 * 		y(0,1) = 1,4
			 * 		y(0,2) = 0,98
			 * 		y(0,3) = 0,686
			*/
		}

		public static double f3 (double t, double yt)
		{
			return -2*yt + 3; // Test avec l'équation y'(t)=-ty(t)+t²+1 de solution connue -(5/2)*exp(-2t) + (3/2)

			/* Résultats exacts (1/1000) :
			 * 		y(0) = -1
			 * 		y(0,1) = -0.547
			 * 		y(0,2) = -0.176
			 * 		y(0,3) = 0.128
			 * Résultats obtenus :
			 * 		y(0,1) = -0,5
			 * 		y(0,2) = -0,1
			 * 		y(0,3) = 0,22
			*/
		}

		public static double f4 (double t, double yt)
		{
			return 2*yt - 4*t; // Test avec l'équation y'(t)=2y(t)-4t de solution connue 2exp(2t) + 2t + 1

			/* Résultats exacts (1/1000) :
			 * 		y(0) = 3
			 * 		y(0,1) = 3.643
			 * 		y(0,2) = 4.384
			 * 		y(0,3) = 5.244
			 * Résultats obtenus :
			 * 		y(0,1) = 3,6
			 * 		y(0,2) = 4,28
			 * 		y(0,3) = 5,056
			*/
		}

		public static double f5 (double t, double yt)
		{
			return 2*t*yt; // Test avec l'équation y'(t)=2ty(t) de solution connue -2exp(t²)

			/* Résultats exacts :
			 * 		y(0) = -2
			 * 		y(0,1) = -2.02010033417
			 * 		y(0,2) = -2.08162154838
			 * 		y(0,3) = -2.18834856741
			 * Résultats obtenus :
			 * 		y(0,1) = -2
			 * 		y(0,2) = -2,04
			 * 		y(0,3) = -2,1216
			*/
		}

		public static double f6 (double t, double yt)
		{
			return 2*t*yt - 2*t; // Test avec l'équation y'(t) = 2ty(t) - 2t de solution connue -3exp(t²) + 1

			/* Résultats exacts :
			 * 		y(0) = -2
			 * 		y(0,1) = -2.03015050125
			 * 		y(0,2) = -2.12243232258
			 * 		y(0,3) = -2.28252285112
			 * Résultats obtenus :
			 * 		y(0,1) = -2
			 * 		y(0,2) = -2,06
			 * 		y(0,3) = -2,1824
			*/
		}

		public static double f7 (double t, double yt)
		{
			return -((2*t)/(1+t*t))*yt + (1+3*t*t)/(1+t*t); // Test avec l'équation y'(t) = (-2t/(1+t²)) y(t) + (1+3t²)/(1+t²) de solution connue t + 5/(1+t²)

			/* Résultats exacts :
			 * 		y(0) = 5
			 * 		y(0,1) = 5.0504950495
			 * 		y(0,2) = 5.00769230769
			 * 		y(0,3) = 4.8871559633
			 * Résultats obtenus :
			 * 		y(0,1) = 5,1
			 * 		y(0,2) = 5,1009900990099
			 * 		y(0,3) = 5,01249047981721
			*/
		}

		public static double f8 (double t, double yt)
		{
			return yt/2 - (t*t)/2 + (5*t)/2; // Test avec l'équation y'(t) = y(t)/2 - t²/2 + 5t/2 de solution connue exp(t/2) + t² - t - 2

			/* Résultats exacts :
			 * 		y(0) = -1
			 * 		y(0,1) = -1.03872890362
			 * 		y(0,2) = -1.05482908192
			 * 		y(0,3) = -1.04816575727
			 * Résultats obtenus :
			 * 		y(0,1) = -1,05
			 * 		y(0,2) = -1,078
			 * 		y(0,3) = -1,0839
			*/
		}

	}
}

