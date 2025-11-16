using System;

namespace LiburutegiApp
{
    public class Liburu
    {
        public int Id;
        public string Izenburua;
        public string Egilea;
        public int Stock;
        public decimal Prezioa;

        public Liburu()
        {
            Id = 0; Izenburua = ""; Egilea = ""; Stock = 0; Prezioa = 0m;
        }

        public void Inicializatu(int id, string izen, string eg, int stock, decimal prez)
        {
            Id = id; Izenburua = izen; Egilea = eg; Stock = stock; Prezioa = prez;
        }

        public string Laburpena()
        {
            return Id.ToString().PadLeft(3, '0') + " - " + Izenburua + " | " + Egilea + " | S:" + Stock.ToString() + " | " + Prezioa.ToString("0.00") + "€";
        }
    }

    public class Bezero
    {
        public int Id;
        public string Izena;
        public string Emaila;

        public Bezero()
        {
            Id = 0; Izena = ""; Emaila = "";
        }

        public void Inicializatu(int id, string iz, string em)
        {
            Id = id; Izena = iz; Emaila = em;
        }

        public string Laburpena()
        {
            return Id.ToString().PadLeft(3, '0') + " - " + Izena + " (" + Emaila + ")";
        }
    }

    public class Hornitzaile
    {
        public int Id;
        public string Izena;
        public string Kontaktua;

        public Hornitzaile()
        {
            Id = 0; Izena = ""; Kontaktua = "";
        }

        public void Inicializatu(int id, string iz, string ko)
        {
            Id = id; Izena = iz; Kontaktua = ko;
        }

        public string Laburpena()
        {
            return Id.ToString().PadLeft(3, '0') + " - " + Izena + " | " + Kontaktua;
        }
    }

    public class Agindua
    {
        public int Id;
        public int HornitzaileId;
        public int[] LiburuIds;
        public int[] Kantitateak;
        public int ZenbatElementu;
        public DateTime Data;

        public Agindua()
        {
            Id = 0; HornitzaileId = 0; LiburuIds = new int[0]; Kantitateak = new int[0]; ZenbatElementu = 0; Data = DateTime.Now;
        }

        public void Inicializatu(int id, int hornId)
        {
            Id = id; HornitzaileId = hornId; LiburuIds = new int[0]; Kantitateak = new int[0]; ZenbatElementu = 0; Data = DateTime.Now;
        }

        public void GehituElemento(int libId, int kop)
        {
            int n = ZenbatElementu + 1;
            int[] nl = new int[n];
            int[] nk = new int[n];
            for (int i = 0; i < ZenbatElementu; i = i + 1) { nl[i] = LiburuIds[i]; nk[i] = Kantitateak[i]; }
            nl[n - 1] = libId; nk[n - 1] = kop;
            LiburuIds = nl; Kantitateak = nk; ZenbatElementu = n;
        }

        public string Laburpena()
        {
            string s = "";
            for (int i = 0; i < ZenbatElementu; i = i + 1)
            {
                if (i == 0) s = LiburuIds[i].ToString() + "x" + Kantitateak[i].ToString();
                else s = s + ", " + LiburuIds[i].ToString() + "x" + Kantitateak[i].ToString();
            }
            return Id.ToString().PadLeft(3, '0') + " - H:" + HornitzaileId.ToString() + " - " + s + " - " + Data.ToString();
        }
    }

    public class Salmenta
    {
        public int Id;
        public int BezeroId;
        public int[] LiburuIds;
        public int[] Kantitateak;
        public int ZenbatElementu;
        public decimal Guztira;
        public DateTime Data;

        public Salmenta()
        {
            Id = 0; BezeroId = 0; LiburuIds = new int[0]; Kantitateak = new int[0]; ZenbatElementu = 0; Guztira = 0m; Data = DateTime.Now;
        }

        public void Inicializatu(int id, int bezId)
        {
            Id = id; BezeroId = bezId; LiburuIds = new int[0]; Kantitateak = new int[0]; ZenbatElementu = 0; Guztira = 0m; Data = DateTime.Now;
        }

        public void GehituElemento(int libId, int kop)
        {
            int n = ZenbatElementu + 1;
            int[] nl = new int[n];
            int[] nk = new int[n];
            for (int i = 0; i < ZenbatElementu; i = i + 1) { nl[i] = LiburuIds[i]; nk[i] = Kantitateak[i]; }
            nl[n - 1] = libId; nk[n - 1] = kop;
            LiburuIds = nl; Kantitateak = nk; ZenbatElementu = n;
        }

        public void EguneratuGuztira(decimal zenbat)
        {
            Guztira = Guztira + zenbat;
        }

        public string Laburpena()
        {
            string s = "";
            for (int i = 0; i < ZenbatElementu; i = i + 1)
            {
                if (i == 0) s = LiburuIds[i].ToString() + "x" + Kantitateak[i].ToString();
                else s = s + ", " + LiburuIds[i].ToString() + "x" + Kantitateak[i].ToString();
            }
            return Id.ToString().PadLeft(3, '0') + " - B:" + BezeroId.ToString() + " - " + s + " - " + Guztira.ToString("0.00") + "€ - " + Data.ToString();
        }
    }

    // LIBURUTEGI = array , for bakarrik
    public class Liburutegi
    {
        private Liburu[] liburuArray; private int liburuCount;
        private Bezero[] bezeroArray; private int bezeroCount;
        private Hornitzaile[] hornArray; private int hornCount;
        private Agindua[] aginduArray; private int aginduCount;
        private Salmenta[] salmentaArray; private int salmentaCount;
        private int nextLibId; private int nextBezId; private int nextHornId; private int nextAgId; private int nextSalId;

        public Liburutegi()
        {
            liburuArray = new Liburu[0]; liburuCount = 0;
            bezeroArray = new Bezero[0]; bezeroCount = 0;
            hornArray = new Hornitzaile[0]; hornCount = 0;
            aginduArray = new Agindua[0]; aginduCount = 0;
            salmentaArray = new Salmenta[0]; salmentaCount = 0;

            nextLibId = 1; nextBezId = 1; nextHornId = 1; nextAgId = 1; nextSalId = 1;

            // datu hasierako oinarrizkoak
            GehituLiburu("1984", "George Orwell", 5, 9.99m);
            GehituLiburu("Don Quijote", "Miguel de Cervantes", 3, 14.50m);
            GehituBezero("Ane", "ane@posta.eus");
            GehituHornitzaile("Erein Argit.", "600111222");
        }

        // LIBURUAK 
        public Liburu GehituLiburu(string izen, string egilea, int stock, decimal prezioa)
        {
            Liburu l = new Liburu(); l.Inicializatu(nextLibId, izen, egilea, stock, prezioa);
            Liburu[] berria = new Liburu[liburuCount + 1];
            for (int i = 0; i < liburuCount; i = i + 1) berria[i] = liburuArray[i];
            berria[liburuCount] = l; liburuArray = berria; liburuCount = liburuCount + 1; nextLibId = nextLibId + 1;
            return l;
        }

        public Liburu BilatuLiburu(int id)
        {
            for (int i = 0; i < liburuCount; i = i + 1) { if (liburuArray[i] != null && liburuArray[i].Id == id) return liburuArray[i]; }
            return null;
        }

        public Liburu[] LortuLiburuak()
        {
            Liburu[] ema = new Liburu[liburuCount];
            for (int i = 0; i < liburuCount; i = i + 1) ema[i] = liburuArray[i];
            return ema;
        }

        public bool AldatuLiburu(int id, string izen, string egilea, int stock, decimal prezio)
        {
            Liburu l = BilatuLiburu(id);
            if (l == null) return false;
            l.Izenburua = izen; l.Egilea = egilea; l.Stock = stock; l.Prezioa = prezio; return true;
        }

        public bool EzabatuLiburu(int id)
        {
            for (int i = 0; i < liburuCount; i = i + 1)
            {
                if (liburuArray[i] != null && liburuArray[i].Id == id)
                {
                    for (int j = i; j < liburuCount - 1; j = j + 1) liburuArray[j] = liburuArray[j + 1];
                    liburuArray[liburuCount - 1] = null; liburuCount = liburuCount - 1; return true;
                }
            }
            return false;
        }

        public bool AldatuStock(int id, int aldaketa)
        {
            Liburu l = BilatuLiburu(id);
            if (l == null) return false;
            l.Stock = l.Stock + aldaketa; if (l.Stock < 0) l.Stock = 0; return true;
        }

        // BEZEROAK -
        public Bezero GehituBezero(string izena, string emaila)
        {
            Bezero b = new Bezero(); b.Inicializatu(nextBezId, izena, emaila);
            Bezero[] berria = new Bezero[bezeroCount + 1];
            for (int i = 0; i < bezeroCount; i = i + 1) berria[i] = bezeroArray[i];
            berria[bezeroCount] = b; bezeroArray = berria; bezeroCount = bezeroCount + 1; nextBezId = nextBezId + 1;
            return b;
        }

        public Bezero BilatuBezero(int id)
        {
            for (int i = 0; i < bezeroCount; i = i + 1) { if (bezeroArray[i] != null && bezeroArray[i].Id == id) return bezeroArray[i]; }
            return null;
        }

        public Bezero[] LortuBezeroak()
        {
            Bezero[] ema = new Bezero[bezeroCount];
            for (int i = 0; i < bezeroCount; i = i + 1) ema[i] = bezeroArray[i];
            return ema;
        }

        public bool EzabatuBezero(int id)
        {
            for (int i = 0; i < bezeroCount; i = i + 1)
            {
                if (bezeroArray[i] != null && bezeroArray[i].Id == id)
                {
                    for (int j = i; j < bezeroCount - 1; j = j + 1) bezeroArray[j] = bezeroArray[j + 1];
                    bezeroArray[bezeroCount - 1] = null; bezeroCount = bezeroCount - 1; return true;
                }
            }
            return false;
        }

        // HORNITZAILEAK 
        public Hornitzaile GehituHornitzaile(string izena, string kontaktua)
        {
            Hornitzaile h = new Hornitzaile(); h.Inicializatu(nextHornId, izena, kontaktua);
            Hornitzaile[] berria = new Hornitzaile[hornCount + 1];
            for (int i = 0; i < hornCount; i = i + 1) berria[i] = hornArray[i];
            berria[hornCount] = h; hornArray = berria; hornCount = hornCount + 1; nextHornId = nextHornId + 1;
            return h;
        }

        public Hornitzaile BilatuHornitzaile(int id)
        {
            for (int i = 0; i < hornCount; i = i + 1) { if (hornArray[i] != null && hornArray[i].Id == id) return hornArray[i]; }
            return null;
        }

        public Hornitzaile[] LortuHornitzaileak()
        {
            Hornitzaile[] ema = new Hornitzaile[hornCount];
            for (int i = 0; i < hornCount; i = i + 1) ema[i] = hornArray[i];
            return ema;
        }

        //  AGINDUAK 
        public Agindua SortuAgindua(int hornId, int[] libIds, int[] kant)
        {
            Hornitzaile h = BilatuHornitzaile(hornId);
            if (h == null) throw new Exception("Hornitzailea ez da aurkitu.");
            Agindua a = new Agindua(); a.Inicializatu(nextAgId, hornId);
            if (libIds != null)
            {
                for (int i = 0; i < libIds.Length; i = i + 1) a.GehituElemento(libIds[i], kant[i]);
            }
            Agindua[] berria = new Agindua[aginduCount + 1];
            for (int i = 0; i < aginduCount; i = i + 1) berria[i] = aginduArray[i];
            berria[aginduCount] = a; aginduArray = berria; aginduCount = aginduCount + 1; nextAgId = nextAgId + 1;
            return a;
        }

        public Agindua[] LortuAginduak()
        {
            Agindua[] ema = new Agindua[aginduCount];
            for (int i = 0; i < aginduCount; i = i + 1) ema[i] = aginduArray[i];
            return ema;
        }

        // ---------- SALMENTAK ----------
        public Salmenta SortuSalmenta(int bezId, int[] libIds, int[] kant)
        {
            Bezero b = BilatuBezero(bezId);
            if (b == null) throw new Exception("Bezeroa ez da aurkitu.");
            if (libIds == null || libIds.Length == 0) throw new Exception("Ez da libururik aukeratu.");
            decimal guztira = 0m;
            for (int i = 0; i < libIds.Length; i = i + 1)
            {
                int lid = libIds[i]; int kop = kant[i];
                Liburu l = BilatuLiburu(lid);
                if (l == null) throw new Exception("Liburua " + lid.ToString() + " ez da aurkitu.");
                if (l.Stock < kop) throw new Exception("Ez dago nahikoa stock: " + l.Izenburua);
                decimal part = l.Prezioa * kop; guztira = guztira + part;
            }
            for (int i = 0; i < libIds.Length; i = i + 1) AldatuStock(libIds[i], -kant[i]);
            Salmenta s = new Salmenta(); s.Inicializatu(nextSalId, bezId);
            for (int i = 0; i < libIds.Length; i = i + 1) s.GehituElemento(libIds[i], kant[i]);
            s.Guztira = guztira;
            Salmenta[] berria = new Salmenta[salmentaCount + 1];
            for (int i = 0; i < salmentaCount; i = i + 1) berria[i] = salmentaArray[i];
            berria[salmentaCount] = s; salmentaArray = berria; salmentaCount = salmentaCount + 1; nextSalId = nextSalId + 1;
            return s;
        }

        public Salmenta[] LortuSalmentak()
        {
            Salmenta[] ema = new Salmenta[salmentaCount];
            for (int i = 0; i < salmentaCount; i = i + 1) ema[i] = salmentaArray[i];
            return ema;
        }

        //  OINARRIZKO ESTATISTIKA 
        public int GuztiraSalmentak() { return salmentaCount; }

        //  KONTROL ETA GARBITU 
        public void GarbituDatuak()
        {
            liburuArray = new Liburu[0]; liburuCount = 0;
            bezeroArray = new Bezero[0]; bezeroCount = 0;
            hornArray = new Hornitzaile[0]; hornCount = 0;
            aginduArray = new Agindua[0]; aginduCount = 0;
            salmentaArray = new Salmenta[0]; salmentaCount = 0;
            nextLibId = 1; nextBezId = 1; nextHornId = 1; nextAgId = 1; nextSalId = 1;
        }

        public void ImprimatuTxostenOrokorra()
        {
            Console.WriteLine("=== TXOSTENA OROKORRA (laburra) ===");
            Console.WriteLine("Liburu kop: " + liburuCount.ToString() + " | Bezero kop: " + bezeroCount.ToString() + " | Horn kop: " + hornCount.ToString() + " | Salmentak: " + salmentaCount.ToString());
            Console.WriteLine("Liburuak:");
            for (int i = 0; i < liburuCount; i = i + 1) Console.WriteLine("  " + liburuArray[i].Laburpena());
        }

        // segurtasun eta parse
        private int IntSafe(string s) { try { return int.Parse(s); } catch { return 0; } }
        private decimal DecimalSafe(string s) { try { return decimal.Parse(s); } catch { return 0m; } }
        private DateTime DateTimeParseSafe(string s) { try { return DateTime.Parse(s); } catch { return DateTime.Now; } }

        // TOP kalkulu txiki bat (sinple) 
        public int[][] KalkulatuSalmentakPerLiburu()
        {
            if (salmentaCount == 0) return new int[0][];
            
            int uniqueCount = 0;
            int[] uniqIds = new int[0];
            for (int i = 0; i < salmentaCount; i = i + 1)
            {
                Salmenta s = salmentaArray[i];
                for (int j = 0; j < s.ZenbatElementu; j = j + 1)
                {
                    int lid = s.LiburuIds[j];
                    bool found = false;
                    for (int k = 0; k < uniqueCount; k = k + 1) { if (uniqIds[k] == lid) { found = true; break; } }
                    if (!found)
                    {
                        int n = uniqueCount + 1;
                        int[] nids = new int[n];
                        for (int u = 0; u < uniqueCount; u = u + 1) nids[u] = uniqIds[u];
                        nids[n - 1] = lid; uniqIds = nids; uniqueCount = n;
                    }
                }
            }
            if (uniqueCount == 0) return new int[0][];
            int[][] pairs = new int[uniqueCount][];
            for (int i = 0; i < uniqueCount; i = i + 1)
            {
                pairs[i] = new int[2];
                pairs[i][0] = uniqIds[i]; pairs[i][1] = 0;
            }
            for (int i = 0; i < salmentaCount; i = i + 1)
            {
                Salmenta s = salmentaArray[i];
                for (int j = 0; j < s.ZenbatElementu; j = j + 1)
                {
                    int lid = s.LiburuIds[j];
                    int kopt = s.Kantitateak[j];
                    for (int k = 0; k < uniqueCount; k = k + 1)
                    {
                        if (pairs[k][0] == lid) { pairs[k][1] = pairs[k][1] + kopt; break; }
                    }
                }
            }
            // ordenatu burbuja 
            for (int a = 0; a < uniqueCount; a = a + 1)
            {
                for (int b = 0; b < uniqueCount - 1; b = b + 1)
                {
                    if (pairs[b][1] < pairs[b + 1][1])
                    {
                        int[] tmp = pairs[b]; pairs[b] = pairs[b + 1]; pairs[b + 1] = tmp;
                    }
                }
            }
            return pairs;
        }
    } 

    //  LAGUNTZAILEAK 
    public static class Laguntzaile
    {
        public static int IrakurriInt(string mezua)
        {
            Console.Write(mezua);
            string s = Console.ReadLine();
            if (s == null) return 0;
            try { return int.Parse(s); } catch { return 0; }
        }

        public static decimal IrakurriDecimal(string mezua)
        {
            Console.Write(mezua);
            string s = Console.ReadLine();
            if (s == null) return 0m;
            try { return decimal.Parse(s); } catch { return 0m; }
        }

        public static string IrakurriString(string mezua)
        {
            Console.Write(mezua);
            string s = Console.ReadLine();
            if (s == null) return "";
            return s;
        }

        public static bool BaiEz(string mezua)
        {
            Console.Write(mezua + " (bai/eze): ");
            string s = Console.ReadLine();
            if (s == null) return false;
            s = s.Trim().ToLower();
            if (s == "bai" || s == "y" || s == "yes") return true;
            return false;
        }

        public static void Itxaron()
        {
            Console.WriteLine("Sakatu ENTER jarraitzeko...");
            Console.ReadLine();
        }

        public static void Garbitu()
        {
            try { Console.Clear(); } catch { }
        }
    }

    //  APLIKAZIOA (menua eta Run)
    public class Aplikazioa
    {
        private Liburutegi lib;

        public Aplikazioa()
        {
            lib = new Liburutegi();
        }

        public void Run()
        {
            bool irten = false;
            while (!irten)
            {
                Laguntzaile.Garbitu();
                MenuNagusia();
                int auk = Laguntzaile.IrakurriInt("Aukera: ");
                switch (auk)
                {
                    case 1: Txostena(); break;
                    case 2: MenuLiburuak(); break;
                    case 3: MenuBezeroak(); break;
                    case 4: MenuHornitzaileak(); break;
                    case 5: SalmentaFluxua(); break;
                    case 6: AginduaFluxua(); break;
                    case 7: TresnakMenu(); break;
                    case 8: BilaketaEstatistikak(); break;
                    case 0: if (Laguntzaile.BaiEz("Ziur irten?")) irten = true; break;
                    default: Console.WriteLine("Aukera okerra."); Laguntzaile.Itxaron(); break;
                }
            }
            Console.WriteLine("Agur!");
        }

        void MenuNagusia()
        {
            Console.WriteLine("=== LIBURUTEGI APP ===");
            Console.WriteLine("1 - Ikusi txostena");
            Console.WriteLine("2 - Liburuak");
            Console.WriteLine("3 - Bezeroak");
            Console.WriteLine("4 - Hornitzaileak");
            Console.WriteLine("5 - Salmenta");
            Console.WriteLine("6 - Agindua");
            Console.WriteLine("7 - Tresnak");
            Console.WriteLine("8 - Bilaketak/Top");
            Console.WriteLine("0 - Irten");
        }

        void Txostena()
        {
            Laguntzaile.Garbitu();
            lib.ImprimatuTxostenOrokorra();
            Laguntzaile.Itxaron();
        }

        //  LIBURUAK MENU
        void MenuLiburuak()
        {
            bool atzera = false;
            while (!atzera)
            {
                Laguntzaile.Garbitu();
                Console.WriteLine("--- LIBURUAK ---");
                Console.WriteLine("1 - Gehitu");
                Console.WriteLine("2 - Zerrendatu");
                Console.WriteLine("3 - Bilatu IDarekin");
                Console.WriteLine("4 - Editatu");
                Console.WriteLine("5 - Ezabatu");
                Console.WriteLine("6 - Stock aldatu");
                Console.WriteLine("0 - Atzera");
                int a = Laguntzaile.IrakurriInt("Aukera: ");
                switch (a)
                {
                    case 1: GehituLiburu(); break;
                    case 2: ZerrendatuLiburuak(); break;
                    case 3: BilatuLiburuId(); break;
                    case 4: EditatuLiburu(); break;
                    case 5: EzabatuLiburu(); break;
                    case 6: StockAldatu(); break;
                    case 0: atzera = true; break;
                    default: Console.WriteLine("Aukera okerra."); Laguntzaile.Itxaron(); break;
                }
            }
        }

        void GehituLiburu()
        {
            Laguntzaile.Garbitu();
            string iz = Laguntzaile.IrakurriString("Izenburua: ");
            string eg = Laguntzaile.IrakurriString("Egilea: ");
            int st = Laguntzaile.IrakurriInt("Stock: ");
            decimal pr = Laguntzaile.IrakurriDecimal("Prezioa: ");
            Liburu l = lib.GehituLiburu(iz, eg, st, pr);
            Console.WriteLine("Gehitu da: " + l.Laburpena());
            Laguntzaile.Itxaron();
        }

        void ZerrendatuLiburuak()
        {
            Laguntzaile.Garbitu();
            Liburu[] list = lib.LortuLiburuak();
            Console.WriteLine("=== LIBURUAK ===");
            for (int i = 0; i < list.Length; i = i + 1) Console.WriteLine(list[i].Laburpena());
            Laguntzaile.Itxaron();
        }

        void BilatuLiburuId()
        {
            Laguntzaile.Garbitu();
            int id = Laguntzaile.IrakurriInt("Sartu Liburu ID: ");
            Liburu l = lib.BilatuLiburu(id);
            if (l == null) Console.WriteLine("Ez da aurkitu."); else Console.WriteLine(l.Laburpena());
            Laguntzaile.Itxaron();
        }

        void EditatuLiburu()
        {
            Laguntzaile.Garbitu();
            int id = Laguntzaile.IrakurriInt("ID: ");
            Liburu l = lib.BilatuLiburu(id);
            if (l == null) { Console.WriteLine("Ez da aurkitu."); Laguntzaile.Itxaron(); return; }
            string iz = Laguntzaile.IrakurriString("Izenburua (utzi hutsik eguneratzeko): ");
            if (iz == null || iz.Trim().Length == 0) iz = l.Izenburua;
            string eg = Laguntzaile.IrakurriString("Egilea (utzi hutsik eguneratzeko): ");
            if (eg == null || eg.Trim().Length == 0) eg = l.Egilea;
            int st = Laguntzaile.IrakurriInt("Stock: ");
            decimal pr = Laguntzaile.IrakurriDecimal("Prezioa: ");
            bool ok = lib.AldatuLiburu(id, iz, eg, st, pr);
            if (ok) Console.WriteLine("Eguneratu da."); else Console.WriteLine("Ezin izan da eguneratu.");
            Laguntzaile.Itxaron();
        }

        void EzabatuLiburu()
        {
            Laguntzaile.Garbitu();
            int id = Laguntzaile.IrakurriInt("ID: ");
            if (lib.EzabatuLiburu(id)) Console.WriteLine("Ezabatu da."); else Console.WriteLine("Errorea.");
            Laguntzaile.Itxaron();
        }

        void StockAldatu()
        {
            Laguntzaile.Garbitu();
            int id = Laguntzaile.IrakurriInt("Liburu ID: ");
            int ald = Laguntzaile.IrakurriInt("Aldaketa: ");
            if (lib.AldatuStock(id, ald)) Console.WriteLine("Stock eguneratu da."); else Console.WriteLine("Liburua ez da aurkitu.");
            Laguntzaile.Itxaron();
        }

        //  BEZEROAK MENU 
        void MenuBezeroak()
        {
            bool atzera = false;
            while (!atzera)
            {
                Laguntzaile.Garbitu();
                Console.WriteLine("--- BEZEROAK ---");
                Console.WriteLine("1 - Gehitu");
                Console.WriteLine("2 - Zerrendatu");
                Console.WriteLine("3 - Bilatu");
                Console.WriteLine("4 - Ezabatu");
                Console.WriteLine("0 - Atzera");
                int a = Laguntzaile.IrakurriInt("Aukera: ");
                switch (a)
                {
                    case 1: BezeroGehitu(); break;
                    case 2: BezeroZerrendatu(); break;
                    case 3: BezeroBilatu(); break;
                    case 4: BezeroEzabatu(); break;
                    case 0: atzera = true; break;
                    default: Console.WriteLine("Aukera okerra."); Laguntzaile.Itxaron(); break;
                }
            }
        }

        void BezeroGehitu()
        {
            Laguntzaile.Garbitu();
            string iz = Laguntzaile.IrakurriString("Izena: ");
            string em = Laguntzaile.IrakurriString("Emaila: ");
            Bezero b = lib.GehituBezero(iz, em);
            Console.WriteLine("Gehitu da: " + b.Laburpena());
            Laguntzaile.Itxaron();
        }

        void BezeroZerrendatu()
        {
            Laguntzaile.Garbitu();
            Bezero[] list = lib.LortuBezeroak();
            Console.WriteLine("=== BEZEROAK ===");
            for (int i = 0; i < list.Length; i = i + 1) Console.WriteLine(list[i].Laburpena());
            Laguntzaile.Itxaron();
        }

        void BezeroBilatu()
        {
            Laguntzaile.Garbitu();
            int id = Laguntzaile.IrakurriInt("ID: ");
            Bezero b = lib.BilatuBezero(id);
            if (b == null) Console.WriteLine("Ez da aurkitu."); else Console.WriteLine(b.Laburpena());
            Laguntzaile.Itxaron();
        }

        void BezeroEzabatu()
        {
            Laguntzaile.Garbitu();
            int id = Laguntzaile.IrakurriInt("ID: ");
            if (lib.EzabatuBezero(id)) Console.WriteLine("Ezabatu da."); else Console.WriteLine("Errorea.");
            Laguntzaile.Itxaron();
        }

        //  HORNITZAILEAK MENU 
        void MenuHornitzaileak()
        {
            bool atzera = false;
            while (!atzera)
            {
                Laguntzaile.Garbitu();
                Console.WriteLine("--- HORNITZAILEAK ---");
                Console.WriteLine("1 - Gehitu");
                Console.WriteLine("2 - Zerrendatu");
                Console.WriteLine("3 - Bilatu");
                Console.WriteLine("0 - Atzera");
                int a = Laguntzaile.IrakurriInt("Aukera: ");
                switch (a)
                {
                    case 1: HornitzaileGehitu(); break;
                    case 2: HornitzaileZerrendatu(); break;
                    case 3: HornitzaileBilatu(); break;
                    case 0: atzera = true; break;
                    default: Console.WriteLine("Aukera okerra."); Laguntzaile.Itxaron(); break;
                }
            }
        }

        void HornitzaileGehitu()
        {
            Laguntzaile.Garbitu();
            string iz = Laguntzaile.IrakurriString("Izena: ");
            string kt = Laguntzaile.IrakurriString("Kontaktua: ");
            Hornitzaile h = lib.GehituHornitzaile(iz, kt);
            Console.WriteLine("Gehitu da: " + h.Laburpena());
            Laguntzaile.Itxaron();
        }

        void HornitzaileZerrendatu()
        {
            Laguntzaile.Garbitu();
            Hornitzaile[] list = lib.LortuHornitzaileak();
            Console.WriteLine("=== HORNITZAILEAK ===");
            for (int i = 0; i < list.Length; i = i + 1) Console.WriteLine(list[i].Laburpena());
            Laguntzaile.Itxaron();
        }

        void HornitzaileBilatu()
        {
            Laguntzaile.Garbitu();
            int id = Laguntzaile.IrakurriInt("ID: ");
            Hornitzaile h = lib.BilatuHornitzaile(id);
            if (h == null) Console.WriteLine("Ez da aurkitu."); else Console.WriteLine(h.Laburpena());
            Laguntzaile.Itxaron();
        }

        //  SALMENTA FLUXUA 
        void SalmentaFluxua()
        {
            Laguntzaile.Garbitu();
            Console.WriteLine("--- SALMENTA ---");
            int bez = Laguntzaile.IrakurriInt("Bezero ID (0 -> berria): ");
            if (bez == 0)
            {
                BezeroGehitu();
                Bezero[] be = lib.LortuBezeroak();
                if (be.Length > 0) bez = be[be.Length - 1].Id;
            }
            int[] ids = new int[0]; int[] kop = new int[0]; int cnt = 0;
            while (true)
            {
                Liburu[] all = lib.LortuLiburuak();
                for (int i = 0; i < all.Length; i = i + 1) Console.WriteLine(all[i].Laburpena());
                int lid = Laguntzaile.IrakurriInt("Liburu ID (0 amaitu): ");
                if (lid == 0) break;
                int k = Laguntzaile.IrakurriInt("Kantitatea: ");
                bool aurk = false;
                for (int p = 0; p < cnt; p = p + 1) { if (ids[p] == lid) { kop[p] = kop[p] + k; aurk = true; break; } }
                if (!aurk)
                {
                    int n = cnt + 1; int[] nids = new int[n]; int[] nk = new int[n];
                    for (int u = 0; u < cnt; u = u + 1) { nids[u] = ids[u]; nk[u] = kop[u]; }
                    nids[cnt] = lid; nk[cnt] = k; ids = nids; kop = nk; cnt = n;
                }
            }
            try
            {
                Salmenta s = lib.SortuSalmenta(bez, ids, kop);
                Console.WriteLine("Salmenta sortu da: " + s.Laburpena());
            }
            catch (Exception ex) { Console.WriteLine("Errorea: " + ex.Message); }
            Laguntzaile.Itxaron();
        }

        //  AGINDUA FLUXUA 
        void AginduaFluxua()
        {
            Laguntzaile.Garbitu();
            Console.WriteLine("--- AGINDUA ---");
            Hornitzaile[] hh = lib.LortuHornitzaileak();
            for (int i = 0; i < hh.Length; i = i + 1) Console.WriteLine(hh[i].Laburpena());
            int hid = Laguntzaile.IrakurriInt("Hornitzaile ID: ");
            int[] ids = new int[0]; int[] kop = new int[0]; int cnt = 0;
            while (true)
            {
                Liburu[] all = lib.LortuLiburuak();
                for (int i = 0; i < all.Length; i = i + 1) Console.WriteLine(all[i].Laburpena());
                int lid = Laguntzaile.IrakurriInt("Liburu ID (0 amaitu): ");
                if (lid == 0) break;
                int k = Laguntzaile.IrakurriInt("Kantitatea: ");
                bool aurk = false;
                for (int p = 0; p < cnt; p = p + 1) { if (ids[p] == lid) { kop[p] = kop[p] + k; aurk = true; break; } }
                if (!aurk)
                {
                    int n = cnt + 1; int[] nids = new int[n]; int[] nk = new int[n];
                    for (int u = 0; u < cnt; u = u + 1) { nids[u] = ids[u]; nk[u] = kop[u]; }
                    nids[cnt] = lid; nk[cnt] = k; ids = nids; kop = nk; cnt = n;
                }
            }
            try
            {
                Agindua a = lib.SortuAgindua(hid, ids, kop);
                Console.WriteLine("Agindua sortu da: " + a.Laburpena());
            }
            catch (Exception ex) { Console.WriteLine("Errorea: " + ex.Message); }
            Laguntzaile.Itxaron();
        }

        // TRESNAK 
        void TresnakMenu()
        {
            bool atzera = false;
            while (!atzera)
            {
                Laguntzaile.Garbitu();
                Console.WriteLine("--- TRESNAK ---");
                Console.WriteLine("1 - Garbitu datuak");
                Console.WriteLine("0 - Atzera");
                int a = Laguntzaile.IrakurriInt("Aukera: ");
                switch (a)
                {
                    case 1:
                        if (Laguntzaile.BaiEz("Ziur datuak garbitu?")) { lib.GarbituDatuak(); Console.WriteLine("Garbitu da."); }
                        Laguntzaile.Itxaron();
                        break;
                    case 0: atzera = true; break;
                    default: Console.WriteLine("Aukera okerra."); Laguntzaile.Itxaron(); break;
                }
            }
        }

        // BILAKETA ETA TOP 
        void BilaketaEstatistikak()
        {
            bool atzera = false;
            while (!atzera)
            {
                Laguntzaile.Garbitu();
                Console.WriteLine("--- BILAKETA ETA TOP ---");
                Console.WriteLine("1 - Bilatu izenarekin");
                Console.WriteLine("2 - Ikusi top liburuak");
                Console.WriteLine("0 - Atzera");
                int a = Laguntzaile.IrakurriInt("Aukera: ");
                switch (a)
                {
                    case 1: BilatuIzenarekin(); break;
                    case 2: IkusiTopLiburuak(); break;
                    case 0: atzera = true; break;
                    default: Console.WriteLine("Aukera okerra."); Laguntzaile.Itxaron(); break;
                }
            }
        }

        void BilatuIzenarekin()
        {
            Laguntzaile.Garbitu();
            string term = Laguntzaile.IrakurriString("Terminoa: ");
            Liburu[] all = lib.LortuLiburuak();
            for (int i = 0; i < all.Length; i = i + 1)
            {
                string iz = all[i].Izenburua; if (iz == null) iz = "";
                if (IndexOfIgnoreCase(iz, term) >= 0) Console.WriteLine(all[i].Laburpena());
            }
            Laguntzaile.Itxaron();
        }

        void IkusiTopLiburuak()
        {
            Laguntzaile.Garbitu();
            int[][] pairs = lib.KalkulatuSalmentakPerLiburu();
            if (pairs == null || pairs.Length == 0) { Console.WriteLine("Ez daude salmentak."); Laguntzaile.Itxaron(); return; }
            int top = 10; if (pairs.Length < top) top = pairs.Length;
            for (int i = 0; i < top; i = i + 1)
            {
                int id = pairs[i][0]; int kop = pairs[i][1];
                Liburu l = lib.BilatuLiburu(id);
                if (l != null) Console.WriteLine(l.Laburpena() + " - " + kop.ToString());
            }
            Laguntzaile.Itxaron();
        }

        // helper: case-insensitive indexOf 
        int IndexOfIgnoreCase(string text, string term)
        {
            if (text == null || term == null) return -1;
            string lowerText = ToLower(text); string lowerTerm = ToLower(term);
            if (lowerTerm.Length == 0) return 0;
            for (int i = 0; i <= lowerText.Length - lowerTerm.Length; i = i + 1)
            {
                bool match = true;
                for (int j = 0; j < lowerTerm.Length; j = j + 1)
                {
                    if (lowerText[i + j] != lowerTerm[j]) { match = false; break; }
                }
                if (match) return i;
            }
            return -1;
        }

        string ToLower(string s)
        {
            if (s == null) return "";
            string outS = "";
            for (int i = 0; i < s.Length; i = i + 1)
            {
                char c = s[i];
                if (c >= 'A' && c <= 'Z') outS = outS + ((char)(c + 32)).ToString(); else outS = outS + c.ToString();
            }
            return outS;
        }
    } 
}
