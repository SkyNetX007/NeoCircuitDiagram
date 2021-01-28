using System;
using System.Collections.Generic;
using System.Text;

namespace NeoCircuitDiagram.Services
{
	class GaussianElimination
	{
		/// <summary>
		/// <paramref name="matrix"/>
		/// Gaussian elimination, meant to solve a set of linear equations.
		/// </summary>
		public static int PerformOperation(float[,] matrix, int n)
		{
			int i, j, k, c, flag = 0;

			// Performing elementary operations 
			for (i = 0; i < n; i++)
			{
				if (matrix[i, i] == 0)
				{
					c = 1;
					while ((i + c) < n && matrix[i + c, i] == 0)
						c++;
					if ((i + c) == n)
					{
						flag = 1;
						break;
					}
					for (j = i, k = 0; k <= n; k++)
					{
						float temp = matrix[j, k];
						matrix[j, k] = matrix[j + c, k];
						matrix[j + c, k] = temp;
					}
				}

				for (j = 0; j < n; j++)
				{

					// Excluding all i == j 
					if (i != j)
					{
						// Converting Matrix to reduced row 
						// echelon form(diagonal matrix) 
						float p = matrix[j, i] / matrix[i, i];
						for (k = 0; k <= n; k++)
							matrix[j, k] = matrix[j, k] - (matrix[i, k]) * p;
					}
				}
			}
			return flag;
		}
		
		// To check whether infinite solutions exists or no solution exists.
		public static int CheckConsistency(float[,] a, int n, int flag)
		{
			int i, j;
			float sum;

			// flag == 2 for infinite solution 
			// flag == 3 for NO solution 
			flag = 3;
			for (i = 0; i < n; i++)
			{
				sum = 0;
				for (j = 0; j < n; j++)
					sum = sum + a[i, j];
				if (sum == a[i, j])
					flag = 2;
			}
			return flag;
		}
	}
}
