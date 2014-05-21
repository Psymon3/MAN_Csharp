using System;

namespace MAN_Project
{
  public class Gauss_Seidel
  {

    public static void gauss_seidel(Matrix mat){
      int[] tableau_m = new int[mat.m]; //tableau représentant b
      for (int i = 0 ; i < mat.n ; i++){
        Console.WriteLine("b values ? "+(mat.m-i)+" values left");
        tableau_m[i] = int.Parse(Console.ReadLine()); 
      }

      int[] tableau_x0 = new int[mat.m]; //tableau représentant la valeur x0 (généralement que des 0)
      for (int i = 0 ; i < mat.n ; i++){
        Console.WriteLine("x0 values ? "+(mat.m-i)+" values left");
        tableau_x0[i] = int.Parse(Console.ReadLine()); 
      }
     
    }
    
  }
}