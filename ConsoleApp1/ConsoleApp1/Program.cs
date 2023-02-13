


Console.WriteLine("2. feladat:");
Console.WriteLine("\t Kérem a kulcsot: [HOLD]: ");
string k = Console.ReadLine()!;
string kulcs = string.IsNullOrWhiteSpace(k) ? "HOLD" : k.ToUpper();
Console.WriteLine("\t Kérem az üzenetet: [Szeretem a csokit]: ");
string u = Console.ReadLine()!;
string uzenet = string.IsNullOrWhiteSpace(u) ? "Szeretem a csokit" : u.ToLower();

ADFGVXrejtjel adf = new(@"..\..\..\src\kodtabla.txt", uzenet, kulcs);
Console.WriteLine("5. feladat: Az átalakitott uzenet: {0}",adf.AtalakitottUzenet());
Console.WriteLine($"6.feladat: s->{adf.Betupar('s')} x->{adf.Betupar('x')}");
Console.WriteLine($"7. feladat: A kódszöveg: {adf.Kodszoveg()}");

Console.WriteLine($"8. feladat: kódolt üzenet: {adf.KodoltUzenet()}");