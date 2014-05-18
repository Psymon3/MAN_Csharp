(matrix, matrix) factoLU(matrix A) { //renvoie un couple de matrices

 	Matrix L = new Matrix(A.m,A.n);
 	for (int i = 0; i < A.n; i++){
 		for (int j =0; j < A.m; j++){
 			if (i == j) { L.data[i,j] = 1}
 			else L.data[i,j] = 0;
 		}
 	}

 	for (int k = 0; k < n; k++) {
	 	for (int i =k+1; i<A.m; i++) {
	 		L.data[i,k] = (A.data[i,k]/A.data[k,k])	;
	 	}

 		for (int i = k+1; i < A.n; i++){
 			for (int j =k; j < i; j++){ 
 				A.data[i,j] = A.data[i,j] - (L.data[i,j] * A.data[0,j]);
	 		}
 		}
 	}
	return (L,A);
}