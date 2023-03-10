class ADFGVXrejtjel
{
    private char[,] Kodtabla;
    private string Uzenet;
    private string Kulcs;

    public string AtalakitottUzenet()
    {
        // 5. feladat:
        string atalakitott = Uzenet.Replace(" ", null);
        for (int i = 0; i < (atalakitott.Length % Kulcs.Length); i++)
        {
            atalakitott += "x";
        }
        return atalakitott;
    }

    public string Betupar(char k)
    {
        string[] adfgvx = { "A", "D", "F", "G", "V", "X" };
        for (int sorindex = 0; sorindex < 6; sorindex++)
        {
            for (int oszlopindex = 0; oszlopindex < 6; oszlopindex++)
            {
                if (Kodtabla[sorindex,oszlopindex] == k)
                {
                    return $"{adfgvx[sorindex]}{adfgvx[oszlopindex]}";
                }
            }
        }
        return "hiba";
    }

    public string Kodszoveg()
    {
        string betuparok = string.Empty;
        foreach (var k in AtalakitottUzenet())
        {
            betuparok += Betupar(k);
        }
        return betuparok;
    }

    public string KodoltUzenet()
    {
        string kodszoveg = Kodszoveg();
        int sorokSzama = kodszoveg.Length / Kulcs.Length;
        int oszlopokSzama = Kulcs.Length;
        char[,] m = new char[sorokSzama, oszlopokSzama];
        int index = 0;
        for (int sor = 0; sor < sorokSzama; sor++)
        {
            for (int oszlop = 0; oszlop < oszlopokSzama; oszlop++)
            {
                m[sor, oszlop] = kodszoveg[index++];
            }
        }

        string kodoltUzenet = "";
        for (char ch = 'A'; ch <= 'Z'; ch++)
        {
            int oszlopIndex = Kulcs.IndexOf(ch);
            if (oszlopIndex != -1)
            {
                for (int sorIndex = 0; sorIndex < sorokSzama; sorIndex++)
                {
                    kodoltUzenet += m[sorIndex, oszlopIndex];
                }
            }
        }
        return kodoltUzenet;
    }

    public ADFGVXrejtjel(string kodtablaFile, string uzenet, string kulcs)
    {
        Uzenet = uzenet;
        Kulcs = kulcs;

        Kodtabla = new char[6, 6];
        int sorIndex = 0;
        foreach (var sor in System.IO.File.ReadAllLines(kodtablaFile))
        {
            for (int oszlopIndex = 0; oszlopIndex < sor.Length; oszlopIndex++)
            {
                Kodtabla[sorIndex, oszlopIndex] = sor[oszlopIndex];
            }
            sorIndex++;
        }
    }
}
