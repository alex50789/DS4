using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace parcial1
{
    public class GeneradorMatrix
    {
        private int[,] _matrix;
        private Random _random;

        public GeneradorMatrix(int size)
        {
            _matrix = new int[size, size];
            _random = new Random();
        }

        public void GenerarMatrix()
        {
            int size = _matrix.GetLength(0);
            if (size % 2 == 0) // N is even
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        if (i == 0 || i == size - 1 || j == 0 || j == size - 1)
                        {
                            _matrix[i, j] = _random.Next(1, 101);
                        }
                        else
                        {
                            _matrix[i, j] = 0; // or any other default value
                        }
                    }
                }
            }
            else // N is odd
            {
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        _matrix[i, j] = _random.Next(1, 101);
                    }
                }
            }
        }

        public int[,] GetMatrix()
        {
            return _matrix;
        }

        public void ImprimirMatrix()
        {
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    Console.Write(_matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }

}
