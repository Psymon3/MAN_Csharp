using System;

namespace MAN_Project
{
    public class Jacobi
    {

        public static double[] jacobi(Matrix mat,int iter,int[] b)
        {
            // Création de la matrice et du tableau des x^(k) et intialisation de x^0 à 0
            Matrix jacobi = mat;
            double[] result = new double[3];
            double[,] res = new double[jacobi.n,jacobi.n];
            for (int f = 0; f < jacobi.n ;f++)
            {
                   res[0,f] = 0;
            }

            // Une première boucle pour le nombre d'itérations
            for (int k = 1; k <= iter; k++)
            {
                // Une deuxieme boucle pour les x^k à l'interieur de chaque itération
                for (int l = 0; l < 3; l++)
                {

                    for (int i = 0; i < jacobi.m; i++)
                    {
                        for (int j = 0; j < jacobi.n; j++)
                        {

                           res[k,l] = (b[i]  - Jacobi.somme(jacobi.data,i, res[k-1,l]))/ jacobi.data[i,i];
                        }
                    }
                }
            }
            
            for(int i = 0; i < res.Length; i++) {
                result[i] = res[iter,i];
            }   
            
            return result;

        }  


        public static double somme(double[,] matrix,int lineNumber, double xik)
        {
            double sum = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                if (i != lineNumber) 
                    sum += matrix[lineNumber,i] *xik;
            }
            return sum;
        }
    }
}


