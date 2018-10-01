using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PingPong.v2
{
	class Program
	{
		static void Main(string[] args)
		{
			UI ui = new UI();
			ui.StartMenu();

			string namePlayer;
			ui.EntryNamePlayerFirst();
			namePlayer = Console.ReadLine();
			Platform playerFirst = new Platform(namePlayer, '|');

			ui.EntryNamePlayerSecond();
			namePlayer = Console.ReadLine();
			Platform playerSecond = new Platform(namePlayer, '|');

			Ball ball = new Ball('O');

			ui.WaitingPressKey();
			Console.Clear();

			GameField game = new GameField(playerFirst, playerSecond, ball, ui);
			ConsoleKey key = ConsoleKey.Spacebar;
			game.SetInitialsPoints();

			while (game.scoreFirstPlayer < 3 && game.scoreSecondPlayer < 3)
			{
				if (Console.KeyAvailable)
				{
					key = Console.ReadKey().Key;
					switch (key)
					{
						case ConsoleKey.UpArrow:
							playerSecond.MovePlayer(false);
							break;
						case ConsoleKey.DownArrow:
							playerSecond.MovePlayer(true);
							break;
						case ConsoleKey.W:
							playerFirst.MovePlayer(false);
							break;
						case ConsoleKey.S:
							playerFirst.MovePlayer(true);
							break;
						default:
							break;
					}
				}
				game.MoveBall();
				Console.Clear();
				game.DrawElements();
				Thread.Sleep(60);
			}
			if(game.scoreFirstPlayer == 3)
			{
				ui.WinPlayer(playerFirst.NamePlatfrom);
			}
			else
			{
				ui.WinPlayer(playerSecond.NamePlatfrom);
			}
		}
	}
}
