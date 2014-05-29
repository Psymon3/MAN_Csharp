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
      


      Matrix x0 = new Matrix(size,1);
      for(int i=0;i<size;i++)
      {
       x0.data[i,0]= (0);
      }

      matrixList.Add(x0);
      Console.WriteLine("1st matrix");
      matrixList[0].PrintMatrix();
      double diff = 1;
      double aii = mat.data[0,0];
      for(int k=0;diff>eps && k<ite;k++)
      {
        Matrix xkplus1 = new Matrix(size,1);
        for(int i=0;i<size;i++)
        {
          xkplus1.data[i,0]= (0);
        }
        double o1 = 0;
        double o2 = 0;

        for(int i = 0 ;i<size;i++){
          for(int j = 0;j!=i;j++ ){
            o1 -= (mat.data[i,j]*xkplus1.data[j,0]);
          }
          for(int j=i+1;j<size;j++){
            o2 -=  (mat.data[i,j]*matrixList[matrixList.Count-1].data[j,0]);
          }
          Console.WriteLine("o1 = "+o1+" o2 = "+o2);
          double val = (tableau_b[i]+o1+o2)/aii;
          Console.WriteLine("x"+i+"k = "+val);
          xkplus1.data[i,0]=val;
            
        }
        Console.WriteLine("iteration k = "+(k+1));
        xkplus1.PrintMatrix();
        matrixList.Add(xkplus1);
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
      double[] b = {-19,1,12,1};
      Console.WriteLine("b : ");
      foreach(double d in b){
        Console.Write(d+" ");
      }
      gauss_seidel(mat, 2, 0.0000000000000001, b);
    }    
  }
}
















//GoT Spoil : Tyrion tue Tywin