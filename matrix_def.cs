
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

  			for (int i=0; i<this.m; i++){
  				for (int j=0; j<this.n; j++){
  					Console.WriteLine("Ligne "+(i+1)+" Colonne "+(j+1)+" ? ");
  					double val = Convert.ToDouble(Console.ReadLine());
  					this.data[i,j] = val;		
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