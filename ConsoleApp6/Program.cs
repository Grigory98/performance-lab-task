using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp6
{
	public class Program
	{

		public static List<string> _tableCards;

		public static List<string> tableCards = new List<string>()
		{
			"R1", "R2", "R3", "R4", "R5", "R6", "R7", "R8", "R9", "R10",
			"G1", "G2", "G3", "G4", "G5", "G6", "G7", "G8", "G9", "G10",
			"B1", "B2", "B3", "B4", "B5", "B6", "B7", "B8", "B9", "B10",
			"W1", "W2", "W3", "W4", "W5", "W6", "W7", "W8", "W9", "W10"
		};

		public static Random rand = new Random();

		public static Dictionary<int, string[]> results = new Dictionary<int, string[]>();

		static void Main(string[] args)
		{
			while (true)
			{
				Console.Write("Command: ");
				var command = Console.ReadLine();

				var entryWord = command.Split(' ')[0];

				switch (entryWord)
				{
					case "start":
						_tableCards = new List<string>(tableCards);
						StartCommand(command);
						break;

					case "get-cards":
						GetCardsCommand(command);
						break;

					case "clear":
						tableCards = new List<string>(_tableCards);
						results.Clear();
						break;
				}
			}
		}

		public static void GetCardsCommand(string command)
		{
			var cmd = command.Split(' ');
			if (cmd.Count() == 1)
				throw new Exception("Error: Неверное количество аргументов.");
			var player = int.Parse(cmd[1]);
			Console.WriteLine(player + " " + string.Join(" ", results[player]));
		}

		public static void StartCommand(string command)
		{
			var cmd = command.Split(' ');
			if (cmd.Count() == 1)
				throw new Exception("Error: Неверное количество аргументов.");
			var cardsCount = int.Parse(cmd[1]);
			var playersCount = int.Parse(cmd[2]);

			if (cardsCount * playersCount > tableCards.Count())
				throw new Exception("Error: Произведение N и C превышает количество кард в колоде.");	

			for (int i = 1; i <= playersCount; i++)
			{
				var cardsList = new string[cardsCount];
				for (int j = 0; j < cardsCount; j++)
				{
					cardsList[j] = GetCard();
				}
				results.Add(i, cardsList);
			}
		}

		public static string GetCard()
		{
			if (tableCards.Count() == 0) return "";
			var randNumber = rand.Next(0, tableCards.Count());
			var card = tableCards[randNumber];
			tableCards.Remove(card);

			return card;
		}
	}
}
