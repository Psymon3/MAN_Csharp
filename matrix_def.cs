
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

        string[] lines = System.IO.File.ReadAllLines("matrix.txt");
        
        for (int i=0; i<this.m; i++){
          Console.WriteLine(lines[i]);
          string[] line = lines[i].Split(' ');
          for (int j=0; j<this.n; j++){
            this.data[i,j] = Convert.ToDouble(line[j]);   
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