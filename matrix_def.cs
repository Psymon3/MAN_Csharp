
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
    }
}