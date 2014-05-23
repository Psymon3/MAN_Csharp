using System;

namespace MAN_Project
{
    public class Jacobi
    {
<<<<<<< HEAD

=======
>>>>>>> 653fc96839b1743f3e604eb60c57d69d4a847c70
        public double[,] Matrix jacobi(Matrx mat,int inter,int[] b)
        {
            // Création de la matrice et du tableau des x^(k) et intialisation de x^0 à 0
            Matrix jacobi = new Matrix(mat.m, mat.n);
            double[,] res = new double[jacobi.n,jacobi.n];
            for (int f = 0; f < jacobi.n ;f++)
            {
                    res[0][f] = 0.0;
            }
<<<<<<< HEAD

        public static Matrix jacobi(Matrix mat)
        {
            Matrix jacobi = new Matrix(mat.m, mat.n); 

=======
        }
        public static Matrix jacobi(Matrix mat)
        {
            Matrix jacobi = new Matrix(mat.m, mat.n); //paye ton nomage de variable : la matrice s'apelle comme la mÃ©thode ^^
>>>>>>> 653fc96839b1743f3e604eb60c57d69d4a847c70
            for(int i = 0; i < jacobi.m ; i++)
            {
                for(int j = 0; j < jacobi.n ; j++)
                {
                    jacobi.data[i,j] = 0.0;
                }
<<<<<<< HEAD

=======
>>>>>>> 653fc96839b1743f3e604eb60c57d69d4a847c70
            }

            // Une première boucle pour le nombre d'itérations
            for (int k = 1; k <= iter; k++)
            {
                // Une deuxieme boucle pour les x^k à l'interieur de chaque itération
                for (int l = 0; l < jacobi.n; l++)
                {

                    for (i = 0; i < jacobi.m; i++)
                    {
                        for (j = 0; j < jacobi.n; j++)
                        {

                            res[k][l] = (b[i] / jacobi.data[i][i]) - somme(jacobi[i],i, res[k - 1][l]);
                        }
                    }
                }
            }
            return res;
               
<<<<<<< HEAD

            }  
            return jacobi;      

=======
            }  
            return jacobi;      
>>>>>>> 653fc96839b1743f3e604eb60c57d69d4a847c70
        }

        public double somme(double[] line,int lineNumber, double xik)
        {
            double sum = 0;
            for (int i = 0; i < line.Length; i++)
            {
                if (i != lineNumber) 
                    sum += (line[i] / line[lineNumber])*xik;
            }
            return sum;
        }
    }
}

<<<<<<< HEAD
}
=======
>>>>>>> 653fc96839b1743f3e604eb60c57d69d4a847c70
