using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using Microsoft.VisualBasic;

namespace ежедневник
{
	class Program
	{
		static void Main(string[] args)
		{
			ConsoleKeyInfo key;
			DateTime Nowdata = DateTime.Today;
			int kol = 0;
			int position1 = 0;
			int position = 11;
			List<DateTime> DataList = new List<DateTime>();
			List<string> NameList = new List<string>();
			List<string> txtList = new List<string>();
			List<string> TimeList = new List<string>();
			Menu();
			while (true)
			{
				Console.SetCursorPosition(2, 10);
				Console.WriteLine(Nowdata);
				key = Console.ReadKey();
				UpDown();
				LeftTight();

				Console.Clear();
				Menu();
				zametki();
				zapis();
				Console.SetCursorPosition(0, position);
				Console.WriteLine("->");
			}
			static void Menu()
			{
				Console.Clear();
				Console.WriteLine("Добро пожaловать в ежедневник \n" +
					"\n" +
					"Переключение по интерфейсу \n" +
					"ESC - выйти из текущей вкладки \n" +
					"ENTER - выбрать пункт \n" +
					"стрелки вверх и вниз - переключение между пункатми \n" +
					"стрелки вправо и влево - переключение между датами ");

				Console.SetCursorPosition(0, 9);
				Console.WriteLine("  Добавить заметку");
			}
			void zametki()
			{
				for (int i = 0; i < kol; ++i)
				{
					if (DataList.Count > 0)
					{
						if ((Nowdata.Year == DataList[i].Year) && (Nowdata.Month == DataList[i].Month) && (Nowdata.Day == DataList[i].Day))
						{
							position1 = 11 + i;
							Console.SetCursorPosition(2, 11 + i);
							Console.WriteLine(NameList[i]);
							if ((key.Key == ConsoleKey.Enter) && (position == 11 + i))
							{
								Console.SetCursorPosition(2, 11);
								Console.WriteLine(DataList[i]);
								Console.SetCursorPosition(2, 12);
								Console.WriteLine(NameList[i]);
								Console.SetCursorPosition(2, 13);
								Console.WriteLine(txtList[i]);
								Console.SetCursorPosition(2, 14);
								Console.WriteLine(TimeList[i]);
								Console.WriteLine("Нажмите Esc для выхода");
								key = Console.ReadKey();
								Console.Clear();
							}
						}
					}
				}
			}
			void UpDown()
			{
				if (key.Key == ConsoleKey.UpArrow)
				{
					position--;
				}
				else if (key.Key == ConsoleKey.DownArrow)
				{
					position++;
				}
			}
			void LeftTight()
			{
				if (key.Key == ConsoleKey.LeftArrow)
				{
					Nowdata = Nowdata.AddDays(-1);
				}
				if (key.Key == ConsoleKey.RightArrow)
				{
					Nowdata = Nowdata.AddDays(1);
				}
			}
			void zapis()
			{
				if ((key.Key == ConsoleKey.Enter) && (position == 9))
				{
					Console.Clear();
					Console.WriteLine("Введите дату заметки:");
					DateTime data = DateTime.Parse(Console.ReadLine());
					DataList.Add(data);

					Console.WriteLine("Введите название заметки:");
					NameList.Add(Console.ReadLine());

					Console.WriteLine("Введите текст заметки:");
					txtList.Add(Console.ReadLine());

					Console.WriteLine("Введите пометку времени заметки:");
					TimeList.Add(Console.ReadLine());
					
					Console.WriteLine("Заметка создана\nНажмите любую клавишу для выхода или Enter для добавления ещё одной заметки");
					kol += 1;
				}
			}
		}
	}
}

