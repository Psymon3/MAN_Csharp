using System;

namespace MAN_Project
{
    public class Jacobi
    {

        public static Matrix jacobi(Matrx mat)
        {
            Matrix jacobi = new Matrix(mat.m, mat.n);
            for(int i = 0; i < jacobi.m ; i++)
            {
                for(int j = 0; j < jacobi.n ; j++)
                {
                    jacobi.data[i,j] = 0.0;
                }
            }



               
        }
    }

}