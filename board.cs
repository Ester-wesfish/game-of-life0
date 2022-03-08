using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameOfLife
{
	class Board
	{
		public enum Status
		{
			alive,
			dead
		}
		public int row { get; set; }
		public int col { get; set; }

		public Status[,] board { get; set; }
		public Board()
		{
			row = 10;
			col = 10;
			board = new Status[row, col];

		}
		Random rnd = new Random();
		public Status[,] Randomize()
		{
			var board = new Status[row, col];
			for (int i = 0; i < row; i++)
			{
				for (int j = 0; j < col; j++)
				{
					board[i, j] = (Status)rnd.Next(0, 2);

				}
			}
			return board;
		}
		public void NextGeneration(Status[,] board)
		{

			var nextGeneration = new Status[row, col];
			for (int i = 0; i < row; i++)
			{
				for (int j = 0; j < col; j++)
				{
					var aliveNeighbors = 0;
					for (int x = -1; x <= 1; x++)
					{
						for (int y = -1; y <= 1; y++)
						{
							if (i + x >= 0 && i + x < row && j + y >= 0 && j + y < col)
							{
								aliveNeighbors += board[i + x, j + y] == Status.alive ? 1 : 0;
							}


						}
					}
					var curCell = board[i, j];
					aliveNeighbors -= curCell == Status.alive ? 1 : 0;

					if (curCell == Status.alive && aliveNeighbors < 2)
						nextGeneration[i, j] = Status.dead;
					else if (curCell == Status.alive && aliveNeighbors > 3)
						nextGeneration[i, j] = Status.dead;
					else if (curCell == Status.dead && aliveNeighbors == 3)
						nextGeneration[i, j] = Status.alive;
					else
						nextGeneration[i, j] = curCell;
				}
			}
			board = nextGeneration;
			Print(board);
		}
		public void Print(Status[,] board)
		{
			for (int i = 0; i < row; i++)
			{

				for (int j = 0; j < col; j++)
				{
					Console.Write(board[i, j] == Status.alive ? 1 : 0);

				}
				Console.Write("\n");
			}
			Thread.Sleep(500);
			Console.SetCursorPosition(0, 0);
			NextGeneration(board);
		}
	}
}
