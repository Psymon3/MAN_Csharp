using System;

namespace MAN_Project
{
	class Main_Class
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
	       	Console.WriteLine("8. Schéma de Runge-Kutta d'ordre 4");
	       	Console.WriteLine("0. Quitter");
	       	Console.WriteLine("\nChoix:");
		}

	    static void Main(string[] args)
	    {
	        Matrix mat = new Matrix(0, 0);
	        PrintMenu();

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

	       	int choix = int.Parse(Console.ReadLine());

	       	while(choix != 0) {

	       		switch (choix) {
				    case 1:
				        //FactorisationLU.Test1();
				        Matrix[] resFactoLu = FactorisationLU.Factorisation(mat);
     					resFactoLu[0].PrintMatrix();
     					resFactoLu[1].PrintMatrix();
				        break;
				    case 2:
				        Console.WriteLine("Factorisation de Cholesky : ");
				        //Cholesky.test1();
						//Cholesky.test2();
						Matrix resCholesky = Cholesky.chol(mat);
            			Console.WriteLine("Decomposition obtenu :");
            			resCholesky.PrintMatrix();
				        break;
				    case 3:
				    	Console.WriteLine("Algorithme de Jacobi : \n");
				    	Console.WriteLine("Nombre d'itérations ?");
				    	int iteration = int.Parse(Console.ReadLine());
				    	int[] b = new int[mat.n];
				    	for(int i = 0;i < mat.n;i++) {
				    		Console.WriteLine("Coordonées "+(i+1)+" de b?");
				    		b[i] = int.Parse(Console.ReadLine());
				    	}
				    	double[] resJacobi =  Jacobi.jacobi(mat,iteration,b);
				    	for(int i=0; i < resJacobi.Length; i++) {
			    			Console.WriteLine(resJacobi[i]);
				    		}
				       	break;
				    case 4:
				        Console.WriteLine("Gauss Seidel Algorithm");
				        Console.WriteLine("1 = Test 1 ; 2 = Test 2 : 3 = your matrice ; 0 = exit");
				        int nbchoix = int.Parse(Console.ReadLine());
				        while(nbchoix != 0){
				        	switch(nbchoix){
				        		case 1:
				        		GaussSeidel.Test1();
				        		break;

				        		case 2:
				        		GaussSeidel.Test2();
				        		break;

				        		case 3:
				        		GaussSeidel.UserMatrixParams(mat);
				        		break;
				        	}
				        	Console.WriteLine("1 = Test 1 ; 2 = Test 2 : 3 = your matrice ; 0 = exit");
				       		nbchoix = int.Parse(Console.ReadLine());
				        }
				        break;
				    case 5:
				        Console.WriteLine(choix);
				        break;
				    case 6:
				        Console.WriteLine("Gauss Seidel Relaxation");
				        Console.WriteLine("1 = Test 1 ; 2 = Test 2 : 3 = your matrice ; 0 = exit");
				        int n = int.Parse(Console.ReadLine());
				        while(n != 0){
				        	switch(n){
				        		case 1:
				        		GaussSeidelRelax.Test1();
				        		break;

				        		case 2:
				        		GaussSeidelRelax.Test2();
				        		break;

				        		case 3:
				        		GaussSeidelRelax.UserMatrixParams(mat);
				        		break;
				        	}
				        	Console.WriteLine("1 = Test 1 ; 2 = Test 2 : 3 = your matrice ; 0 = exit");
				       		n = int.Parse(Console.ReadLine());
				       	}
				       	break;
				    case 7:
				        Console.WriteLine("Approximation numérique par la méthode d'Euler explicite :\n");
						EulerExplicite.Menu();
				        break;
				    case 8:
				        RungeKutta.Menu();
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
