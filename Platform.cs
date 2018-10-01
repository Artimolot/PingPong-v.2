using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PingPong.v2
{
	class Platform
	{
		public Platform(string name, char symbol)
		{
			namePlatform = name;
			symbolPlatfrom = symbol;
		}

		public string NamePlatfrom
		{
			get
			{
				return namePlatform;
			}
		}

		public byte SizePlatform
		{
			get
			{
				return sizePlatform;
			}
		}

		public char SymbolPlatform
		{
			get
			{
				return symbolPlatfrom;
			}
		}

		public int MovePlayer(bool isUp)
		{
			if(isUp)
			{
				if(positionPlatform < Console.WindowHeight - sizePlatform)
				{
					positionPlatform++;
				}
			}
			else
			{
				if(positionPlatform > 0)
				{
					positionPlatform--;
				}
			}
			return positionPlatform;
		}

		
		public int positionPlatform;

		private char symbolPlatfrom;
		private byte sizePlatform = 3;
		private string namePlatform;
	}
}
