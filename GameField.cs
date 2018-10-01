using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.v2
{
	class GameField
	{

		public GameField(Platform first, Platform second, Ball ball, UI ui)
		{
			playerFirst = first;
			playerSecond = second;
			this.ball = ball;
			this.ui = ui;
		}

		public void SetInitialsPoints()
		{
			playerFirst.positionPlatform = Console.WindowHeight / 2 - playerFirst.SizePlatform / 2;

			playerSecond.positionPlatform = Console.WindowHeight / 2 - playerSecond.SizePlatform / 2;

			ball.ballPositionX = Console.WindowWidth / 2;
			ball.ballPositionY = Console.WindowHeight / 2;
		}

		public void DrawElements()
		{
			for (int y = playerFirst.positionPlatform; y < playerFirst.positionPlatform + playerFirst.SizePlatform; y++)
			{
				ui.PrintElementGame(0, y, playerFirst.SymbolPlatform);
				ui.PrintElementGame(1, y, playerFirst.SymbolPlatform);
			}
			for (int y = playerSecond.positionPlatform; y < playerSecond.positionPlatform + playerSecond.SizePlatform; y++)
			{
				ui.PrintElementGame(Console.WindowWidth - 1, y, playerSecond.SymbolPlatform);
				ui.PrintElementGame(Console.WindowWidth - 2, y, playerSecond.SymbolPlatform);
			}

			ui.PrintElementGame(ball.ballPositionX, ball.ballPositionY, ball.SymbolBall, scoreFirstPlayer, scoreSecondPlayer);
		}

		public void MoveBall()
		{
			CheckCollisionSide();

			CheckingSkipBall();

			BallPlatform();

			switch (directionBall)
			{
				case DirectionBall.Left:
					ball.ballPositionX--;
					break;
				case DirectionBall.LeftDown:
					ball.ballPositionX--;
					ball.ballPositionY++;
					break;
				case DirectionBall.LeftUp:
					ball.ballPositionX--;
					ball.ballPositionY--;
					break;
				case DirectionBall.Right:
					ball.ballPositionX++;
					break;
				case DirectionBall.RightDown:
					ball.ballPositionX++;
					ball.ballPositionY++;
					break;
				case DirectionBall.RightUp:
					ball.ballPositionX++;
					ball.ballPositionY--;
					break;
				default:
					break;
			}
		}

		public byte scoreFirstPlayer;
		public byte scoreSecondPlayer;

		private void BallPlatform()
		{
			if (ball.ballPositionX < 3)
			{
				if (ball.ballPositionY >= playerFirst.positionPlatform && ball.ballPositionY < playerFirst.positionPlatform + playerFirst.SizePlatform)
				{
					if (ball.ballPositionY == playerFirst.positionPlatform)
					{
						directionBall = DirectionBall.RightUp;
					}
					if (ball.ballPositionY == playerFirst.positionPlatform + 1)
					{
						directionBall = DirectionBall.Right;
					}
					if (ball.ballPositionY == playerFirst.positionPlatform + 2)
					{
						directionBall = DirectionBall.RightDown;
					}
					ball.OnRightBall = true;
				}
			}
			if (ball.ballPositionX >= Console.WindowWidth - 3 - 1)
			{
				if (ball.ballPositionY >= playerSecond.positionPlatform && ball.ballPositionY < playerSecond.positionPlatform + playerSecond.SizePlatform)
				{
					if (ball.ballPositionY == playerSecond.positionPlatform)
					{
						directionBall = DirectionBall.LeftUp;
					}
					if (ball.ballPositionY == playerSecond.positionPlatform + 1)
					{
						directionBall = DirectionBall.Left;
					}
					if (ball.ballPositionY == playerSecond.positionPlatform + 2)
					{
						directionBall = DirectionBall.LeftDown;
					}
					ball.OnRightBall = false;
				}
			}
		}

		private void CheckingSkipBall()
		{
			if (ball.ballPositionX == Console.WindowWidth - 1)
			{
				SetInitialsPoints();
				scoreFirstPlayer++;
				directionBall = DirectionBall.Left;
			}

			if (ball.ballPositionX == 0)
			{
				SetInitialsPoints();
				scoreSecondPlayer++;
				directionBall = DirectionBall.Right;
			}
		}

		private void CheckCollisionSide()
		{
			if (ball.ballPositionY == 0 && ball.OnRightBall == true)
			{
				directionBall = DirectionBall.RightDown;
			}
			else
			{
				if (ball.ballPositionY == 0 && ball.OnRightBall == false)
				{
					directionBall = DirectionBall.LeftDown;
				}
			}
			if (ball.ballPositionY == Console.WindowHeight - 1 && ball.OnRightBall == true)
			{
				directionBall = DirectionBall.RightUp;
			}
			else
			{
				if (ball.ballPositionY == Console.WindowHeight - 1 && ball.OnRightBall == false)
				{
					directionBall = DirectionBall.LeftUp;
				}
			}
		}

		private UI ui;
		private Platform playerFirst;
		private Platform playerSecond;
		private Ball ball;
		private DirectionBall directionBall;
	}
}
