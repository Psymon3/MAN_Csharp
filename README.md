MAN_Csharp
==========

Projet de ENSIIE-MAN en C# 


Compilation: `gmcs -out:main.exe *.cs`<br />
Execution: `./main.exe [filename]`

Si un fichier est passé en paramètre, le programme l'importe et crée la matrice, sinon il vous sera demandé de la créer à la main, case par case.

Format du fichier:

m n<br />
0 x x x n<br />
x x x x x<br />
x x x x x<br />
x x x x x<br />
m x x x x<br />

Menu:

1. Factorisation LU
2. Factorisation de Cholesky
3. Méthode de Jacobi
4. Méthode de Gauss-Seidel
5. Méthode de relaxation pour Jacobi
6. Méthode de relaxation pour Gauss-Seidel
7. Schéma d'Euler explicite
8. Schéma d'Euler implicite
9. Schéma de Runge-Kutta d'ordre 4


Explication Classe Matrix : 

Une matrice = un objet (Matrix) contenant un entier m (nb ligne), un entier n (nb col) et un tableau (m*n) de double "data"

Exemple de code pour remplissage de matrice : 

Matrix mat_test = new Matrix(0,0);
mat_test.fillMatrix();

////////////////////////////////////////

Pour les développeurs en herbe :


Les fonctions "void" de la classe Matrix s'appliquent sur une matrice ; exemple :

mat_test.PrintMatrix();
mat_test.ImportMatrix("nom_fichier.txt");



Les fonctions "public Matrix nomAlgo()" renvoient une matrice ; exemple :

Matrix mat_res = mat_test.Multiplication(mat_test); //pour multiplier une matrice par elle même 


//////////////////////////////////////////


