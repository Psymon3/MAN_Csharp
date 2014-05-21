using System;

namespace MAN_Project
{
    public class Jacobi
    {

        public static Matrix jacobi(Matrix mat)
        {
            Matrix jacobi = new Matrix(mat.m, mat.n); //paye ton nomage de variable : la matrice s'apelle comme la méthode ^^
            for(int i = 0; i < jacobi.m ; i++)
            {
                for(int j = 0; j < jacobi.n ; j++)
                {
                    jacobi.data[i,j] = 0.0;
                }
            }  
            return jacobi;      
        }
    }

}