using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coding
{
    internal class NQueens
    {
        public NQueens()
        {
            int boardSize = 4;

            List<List<string>> queenPostions = new List<List<string>>();

            char[,] chessBoard = new char[boardSize, boardSize];

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    chessBoard[i, j] = '.';
                }
            }

            GetQueenPostions(boardSize, ref queenPostions, ref chessBoard, 0);

            int[] leftRow = new int[boardSize];
            int[] upperDiagonal = new int[2 * boardSize - 1];
            int[] lowerDiagonal = new int[2 * boardSize - 1];

            GetQueenPostionsII(ref leftRow, ref upperDiagonal, ref lowerDiagonal, boardSize, ref queenPostions, ref chessBoard, 0);

            foreach (var position in queenPostions)
            {
                foreach (var row in position)
                {
                    Console.WriteLine(row);
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Time complexity it is exponential in nature, since we trying out all the ways. 
        /// Time complexity = N!xN
        /// Space complexity = O(N^2)
        /// </summary>
        void GetQueenPostions(int boardSize, ref List<List<string>> queenPostions, ref char[,] chessboard, int column)
        {
            if (column == boardSize)
            {
                queenPostions.Add(ConstructString(chessboard, boardSize));
                return;
            }

            for (int row = 0; row < boardSize; row++)
            {
                if (isSafePlacement(chessboard, row, column, boardSize))
                {
                    chessboard[row, column] = 'Q';
                    GetQueenPostions(boardSize, ref queenPostions, ref chessboard, column + 1);
                    chessboard[row, column] = '.';
                }
            }
        }

        bool isSafePlacement(char[,] chessboard, int row, int column, int boardSize)
        {
            int rowCopy = row;
            int columnCopy = column;

            // Left horizontal check
            while (column >= 0)
            {
                if (chessboard[row, column] == 'Q')
                {
                    return false;
                }
                column--;
            }

            // Upper diagonal check
            row = rowCopy;
            column = columnCopy;

            while (row >= 0 && column >= 0)
            {
                if (chessboard[row, column] == 'Q')
                {
                    return false;
                }
                row--;
                column--;
            }

            // Lower diagonal check

            row = rowCopy;
            column = columnCopy;

            while (row < boardSize && column >= 0)
            {
                if (chessboard[row, column] == 'Q')
                {
                    return false;
                }
                row++;
                column--;
            }

            return true;
        }

        List<string> ConstructString(char[,] chessboard, int boardSize)
        {
            List<string> result = new List<string>();
            char[] formedString = new char[boardSize];

            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    formedString[j] = chessboard[i, j];
                }
                result.Add(new string(formedString));

            }
            return result;
        }

        void GetQueenPostionsII(ref int[] leftRow, ref int[] upperDiagonal, ref int[] lowerDiagonal, int boardSize, ref List<List<string>> queenPostions, ref char[,] chessboard, int column)
        {
            if (column == boardSize)
            {
                queenPostions.Add(ConstructString(chessboard, boardSize));
                return;
            }

            for (int row = 0; row < boardSize; row++)
            {
                if (leftRow[row] != 1 && upperDiagonal[row + column] != 1 && lowerDiagonal[(boardSize - 1) + (column - row)] != 1)
                {
                    chessboard[row, column] = 'Q';
                    leftRow[row] = 1;
                    upperDiagonal[row + column] = 1;
                    lowerDiagonal[(boardSize - 1) + (column - row)] = 1;
                    GetQueenPostionsII(ref leftRow, ref upperDiagonal, ref lowerDiagonal, boardSize, ref queenPostions, ref chessboard, column + 1);
                    chessboard[row, column] = '.';
                    leftRow[row] = 0;
                    upperDiagonal[row + column] = 0;
                    lowerDiagonal[(boardSize - 1) + (column - row)] = 0;
                }
            }
        }
    }
}
