using System;

namespace MAN_Project
{
    public class Cholesky
    {
        public static Matrix chol(Matrix mat){
            Matrix res = new Matrix(mat.m,mat.n);
            if(mat.IsSymetric()){
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
            }
            else {
                Console.WriteLine("La matrice n'est pas symetrique. Entrez une matrice symetrique.");
            }
            return res;
        }

        // Premier test de la fonction Cholesky
        public static void test1(){
            Matrix mat = new Matrix(0,0);
            mat.ImportMatrix("matrixes/cholesky1.txt");
            Console.WriteLine("Test avec la premiere matrice :");
            mat.PrintMatrix();
            Matrix res = chol(mat);
            Console.WriteLine("Decomposition obtenu :");
            res.PrintMatrix();
        }

        public static void test2(){
            Matrix mat = new Matrix(0,0);
            mat.ImportMatrix("matrixes/cholesky2.txt");
            Console.WriteLine("Test avec la seconde matrice :");
            mat.PrintMatrix();
            Matrix res = chol(mat);
            Console.WriteLine("Decomposition obtenu :");
            res.PrintMatrix();
        }
    }
}
