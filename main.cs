
using System;

namespace MAN_Project
{
	class MainClass
	{
	    static void Main()
	    {
	        
	        Console.WriteLine("Enter the number of rows ");
			int m = int.Parse(Console.ReadLine());
			Console.WriteLine("Enter the number of columns ");
			int n = int.Parse(Console.ReadLine());
			

	        Matrix mat = new Matrix(m,n);
	        mat.FillMatrix();
	        mat.PrintMatrix();
	    }
	}
    
}