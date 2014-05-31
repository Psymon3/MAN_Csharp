using System;

namespace MAN_Project
{
  public class FactorisationLU
  {

    public static Matrix[] Factorisation(Matrix A){

	 	/*Matrix L = new Matrix(A.m, A.n);
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

		return res;*/
		Matrix L = new Matrix(A.m, A.n);
		Matrix U = new Matrix(A.m, A.n);

		for (int i = 0; i < A.n; i++){
	 		for (int j = 0; j < A.m; j++){
	 			if (i == j) { L.data[i, j] = 1.0; }
	 			else L.data[i, j] = 0.0;
	 		}
	 	}

	 	for (int i = 0; i < A.n; i++){
	 		for (int j = 0; j < A.m; j++){
	 			U.data[i, j] = A.data[i,j];
	 		}
	 	}

	 	for (int i = 0; i < (A.n-1); i++){
	 		for (int j = i; j<A.n; j++) {
	 			for (int k = 0; k < i; k++) {
	 				U.data[i,j] = A.data[i,j] - L.data.[i,k]*U.data[k,j];
	 			}
	 		}
	 		for (int j = i+1; j<A.n;j++) {
	 			for (int k = 0; k<i; k++) {
	 				L.data[j,i] = (A.data[j,i]-L.data[j,k]*U.data[k,i])/(U.data[i,i])
	 			}
	 		}
	 	}

	 	for (int k = 0; k <(A.n-1); k++) {
	 		U.data[A.n;A.n] = A.data[A.n,A.n] - L.data[A.n,k]*U.data[k,A.n];
	 	}

	 	Matrix[] res = new Matrix[2];
	 	res[0] = U;
	 	res[1] = L;

		return res;


    }

    public static void Test1() {
    	Matrix mat = new Matrix(0,0);
    	mat.ImportMatrix("factorisationLU.txt");
     	Matrix[] res = Factorisation(mat);
     	res[0].PrintMatrix();
     	res[1].PrintMatrix();
    }
    
  }
}
