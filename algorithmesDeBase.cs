matrix multiplication(matrix A, matrix B) {

 	Matrix C = new Matrix(A.m,b.n);
 	for (int i = 0; i < A.m; i++){
 		for (int j =0; j < A.n; j++){
 			for (int k = 0; k <A.n; k++) {
 				C.data[i,j] = C.data[i,j] + A.data[i,k]*B.data[k,j];
 			}
 		}
 	}
	return C;
}

matrix addition(matrix A, matrix B) {
 	Matrix C = new Matrix(A.m,b.n);
 	for (int i = 0; i < A.m; i++){
 		for (int j =0; j < A.n; j++){
 			C.data[i,j] = A.data[i,j] + B.data[i,j];
 		}
 	}
	return C;
}

//à rajouter éventuellement: determinant, inversion de matrice