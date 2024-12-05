using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parcial1
{
    public class SumaDeBordes
    {
        public int CalculateSum(int[,] matrix)
        {
            int sum = 0;
            int size = matrix.GetLength(0);

            // suma la primera fila
            for (int j = 0; j < size; j++)
            {
                sum += matrix[0, j];
            }

            // Suma la ultima fila
            for (int j = 0; j < size; j++)
            {
                sum += matrix[size - 1, j];
            }

            // Suma la primera columna
            for (int i = 1; i < size - 1; i++)
            {
                sum += matrix[i, 0];
            }

            // Suma la ultima columna
            for (int i = 1; i < size - 1; i++)
            {
                sum += matrix[i, size - 1];
            }

            return sum;
        }
    }
}
