using System;
using System.Collections.Generic;

namespace MAN_Project
{
  public class Gauss_Seidel
  {

    public static void gauss_seidel(Matrix mat, int ite, double eps, double[] tableau_b){
      int size = mat.m;
      List<Matrix> matrixList = new List<Matrix>();
      Console.WriteLine("\nWelcome in Gauss Seidel Algorithm");  
      

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
         double o1 = 0;
         double o2 = 0;
         for(int j=0;j<i;j++)
          {
            o1 += (mat.data[i,j]*res[j,0]);
          }
          for(int j=i+1;j<size;j++)
          {
            o2 += (mat.data[i,j]*matrixList[k].data[j, 0]);
          }
        
        
          res[i,0] = (tableau_b[i] -o1 -o2);
          
          res[i,0] = (res[i,0]/mat.data[i,i]); //Bug : ce truc donne �
        
        }
        Matrix xi = new Matrix(size,1);
        xi.data = res;
        Console.WriteLine("Iteration "+k);
        xi.PrintMatrix();
        if(Double.IsNaN(xi.data[0,0]))
        {
          Console.WriteLine("NaN error --> 0");
          for(int val = 0; val<size;val++){
            xi.data[val,0]=0;
          }
        }
        matrixList.Add(xi);
      
        if(k>1)
        {
          diff=Math.Abs(matrixList[k-1].data[0, 0] - matrixList[k].data[0, 0]);
        }
      
      }

      Matrix final = matrixList[matrixList.Count-1] ;
      final.PrintMatrix();
    }

    public static void Test1() {
      Matrix mat = new Matrix(4,4);
      mat.ImportMatrix("gaussseidel.txt");
      mat.PrintMatrix();
      double[] b = {-1,2,3};
      Console.WriteLine("b : ");
      foreach(double d in b){
        Console.Write(d+" ");
      }
      gauss_seidel(mat, 2, 0.000001, b);
    }
    
  }
}









//GoT Spoil : Tyrion tue Tywin