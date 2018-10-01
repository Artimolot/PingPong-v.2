using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.v2
{
	class Ball
	{ 
		public Ball(char symbol)
		{
			symbolBall = symbol;
		}

		public char SymbolBall
		{
			get
			{
				return symbolBall;
			}
		}

		public int ballPositionX;
		public int ballPositionY;
		public bool OnRightBall;

		private char symbolBall;
	}

	enum DirectionBall: byte
	{
		Left,
		LeftUp,
		LeftDown,
		Right,
		RightUp,
		RightDown
	}
}
