using System;

namespace MAN_Project
{
  public class FactorisationLU
  {

    public static Matrix[] Factorisation(Matrix A){

	 	Matrix L = new Matrix(A.m, A.n);
	 	for (int i = 0; i < A.n; i++){
	 		for (int j = 0; j < A.m; j++){
	 			if (i == j) { L.data[i, j] = 1.0; }
	 			else L.data[i, j] = 0.0;
	 		}
	 	}

	 	for (int k = 0; k < (A.n - 1); k++) {

		 	for (int i = k+1; i<A.m; i++) {
		 		L.data[i, k] = (A.data[i, k]/A.data[k, k])	;
		 	}

	 		for (int h = k+1; h < A.n; h++){
	 			for (int j = k; j < h; j++){ 
	 				A.data[h, j] = A.data[h, j] - (L.data[h, j] * A.data[j, j]);
		 		}
	 		}
	 	}

	 	Matrix[] res = new Matrix[2];
	 	res[0] = A;
	 	res[1] = L;

		return res;

    }

    public static void Test1() {
    	Matrix mat = new Matrix(0,0);
    	mat.ImportMatrix("matrixes/factorisationLU.txt");
     	Matrix[] res = Factorisation(mat);
     	res[0].PrintMatrix();
     	res[1].PrintMatrix();
    }
    
  }
}