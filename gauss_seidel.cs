using System;

namespace MAN_Project
{
  public class Gauss_Seidel
  {

    public static void gauss_seidel(Matrix mat){
      Console.WriteLine("Welcome in Gauss Seidel Algorithm");
      int[] tableau_m = new int[mat.m]; //tableau représentant b
      for (int i = 0 ; i < mat.n ; i++){
        Console.WriteLine("b values ? "+(mat.m-i)+" values left");
        tableau_m[i] = int.Parse(Console.ReadLine()); 
      }

      int[] tableau_xk = new int[mat.m]; //tableau représentant Xk (Et rempli avec les val de X0)
      int[] tableau_xk1 = new int[mat.m]; //tableau représentant Xk+1
      for (int i = 0 ; i < mat.n ; i++){
        Console.WriteLine("x0 values ? "+(mat.m-i)+" values left");
        tableau_xk[i] = int.Parse(Console.ReadLine()); 
      }
      Console.WriteLine("Number of iteration ?");
      int nb_iter = int.Parse(Console.ReadLine());
     
    }
    
  }
}