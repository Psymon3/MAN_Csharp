using System;

namespace MAN_Project
{
  public class Cholesky
  {

    public static Matrix chol(Matrix mat){

      Matrix res = new Matrix(mat.m,mat.n);
      for (int i = 0; i < mat.n; i++){
        for (int j =0; j < mat.n; j++){
          res.data[i,j] = 0.0;
        }
      }

      for(int i = 0; i < mat.m; i++){
        for(int k = 0; k < (i+1); k++){
          double sum = 0;
          for (int j = 0; j < k; j++){
            sum += res.data[i,j] * res.data[k,j];
          }
          res.data[i,k] = (i == k) ? Math.Sqrt(mat.data[i,i]- sum) : (1.0 / res.data[k,k] * (mat.data[i,k] - sum));
        }
      }

      
      

      return res;

    }

  }
    
}