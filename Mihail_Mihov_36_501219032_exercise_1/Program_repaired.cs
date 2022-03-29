//Реших да използвам camelCase навсякъде
//Имената на променливи и функции с българско значение и написани на латиница съм ги оставил така, за да може по-лесно да се променя кода, а да не трябва да се мислят и нови имена

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mini4ki
{
	public class Minite
	{
		public class Tochki
		{
			string ime;
			int tochki;

			public string Ime
			{
				get { return ime; }
				set { ime = value; }
			}

			public int Tochki
			{
				get { return tochki; }
				set { tochki = value; }
			}

			public tochki() { }

			public tochki(string ime, int tochki)
			{
				this.ime = ime;
				this.tochki = tochki;
			}
		}

		static void Main(string[] argumenti)
		{
			string komanda = string.Empty;
			char[,] poleto = createIgralnoPole();
			char[,] bombite = slojiBombite();
			int broyach = 0;
			bool grum = false;
			List<tochki> shampioncheta = new List<tochki>(6);
			int red = 0;
			int kolona = 0;
			bool flag = true;
			const int maks = 35;
			bool flag2 = false;

			do
			{
				if (flag)
				{
					Console.WriteLine("Hajde da igraem na “Mini4KI”. Probvaj si kasmeta da otkriesh poleteta bez mini4ki." +
					" Komanda 'top' pokazva klasiraneto, 'restart' po4va nova igra, 'exit' izliza i hajde 4ao!");
					dumpp(poleto);
					flag = false;
				}
				Console.Write("Daj red i kolona : ");
				komanda = Console.ReadLine().Trim();
				if (komanda.Length >= 3)
				{
					if (int.TryParse(komanda[0].ToString(), out red) &&
					int.TryParse(komanda[2].ToString(), out kolona) &&
						red <= poleto.GetLength(0) && kolona <= poleto.GetLength(1))
					{
						komanda = "turn";
					}
				}
				switch (komanda)
				{
					case "top":
						klasacia(shampioncheta);
						break;
					case "restart":
						poleto = createIgralnoPole();
						bombite = slojiBombite();
						dumpp(poleto);
						grum = false;
						flag = false;
						break;
					case "exit":
						Console.WriteLine("4a0, 4a0, 4a0!");
						break;
					case "turn":
						if (bombite[red, kolona] != '*')
						{
							if (bombite[red, kolona] == '-')
							{
								tiSiNaHod(poleto, bombite, red, kolona);
								broyach++;
							}
							if (maks == broyach)
							{
								flag2 = true;
							}
							else
							{
								dumpp(poleto);
							}
						}
						else
						{
							grum = true;
						}
						break;
					default:
						Console.WriteLine("\nGreshka! nevalidna Komanda\n");
						break;
				}
				if (grum)
				{
					dumpp(bombite);
					Console.Write("\nHrrrrrr! Umria gerojski s {0} to4ki. " +
						"Daj si niknejm: ", broyach);
					string niknejm = Console.ReadLine();
					tochki t = new tochki(niknejm, broyach);
					if (shampioncheta.Count < 5)
					{
						shampioncheta.Add(t);
					}
					else
					{
						for (int i = 0; i < shampioncheta.Count; i++)
						{
							if (shampioncheta[i].tochki < t.tochki)
							{
								shampioncheta.Insert(i, t);
								shampioncheta.RemoveAt(shampioncheta.Count - 1);
								break;
							}
						}
					}
					shampioncheta.Sort((tochki r1, tochki r2) => r2.ime.CompareTo(r1.ime));
					shampioncheta.Sort((tochki r1, tochki r2) => r2.tochki.CompareTo(r1.tochki));
					klasacia(shampioncheta);

					poleto = createIgralnoPole();
					bombite = slojiBombite();
					broyach = 0;
					grum = false;
					flag = true;
				}
				if (flag2)
				{
					Console.WriteLine("\nBRAVOOOS! Otvri 35 kletki bez kapka kryv.");
					dumpp(bombite);
					Console.WriteLine("Daj si imeto, batka: ");
					string imeee = Console.ReadLine();
					tochki tochkii = new tochki(imeee, broyach);
					shampioncheta.Add(tochkii);
					klasacia(shampioncheta);
					poleto = createIgralnoPole();
					bombite = slojiBombite();
					broyach = 0;
					flag2 = false;
					flag = true;
				}
			}
			while (komanda != "exit");
			Console.WriteLine("Made in Bulgaria - Uauahahahahaha!");
			Console.WriteLine("AREEEEEEeeeeeee.");
			Console.Read();
		}

		private static void klasacia(List<tochki> tochkii)
		{
			Console.WriteLine("\nTo4KI:");
			if (tochkii.Count > 0)
			{
				for (int i = 0; i < tochkii.Count; i++)
				{
					Console.WriteLine("{0}. {1} --> {2} kutii",
						i + 1, tochkii[i].ime, tochkii[i].tochki);
				}
				Console.WriteLine();
			}
			else
			{
				Console.WriteLine("prazna klasaciq!\n");
			}
		}

		private static void tiSiNaHod(char[,] POLE,
			char[,] BOMBI, int RED, int KOLONA)
		{
			char kolkoBombi = kolko(BOMBI, RED, KOLONA);
			BOMBI[RED, KOLONA] = kolkoBombi;
			POLE[RED, KOLONA] = kolkoBombi;
		}

		private static void dumpp(char[,] board)
		{
			int RRR = board.GetLength(0);
			int KKK = board.GetLength(1);
			Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
			Console.WriteLine("   ---------------------");
			for (int i = 0; i < RRR; i++)
			{
				Console.Write("{0} | ", i);
				for (int j = 0; j < KKK; j++)
				{
					Console.Write(string.Format("{0} ", board[i, j]));
				}
				Console.Write("|");
				Console.WriteLine();
			}
			Console.WriteLine("   ---------------------\n");
		}

		private static char[,] createIgralnoPole()
		{
			int boardRows = 5;
			int boardColumns = 10;
			char[,] board = new char[boardRows, boardColumns];
			for (int i = 0; i < boardRows; i++)
			{
				for (int j = 0; j < boardColumns; j++)
				{
					board[i, j] = '?';
				}
			}

			return board;
		}

		private static char[,] slojiBombite()
		{
			int redove = 5;
			int Koloni = 10;
			char[,] igralnoPole = new char[redove, koloni];

			for (int i = 0; i < redove; i++)
			{
				for (int j = 0; j < koloni; j++)
				{
					igralnoPole[i, j] = '-';
				}
			}

			List<int> r3 = new List<int>();
			while (r3.Count < 15)
			{
				Random random = new Random();
				int asfd = random.Next(50);
				if (!r3.Contains(asfd))
				{
					r3.Add(asfd);
				}
			}

			foreach (int i2 in r3)
			{
				int kol = (i2 / koloni);
				int red = (i2 % koloni);
				if (red == 0 && i2 != 0)
				{
					kol--;
					red = koloni;
				}
				else
				{
					red++;
				}
				igralnoPole[kol, red - 1] = '*';
			}

			return igralnoPole;
		}

		private static void smetki(char[,] pole)
		{
			int kol = pole.GetLength(0);
			int red = pole.GetLength(1);

			for (int i = 0; i < kol; i++)
			{
				for (int j = 0; j < red; j++)
				{
					if (pole[i, j] != '*')
					{
						char kolkoo = kolko(pole, i, j);
						pole[i, j] = kolkoo;
					}
				}
			}
		}

		private static char kolko(char[,] r, int rr, int rrr)
		{
			int brojkata = 0;
			int reds = r.GetLength(0);
			int kols = r.GetLength(1);

			if (rr - 1 >= 0)
			{
				if (r[rr - 1, rrr] == '*')
				{ 
					brojkata++; 
				}
			}
			if (rr + 1 < reds)
			{
				if (r[rr + 1, rrr] == '*')
				{ 
					brojkata++; 
				}
			}
			if (rrr - 1 >= 0)
			{
				if (r[rr, rrr - 1] == '*')
				{ 
					brojkata++;
				}
			}
			if (rrr + 1 < kols)
			{
				if (r[rr, rrr + 1] == '*')
				{ 
					brojkata++;
				}
			}
			if ((rr - 1 >= 0) && (rrr - 1 >= 0))
			{
				if (r[rr - 1, rrr - 1] == '*')
				{ 
					brojkata++; 
				}
			}
			if ((rr - 1 >= 0) && (rrr + 1 < kols))
			{
				if (r[rr - 1, rrr + 1] == '*')
				{ 
					brojkata++; 
				}
			}
			if ((rr + 1 < reds) && (rrr - 1 >= 0))
			{
				if (r[rr + 1, rrr - 1] == '*')
				{ 
					brojkata++; 
				}
			}
			if ((rr + 1 < reds) && (rrr + 1 < kols))
			{
				if (r[rr + 1, rrr + 1] == '*')
				{ 
					brojkata++; 
				}
			}
			return char.Parse(brojkata.ToString());
		}
	}
}
