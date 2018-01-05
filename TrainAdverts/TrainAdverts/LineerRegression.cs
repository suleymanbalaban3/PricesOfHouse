using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainAdverts
{
    class LineerRegression
    {
        public double determinant(double[,] matrix)
        {
            if (matrix.Length != matrix.GetLength(1))
            {
                throw new InvalidOperationException();
            }

            if (matrix.Length == 2)
                return matrix[0,0] * matrix[1,1] - matrix[0,1] * matrix[1,0];

            double det = 0;
            for (int i = 0; i < matrix.GetLength(1); i++)
                det += Math.Pow(-1, i) * matrix[0,i]
                        * determinant(minor(matrix, 0, i));
            return det;
        }
        public double[,] minor(double[,] matrix, int row, int column) {
		    double[,] minor = new double[matrix.Length - 1,matrix.Length - 1];

            for (int i = 0; i < matrix.GetLength(0); i++)
			    for (int j = 0; i != row && j < matrix.GetLength(1); j++)
				    if (j != column)
					    minor[i < row ? i : i - 1, j < column ? j : j - 1] = matrix[i,j];
		    return minor;
	    }
        public double[,] multiply(double[,] a, double[,] b) {
		    if (a.GetLength(1) != b.GetLength(0))
			    throw new InvalidOperationException();

		    double[,] matrix = new double[a.GetLength(0),b.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < b.GetLength(1); j++)
                {
				    double sum = 0;
                    for (int k = 0; k < a.GetLength(1); k++)
					    sum += a[i,k] * b[k,j];
				    matrix[i,j] = sum;
			    }
		    }

		    return matrix;
	    }
        public double[,] transpose(double[,] matrix) {
		    double[,] transpose = new double[matrix.GetLength(1),matrix.GetLength(0)];

            for (int i = 0; i < matrix.GetLength(0); i++)
                for (int j = 0; j < matrix.GetLength(1); j++)
				    transpose[j,i] = matrix[i,j];
		    return transpose;
	    }
        public double[,] invert(double [,] a) 
        {
            int n = a.GetLength(0);
            double [,]x = new double[n,n];
            double [,]b = new double[n,n];
            int []index = new int[n];
            for (int i=0; i<n; ++i) 
                b[i,i] = 1;
 
     // Transform the matrix into an upper triangle
            gaussian(a, index);
 
     // Update the matrix b[i][j] with the ratios stored
            for (int i=0; i<n-1; ++i)
                for (int j=i+1; j<n; ++j)
                    for (int k=0; k<n; ++k)
                        b[index[j],k]
                    	        -= a[index[j],i]*b[index[i],k];
 
     // Perform backward substitutions
            for (int i=0; i<n; ++i) 
            {
                x[n-1,i] = b[index[n-1],i]/a[index[n-1],n-1];
                for (int j=n-2; j>=0; --j) 
                {
                    x[j,i] = b[index[j],i];
                    for (int k=j+1; k<n; ++k) 
                    {
                        x[j,i] -= a[index[j],k]*x[k,i];
                    }
                    x[j,i] /= a[index[j],j];
                }
            }
            return x;
        }
 
    // Method to carry out the partial-pivoting Gaussian
    // elimination.  Here index[] stores pivoting order.
 
        public void gaussian(double [,] a, int [] index) 
        {
            int n = index.Length;
            double [] c = new double[n];
 
     // Initialize the index
            for (int i=0; i<n; ++i) 
                index[i] = i;
 
     // Find the rescaling factors, one from each row
            for (int i=0; i<n; ++i) 
            {
                double c1 = 0;
                for (int j=0; j<n; ++j) 
                {
                    double c0 = Math.Abs(a[i,j]);
                    if (c0 > c1) c1 = c0;
                }
                c[i] = c1;
            }
 
     // Search the pivoting element from each column
            int k = 0;
            for (int j=0; j<n-1; ++j) 
            {
                double pi1 = 0;
                for (int i=j; i<n; ++i) 
                {
                    double pi0 = Math.Abs(a[index[i],j]);
                    pi0 /= c[index[i]];
                    if (pi0 > pi1) 
                    {
                        pi1 = pi0;
                        k = i;
                    }
                }
 
       // Interchange rows according to the pivoting order
                int itmp = index[j];
                index[j] = index[k];
                index[k] = itmp;
                for (int i=j+1; i<n; ++i) 	
                {
                    double pj = a[index[i],j]/a[index[j],j];
 
     // Record pivoting ratios below the diagonal
                    a[index[i],j] = pj;
 
     // Modify other elements accordingly
                    for (int l=j+1; l<n; ++l)
                        a[index[i],l] -= pj*a[index[j],l];
                }
            }
        }
        public double[,] Make(double [,] x, double [,] y)
        {
            return multiply(
                multiply(invert(multiply(transpose(x), x)), transpose(x)), y);
        }
    }
}
