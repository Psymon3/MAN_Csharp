using System;

namespace MAN_Project
{
    public class Jacobi
    {
<<<<<<< HEAD
<<<<<<< HEAD

<<<<<<< HEAD
=======
>>>>>>> 653fc96839b1743f3e604eb60c57d69d4a847c70
=======
<<<<<<< HEAD
>>>>>>> parent of a5fe9c7... Merci pour les conflits sur jacobi
        public double[,] Matrix jacobi(Matrx mat,int inter,int[] b)
=======
        public Matrix jacobi(Matrix mat,int iter,int[] b)
>>>>>>> 785e8bd5a17d9895a1c07fc7b7b1e5e68ff2f739
        {
            // Cr�ation de la matrice et du tableau des x^(k) et intialisation de x^0 � 0
            Matrix jacobi = new Matrix(mat.m, mat.n);
            //double[,] res = new double[jacobi.n,jacobi.n];
            for (int f = 0; f < jacobi.n ;f++)
            {
                   // res[0][f] = 0.0;
            }
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

        public static Matrix jacobi(Matrix mat)
        {
            Matrix jacobi = new Matrix(mat.m, mat.n); 

=======
        }
        public static Matrix jacobi(Matrix mat)
        {
            Matrix jacobi = new Matrix(mat.m, mat.n); //paye ton nomage de variable : la matrice s'apelle comme la méthode ^^
>>>>>>> 653fc96839b1743f3e604eb60c57d69d4a847c70
=======
=======
        public static Matrix jacobi(Matrix mat)
        {
            Matrix jacobi = new Matrix(mat.m, mat.n); //paye ton nomage de variable : la matrice s'apelle comme la méthode ^^
>>>>>>> 83c5664ddf626353c7b7fdc083f849ecc301cbd9
>>>>>>> parent of a5fe9c7... Merci pour les conflits sur jacobi
=======
        
>>>>>>> 785e8bd5a17d9895a1c07fc7b7b1e5e68ff2f739
            for(int i = 0; i < jacobi.m ; i++)
            {
                for(int j = 0; j < jacobi.n ; j++)
                {
                    jacobi.data[i,j] = 0.0;
                }
<<<<<<< HEAD
<<<<<<< HEAD

=======
>>>>>>> 653fc96839b1743f3e604eb60c57d69d4a847c70
=======
>>>>>>> parent of a5fe9c7... Merci pour les conflits sur jacobi
            }

            // Une premi�re boucle pour le nombre d'it�rations
            for (int k = 1; k <= iter; k++)
            {
                // Une deuxieme boucle pour les x^k � l'interieur de chaque it�ration
                for (int l = 0; l < jacobi.n; l++)
                {

                    for (int i = 0; i < jacobi.m; i++)
                    {
                        for (int j = 0; j < jacobi.n; j++)
                        {

                          //  res[k][l] = (b[i] / jacobi.data[i][i]) - somme(jacobi[i],i, res[k - 1][l]);
                        }
                    }
                }
            }
<<<<<<< HEAD
            return res;
               
<<<<<<< HEAD
<<<<<<< HEAD

            }  
            return jacobi;      

=======
            }  
=======
            
>>>>>>> 785e8bd5a17d9895a1c07fc7b7b1e5e68ff2f739
            return jacobi;      
>>>>>>> 653fc96839b1743f3e604eb60c57d69d4a847c70
=======
=======
            }  
            return jacobi;      
>>>>>>> 83c5664ddf626353c7b7fdc083f849ecc301cbd9
>>>>>>> parent of a5fe9c7... Merci pour les conflits sur jacobi
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
<<<<<<< HEAD
}
=======
>>>>>>> 653fc96839b1743f3e604eb60c57d69d4a847c70
=======
}
>>>>>>> parent of a5fe9c7... Merci pour les conflits sur jacobi
