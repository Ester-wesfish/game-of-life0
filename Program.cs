using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
	class Program
	{
		static void Main()
		{
			Board new_board = new Board();
			new_board.board = new_board.Randomize();
			new_board.Print(new_board.board);

			new_board.NextGeneration(new_board.board);

			Console.ReadLine();
		}
	}
}
