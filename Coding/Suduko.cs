using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    internal class Suduko
    {
        public Suduko()
        {
            char[,] suduko = new char[,]{
                    {'.', '2', '.', '.', '9', '.', '.', '.', '.'},
                    {'8', '.', '.', '.', '.', '.', '.', '3', '5'},
                    {'.', '9', '7', '.', '.', '.', '.', '.', '6'},
                    {'.', '.', '.', '6', '8', '.', '3', '.', '1'},
                    {'7', '.', '.', '.', '.', '.', '.', '.', '.'},
                    {'.', '.', '9', '7', '4', '.', '8', '.', '.'},
                    {'.', '.', '.', '3', '.', '.', '1', '8', '.'},
                    {'.', '6', '2', '8', '.', '.', '.', '5', '.'},
                    {'.', '1', '.', '.', '.', '.', '.', '.', '.'},
                    };

            int sudukoSize = 9;

            SolveSuduko(suduko, sudukoSize);

            for (int row = 0; row < sudukoSize; row++)
            {
                for (int column = 0; column < sudukoSize; column++)
                {
                    Console.Write(suduko[row, column] + " ");
                }
                Console.WriteLine();
            }
        }

        bool SolveSuduko(char[,] suduko, int sudukoSize)
        {
            for (int row = 0; row < sudukoSize; row++)
            {
                for (int column = 0; column < sudukoSize; column++)
                {
                    if (suduko[row, column] == '.')
                    {
                        for (char placementCharacter = '1'; placementCharacter <= '9'; placementCharacter++)
                        {
                            if (isSafePlacement(placementCharacter, suduko, row, column, sudukoSize))
                            {
                                suduko[row, column] = placementCharacter;
                                if (SolveSuduko(suduko, sudukoSize))
                                {
                                    return true;
                                }
                                else
                                {
                                    suduko[row, column] = '.';
                                }
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }

        bool isSafePlacement(char placementCharacter, char[,] suduko, int row, int column, int sudukoSize)
        {
            for (int i = 0; i < sudukoSize; i++)
            {
                // To check if number exist in a complete row 
                if (suduko[row, i] == placementCharacter)
                {
                    return false;
                }
                // To check if number exist in a complete column 
                if (suduko[i, column] == placementCharacter)
                {
                    return false;
                }
                if (suduko[3 * (row / 3) + i / 3, 3 * (column / 3) + i % 3] == placementCharacter)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
