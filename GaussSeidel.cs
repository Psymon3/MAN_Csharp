using System;
using System.Collections.Generic;

namespace MAN_Project
{
    public class GaussSeidel
    {

        public static void gauss_seidel(Matrix mat, int ite, double eps, double[] tableau_b){ //Algo principal de GS
            
            Matrix gs = mat;
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
            double aii = gs.data[0,0];
            for(int k=0;diff>eps && k<ite;k++)
            {
                Matrix xkplus1 = new Matrix(size,1);
                for(int i=0;i<size;i++)
                {
                    xkplus1.data[i,0]= (0);
                }
                

                for(int i = 0 ;i<size;i++){
                double o1 = 0;
                double o2 = 0;
                    for(int j = 0;j!=i;j++ ){
                        o1 += -(gs.data[i,j]*xkplus1.data[j,0]);
                     /* Console.WriteLine("-----------\n");
                        Console.WriteLine("xkplus1.data[j,0] = "+xkplus1.data[j,0]);
                        Console.WriteLine("gs.data[i,j] = "+gs.data[i,j]);
                        Console.WriteLine("i "+i+" j "+j+" o1 = "+o1);
                        Console.WriteLine("-----------\n");*/
                    }
                    for(int j=i+1;j<size;j++){
                        o2 +=    -(gs.data[i,j]*matrixList[matrixList.Count-1].data[j,0]);/*
                        Console.WriteLine("-----------\n");
                        Console.WriteLine("matrixList[matrixList.Count-1].data[j,0] "+matrixList[matrixList.Count-1].data[j,0]);
                        Console.WriteLine("gs.data[i,j] = "+gs.data[i,j]);
                        Console.WriteLine("i "+i+" j "+j+" o1 = "+o2);
                        Console.WriteLine("-----------\n");*/
                    }
                    
                    double val = (tableau_b[i]+o1+o2)/aii;
                 // Console.WriteLine("\n ----------------\n x"+i+"k+1 = "+val);
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
            Matrix mat = new Matrix(3,3);
            mat.ImportMatrix("matrixes/gaussseidel.txt");
            mat.PrintMatrix();
            double[] b = {1,1,1};
            Console.WriteLine("b : ");
            foreach(double d in b){
                Console.Write(d+" ");
            }
            gauss_seidel(mat, 2, 0.00001, b);            
        }

        public static void Test2() {
            Matrix mat2 = new Matrix(3,3);
            mat2.ImportMatrix("matrixes/gaussseidel2.txt");
            mat2.PrintMatrix();
            double[] b2 = {7,-4,9};
            Console.WriteLine("b : ");
            foreach(double d in b2){
                Console.Write(d+" ");
            }
            gauss_seidel(mat2, 3, 0.00001, b2);
        }     
        public static void UserMatrixParams(Matrix mat) { //Si l'utilisateur utilise sa propre matrice, il remplit les paramètres de GS avec cette fonction
            Console.WriteLine("Nb Iteration ?");
            int ite = int.Parse(Console.ReadLine());
            while(ite<1){
                Console.WriteLine("Nice try ! \n    ");
                Console.WriteLine("Nombre d'iteration ?");
                ite = int.Parse(Console.ReadLine());
            }
            Console.WriteLine("Precision ? (example 0,001 .... , not a .) ");
            double eps = Convert.ToDouble(Console.ReadLine());

            double[] tableau_b = new double[mat.m]; //tableau représentant b
            for (int i = 0 ; i < mat.n ; i++){
                Console.WriteLine("b values ? "+(mat.n-i)+" values left");
                tableau_b[i] = Convert.ToDouble(Console.ReadLine());
            }
         
            Console.WriteLine("b : ");
            foreach(double d in tableau_b){
                Console.Write(d+" ");
            }
            gauss_seidel(mat, ite, eps, tableau_b);
        } 
    }
}
















//GoT Spoil : Tyrion tue Tywin