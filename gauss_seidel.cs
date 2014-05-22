using System;
using System.Collections.Generic;

namespace MAN_Project
{
  public class Gauss_Seidel
  {

    public static void gauss_seidel(Matrix mat){
      int size = mat.m;
      List<Matrix> matrixList = new List<Matrix>();
      Console.WriteLine("Welcome in Gauss Seidel Algorithm");  
      Console.WriteLine("Number of iteration ?");
      int ite = int.Parse(Console.ReadLine());
      while(ite<1){
        Console.WriteLine("Nice try ! \nGoT Spoil : Tyrion tue Tywin  ");
        Console.WriteLine("Nombre d'iteration ?");
        ite = int.Parse(Console.ReadLine());
      }
      Console.WriteLine("Precision ?");
      double eps = Convert.ToDouble(Console.ReadLine());
      int[] tableau_b = new int[mat.m]; //tableau représentant b
      for (int i = 0 ; i < mat.n ; i++){
        Console.WriteLine("b values ? "+(size-i)+" values left");
        tableau_b[i] = int.Parse(Console.ReadLine()); 
      }

      double[,] f0 = new double[size,1]; 
      for(int i=0;i<size;i++)
      {
       f0[i,0]= (0);
      }

      Matrix x0 = new Matrix(size,1);
      for(int i=0;i<size;i++)
      {
       mat.data[i,0]= (0);
      }

      matrixList.Add(x0);
      double diff = 1;
      for(int k=0;diff>eps && k<ite;k++)
      {
        double[,] res = new double[size,1];
        for(int i=0;i<size;i++)
        {
         double o1 = (0);
         double o2 = (0);
         for(int j=0;j<i;j++)
          {
            o1 += (mat.data[i,j]*res[j,0]);
          }
          for(int j=i+1;j<size;j++)
          {
            o2 += (mat.data[i,j]*matrixList[k].data[j, 0]);
          }
        
        
          res[i,0] = (tableau_b[i] -o1 -o2);
        
          res[i,0] = (res[i,0]/mat.data[i,i]);
        
        }
        Matrix xi = new Matrix(size,1);
        xi.data = res;
  
      
        matrixList.Add(xi);
      
        if(k>1)
        {
          diff=Math.Abs(matrixList[k-1].data[0, 0] - matrixList[k].data[0, 0]);
        }
      
      }

      Matrix final = matrixList[matrixList.Count-1] ;
      final.PrintMatrix();
    }
    
  }
}