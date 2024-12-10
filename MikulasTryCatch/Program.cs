namespace hogomb
{
	internal class Program
	{
		static void Main(string[] args)
		{
			List<string> elemek = new List<string>();
			List<int> mennyisegek = new List<int>();
			bool fut = true;
			while (fut)
			{
				try
				{
					Console.Clear();
					Console.WriteLine("\t1. Elemek hozzáadása\n\t2. Tartalom megtekintése\n\t 3. Elem eltávolítása\n\t4. Terminado");
					Console.Write("Add meg a választásod: ");
					int valasz = Convert.ToInt32(Console.ReadLine());
					switch (valasz)
					{
						case 1:
							bool futas = true;
							while (futas)
							{
								try
								{
									Console.Write("Mi az elem neve: ");
									string beker = Console.ReadLine();
									if (beker == "")
									{
										throw new Exception("A bemenet nem lehet üres.");
									}
									Console.Write("Hány darab: ");
									int menny = Convert.ToInt32(Console.ReadLine());
									Console.Write("Van még elem(i/n): ");
									char vane = Convert.ToChar(Console.ReadLine());
									if (vane == 'n')
									{
										futas = false;
									}
									elemek.Add(beker);
									mennyisegek.Add(menny);
								}
								catch (OverflowException)
								{
									Console.WriteLine("Túllépted a határt.");
								}
								catch (FormatException)
								{
									Console.WriteLine("Hiba: Rossz bemeneti formátum.");
								}
								catch (Exception ex)
								{
									Console.WriteLine($"Hiba: {ex.Message}");
								}
							}
							break;
						case 2:
							Console.WriteLine("Lista tartalma:");
							for (int i = 0; i < elemek.Count; i++)
							{
								Console.WriteLine($"{i + 1}. elem: {elemek[i]} - {mennyisegek[i]} db");
							}
							Console.ReadKey();
							break;
						case 3:
							try
							{
								Console.Write("Melyik elem eltávolítása: ");
								string bekerElem = Console.ReadLine();
								if (bekerElem == "")
								{
									throw new Exception("A bemenet nem lehet üres");
								}
								if (elemek.Contains(bekerElem))
								{
									int elemIndex = elemek.IndexOf(bekerElem);
									elemek.Remove(bekerElem);
									mennyisegek.RemoveAt(elemIndex);
									Console.WriteLine("Az elem eltávolítása megtörtént.");
									Console.ReadKey();
								}
								else
								{
									throw new Exception("A megadott elem nincs a listában.");
								}
							}
							catch (Exception ex)
							{
								Console.WriteLine($"Hiba: {ex.Message}");
							}
							break;
						case 4:
							fut = false;
							break;
						default:
							Console.WriteLine("Adj meg érvényes bemenetet.");
							break;
					}
				}
				catch (FormatException)
				{
					Console.WriteLine("Hibás bemeneti formátum.");
				}

			}
		}
	}
}