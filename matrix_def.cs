
using System;

namespace MAN_Project
{
    public class Matrix
    {
        public int m; // number rows
        public int n; // number columns
        public double[,] data;

        public Matrix(int m, int n){
            this.m = m;
            this.n = n;
            this.data = new double[m,n];
        }

        public void FillMatrix(){

            Console.WriteLine("Enter the number of rows ");
            int m = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter the number of columns ");
            int n = int.Parse(Console.ReadLine());

            this.m = m;
            this.n = n;
            this.data = new double[m,n];

            for (int i=0; i<this.m; i++){
                for (int j=0; j<this.n; j++){
                    Console.WriteLine("Ligne "+(i+1)+" Colonne "+(j+1)+" ? ");
                    double val = Convert.ToDouble(Console.ReadLine());
                    this.data[i,j] = val;       
                }
            }
      }

        public void ImportMatrix(string filename) {

            string[] lines = System.IO.File.ReadAllLines(filename);

            string[] firstLine = lines[0].Split(' ');
            this.m = int.Parse(firstLine[0]);
            this.n = int.Parse(firstLine[1]);
            this.data = new double[m,n];

            for (int i=1; i<this.m+1; i++){
                string[] line = lines[i].Split(' ');
                for (int j=0; j<this.n; j++){
                    this.data[i-1,j] = Convert.ToDouble(line[j]);   
                }
            }
        }

        public void PrintMatrix(){
            Console.WriteLine("-----------------------");
            for (int i=0; i<this.m; i++){
                Console.Write("\n");
                for (int j=0; j<this.n; j++){
                    Console.Write(this.data[i,j]+"|");  
                }
            }
            Console.WriteLine("\n-----------------------");
        }

        public Matrix Multiplication(Matrix B) {
            Matrix C = new Matrix(this.m, this.n);
            for (int i = 0; i < this.m; i++){
                for (int j =0; j < this.n; j++){
                    for (int k = 0; k <this.n; k++) {
                        C.data[i,j] = C.data[i,j] + this.data[i,k]*B.data[k,j];
                    }
                }
            }
            return C;
        }

        public Matrix Add(Matrix B) {
            Matrix C = new Matrix(this.m, this.n);
            for (int i = 0; i < this.m; i++){
                for (int j =0; j < this.n; j++){
                    C.data[i,j] = this.data[i,j] + B.data[i,j];
                }
            }
            return C;
        }

        public Matrix IsSquare() {
            return this.m == this.n;
        }

        public Matrix IsSymetric() {
            for(int i=0; i < this.m; i++) {
                for(int j=0; j<this.n; j++) {
                    if(this.data[i, j] != this.data[j, i]) {
                        return false;
                    }
                }
            }
            return true;
        }

        public Matrix GetTransposed() {
            Matrix res = new Matrix(this.m, this.n);
            for(int i=0; i<this.m; i++) {
                for(int j=0; i<this.n; j++) {
                    res.data[i, j] = this.data[j, i];
                }
            }
            return res;
        }

        public Matrix CreateIdentity(int n) {
            Matrix res = new Matrix(n, n);
            for(int i=0; i<n, i++) {
                res.data[i, i] = 1;
            }
            return res;
        }

        public boolean IsDiagonal() {
            if(!this.IsSquare()) {
                return false;
            }
            boolean res = true;
            int i = 0;
            int j = 0;

            while(res && i < this.m) {
                while(res && j < this.n) {
                    if(i != j && this.data[i, j] != 0) {
                        res = false;
                    }
                    j++;
                }
                i++;
                j = 0;
            }
            return res;
        }

        /* Is there a triangle superior */
        public boolean IsTriSup() {
            boolean res = true;
            int i = 0;
            int j = 0;

            while(res && i < this.m) {
                while(res && j < this.m) {
                    if(i > j && this.data[i, j] != 0) {
                        res = false;
                    }
                    j++;
                }
                i++;
                j = 0;
            }
            return res;
        }

        /* Is there a triangle inferior */
        public boolean IsTriInf() {
            boolean res = true;
            int i = 0;
            int j = 0;

            while(res && i < this.m) {
                while(res && j < this.m) {
                    if(i < j && this.data[i, j] != 0) {
                        res = false;
                    }
                    j++;
                }
                i++;
                j = 0;
            }
            return res;
        }

        public static Matrix getSubMatrix(Matrix a, int lineTop, int lineBottom, int colLeft, int colRight) {

            int nbLines = lineBottom - lineTop;
            int nbCols = colRight - colLeft;

            Matrix res = new Matrix(nbLines, nbCols);
            int diff_lines = lineBottom - a.m;

            if(diff_lines <= 0) {
                for(int i = lineTop; i<lineBottom; i++) {
                    for(int j = colLeft; j<colRight; j++) {
                        float val = a.data[i, j];
                        res.data[i - lineTop, j - colLeft] = val;
                    }
                }
            }
            else {
                for(int i = lineTop; i<a.m; i++) {
                    for(int j = colLeft; j<colRight; j++) {
                        float val = a.data[i, j];
                        res.data[i - lineTop, j - colLeft] = val;
                    }
                }
                for(int i = 0; i<diff_lines; i++) {
                    for(int j=colLeft; j<colRight; j++) {
                        float val = a.data[i, j];
                        res.data[i + a.m - lineTop, j - colLeft] = val;
                    }
                }
            }

            return res;
        }

        public static int Determinant(Matrix a) {
            if(!a.IsSquare()) {
                return 0;
            }
            else if(a.IsDiagonal() || a.IsTriInf() || a.IsTriSup()) {
                float res = 1;
                for(int i=0; i<a.m; i++) {
                    res *= a.data[i, i];
                }
                return res;
            }
            else if(a.m == 1) {
                return a.data[0, 0];
            }
            else {
                float res = 0;
                for(int i=0; i<a.m; i++) {
                    if(i % 2 == 0) {
                        res += a.data[i, 0] * Determinant(Matrix.getSubMatrix(a, i+1, i+ a.m, 1, a.n));
                    }
                    else {
                        res -= a.data[i, 0] * Determinant(Matrix.getSubMatrix(a, i+1, i+ a.m, 1, a.n));
                    }
                }
                return res;
            }
        }
    }
}