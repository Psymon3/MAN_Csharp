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
 	Matrix C = new Matrix(A.m,B.n);
 	for (int i = 0; i < A.m; i++){
 		for (int j =0; j < A.n; j++){
 			C.data[i,j] = A.data[i,j] + B.data[i,j];
 		}
 	}
	return C;
}


int determinant(matrix A) { //cette fonction est recursive
	Matrix T = new Matrix((A.m - 1), (A.m-1));
	int k = 1;
	int res;
	if A.m = 1 {return A.data[0,0];}
	else {
		for (int i = 0; i<A.m; i++) { //pour la première colonne
			for (int j = 0; j<(A.m -1); j++) {
				while (k<(A.m -1)) { // k commence à 1 -> on vire la 1e colonne
					if (j < i) { T.data[j,k] = A.data[j,k];}
					else if (j > i) { T.data[j-1,k] = A.data[j,k];}
				}
				 
			}
			res = pow(-1,i+1) * A.data[i,0] * determinant(T); //pow(-1;i+1) = (-1)^(i+1)
		}
		return res;
	}
}

matrix transposee(matrix A) {
	matrix B;
 	for (int i = 0; i < A.m; i++){
 		for (int j =0; j < A.n; j++){
 			B.data[i,j] = A.data[j,i];
 		}
 	}
 	return B;
}

matrix comatrice(matrix A) {

}

//comatrice à finir, puis inversion matrice
