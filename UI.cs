using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.v2
{
	class UI
	{
		#region Menu
		public void StartMenu()
		{
			Console.SetCursorPosition(Console.WindowWidth / 2, 0);
			Console.WriteLine("PING-PONG");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Правила игры: ");
			Console.WriteLine("1. Игрок в чью сторону летит мяч, должен отбить мяч");
			Console.WriteLine("2. Принимающий не должен пропустить мяч за ракетку, иначе подающему засчитается одно очко");
			Console.WriteLine("3. Мач будет длиться до тех пор, пока один из игроков не получит 3 очка");
			Console.WriteLine("4. Кнопки управления первого игрока: W - Вверх | S - Вниз");
			Console.WriteLine("5. Кнопки управления второго игрока: Стрелочка вверх - Вверх | Стрелочка вних - Вниз");
		}

		public void EntryNamePlayerFirst()
		{
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine();
			Console.Write("Введите желаемое имя первого игрока: ");
		}

		public void EntryNamePlayerSecond()
		{
			Console.ForegroundColor = ConsoleColor.Cyan;
			Console.WriteLine();
			Console.Write("Введите желаемое имя второго игрока: ");
		}

		public void WaitingPressKey()
		{
			Console.ForegroundColor = ConsoleColor.Gray;
			Console.WriteLine();
			Console.WriteLine("Ожидания нажатия любой кнопки...");
			Console.ReadKey();
		}
		#endregion

		// Отображение элементов игры, таких как: мяч, платформы, счёт.
		public void PrintElementGame(int xCord, int yCord, char symbol, byte scorePlayerFirst = 0, byte scorePlayerSecond = 0)
		{
			Console.SetCursorPosition(xCord, yCord);
			Console.Write(symbol);
			// Корректировка ввыода счёта по центру, сверху
			Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 0);
			Console.WriteLine("{0}-{1}", scorePlayerFirst, scorePlayerSecond);
		}

		public void WinPlayer(string name)
		{
			Console.Clear();
			Console.SetCursorPosition(Console.WindowWidth / 2 - 1, 0);
			Console.ForegroundColor = ConsoleColor.Green;
			Console.WriteLine("Победитель: {0}", name);
			Console.ReadKey();
		}
	}
}
