using System;

namespace MAN_Project
{
	class MainClass
	{
		static void PrintMenu() {
			Console.WriteLine("\nMenu:");
	        Console.WriteLine("=====\n");
	        Console.WriteLine("1. Factorisation LU");
	    	Console.WriteLine("2. Factorisation de Cholesky");
	        Console.WriteLine("3. Méthode de Jacobi");
	        Console.WriteLine("4. Méthode de Gauss-Seidel");
	        Console.WriteLine("5. Méthode de relaxation pour Jacobi");
	        Console.WriteLine("6. Méthode de relaxation pour Gauss-Seidel");
	        Console.WriteLine("7. Schéma d'Euler explicite");
	        Console.WriteLine("8. Schéma d'Euler implicite");
	       	Console.WriteLine("9. Schéma de Runge-Kutta d'ordre 4");
	       	Console.WriteLine("0. Quitter");
	       	Console.WriteLine("\nChoix:");
		}

	    static void Main(string[] args)
	    {
	        Matrix mat = new Matrix(0, 0);

	        /* If there is a file in argument, we import it */
	        if(args.Length > 0) {
	        	Console.WriteLine(args[0]);
	        	mat.ImportMatrix(args[0]);
	        }

	        /* Otherwise, we create it manually */
	        else {
	       		mat.FillMatrix();
	        }

	        mat.PrintMatrix();

	        PrintMenu();
	       	int choix = int.Parse(Console.ReadLine());

	       	while(choix != 0) {

	       		switch (choix) {
				    case 1:
				        Console.WriteLine(choix);
				        break;
				    case 2:
				        Console.WriteLine("Factorisation de Cholesky : ");
				        Matrix chol = Cholesky.chol(mat);
				        chol.PrintMatrix();
				        break;
				    case 3:
				        Console.WriteLine(choix);
				       	break;
				    case 4:
				        Console.WriteLine(choix);
				        Gauss_Seidel.gauss_seidel(mat);
				        break;
				    case 5:
				        Console.WriteLine(choix);
				        break;
				    case 6:
				        Console.WriteLine(choix);
				       	break;
				    case 7:
				        Console.WriteLine(choix);
				        break;
				    case 8:
				        Console.WriteLine(choix);
				        break;
				    case 9:
				        Console.WriteLine(choix);
				       	break;
				    default:
				        Console.WriteLine("Mauvais choix");
				        break;
				}

				PrintMenu();
	       		choix = int.Parse(Console.ReadLine());
	       	}

	    }
	}
}