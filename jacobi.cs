using System;

namespace MAN_Project
{
    public class Jacobi
    {
        private static int nbX;
        private static double[,] res;
        private static int iteration;
        
        public static double[] jacobi(Matrix mat,int iter,int[] b)
        {
            // Création de la matrice et du tableau des x^(k) et intialisation de x^0 à 0
            iteration = iter;
            nbX = b.Length;
            Matrix jacobi = mat;
            double[] result = new double[nbX];
            res = new double[iter+1,nbX];
            for (int f = 0; f < nbX ;f++)
            {
                   res[0,f] = 0;
            }
            // Une première boucle pour le nombre d'itérations
            for (int k = 1; k <= iter; k++)
            {
                Console.WriteLine("Iteration "+k+" :");
                // Une deuxieme boucle pour les x^k à l'interieur de chaque itération
                for (int l = 0; l < nbX; l++)
                {
                    res[k,l] = b[l]/jacobi.data[l,l];
                    res[k,l] += -(Jacobi.somme(jacobi,l, res,k-1))/ jacobi.data[l,l];
                    Console.WriteLine("x"+(l+1)+" : "+res[k,l]);
                }
                Console.WriteLine(" -------------------------");
            }
    
            for(int i = 0; i < nbX; i++) {
                result[i] = res[iter,i];
            }   
            
            return result;

        }  

        // Fonction appelé pour faire la somme Ai,j*Xk,j 
        public static double somme(Matrix matrix,int lineNumber, double[,] tab,int k)
        {
            double sum = 0;
            double[,] localRes = new double[iteration+1,nbX];
            for(int g = 0; g < iteration+1;g++) {
                for(int f = 0; f < nbX; f++) {
                    localRes[g,f] = res[g,f];
                }
            }
            for (int i = 0,j=0; i < matrix.m; i++)
            {
                if (i != lineNumber)
                {
                    while(!(localRes[k,j] != 1054.0928475) && j < nbX || j == lineNumber && j < nbX)
                    {
                        j++;
                    }
                    sum += matrix.data[lineNumber,i] *localRes[k,j];
                    localRes[k,j] = 1054.0928475;
                    j = 0;
                }
            }
            return sum;
        }
    }
}


