using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Algo_Apri_Asoc
{
    public partial class Form1 : Form
    {
        public List<List<string>> aZbior;
        public int nProgCzestosci;
        public int nProgLicznik;
        public int nProgMianownik;
        public string sLogi;
        
        public Form1()
        {
            this.aZbior = null;
            this.nProgCzestosci = 0;
            this.nProgLicznik = 0;
            this.nProgMianownik = 0;
            this.sLogi = "";
            
            InitializeComponent();
        }

        private void btnWczytaj_Click(object sender, EventArgs e)
        {
            int nRows, nCols;
            string sPath = "paragon-system.txt";
            string[] aLinie = null;
            
            if (File.Exists(sPath))
            {
                aLinie = File.ReadAllLines(sPath);
                nRows = aLinie.Length;
                nCols = aLinie[0].Split(' ').Length;

                this.aZbior = new List<List<string>>();

                string[] aElementy;
                for (int i = 0; i < nRows; i++)
                {
                    List<string> aWiersz = new List<string>();
                    aElementy = aLinie[i].Split(' ');
                    nCols = aElementy.Length;
                    for (int j = 0; j < nCols; j++)
                    {
                        if (aElementy[j] != String.Empty)
                        {
                            aWiersz.Add(aElementy[j]);
                        }
                    }
                    if (aWiersz.Count > 0)
                    {
                        this.aZbior.Add(aWiersz);
                    }
                }
            }
            else
            {
                MessageBox.Show("Brak pliku paragon-system.txt");
            }

            if (this.aZbior.Count <= 0)
            {
                MessageBox.Show("Plik paragon-system.txt jest pusty lub posiada nieodpowiedni format danych.");
            }
            else
            {
                this.rtxtLogi.Text = "";
                this.rtxtWynik.Text = "";
                this.rtxtWczytany.Text = WypiszZbior(this.aZbior);
                btnLicz.Enabled = true;
            }
            
            return;
        }

        private string WypiszZbior(List<List<string>> aZbior)
        {
            string sZbior = "";

            foreach (List<string> aRow in aZbior)
            {
                foreach (string item in aRow)
                {
                    sZbior += item + " ";
                }
                sZbior += "\r\n";
            }

            return sZbior;
        }

        private void btnLicz_Click(object sender, EventArgs e)
        {
            if (this.nProgCzestosci == 0)
            {
                MessageBox.Show("Ustaw Próg Częstości!");
                return;
            }

            if (this.nProgLicznik == 0 || this.nProgMianownik == 0)
            {
                MessageBox.Show("Ustaw Próg!");
                return;
            }

            this.rtxtWynik.Text = "";
            this.rtxtLogi.Text = "";
            this.sLogi = "";

            List<Zbior> aZbioryF = AlgoApriori();

            if (aZbioryF.Count == 0)
            {
                MessageBox.Show("Nie znaleziono żadnych zbiorów algorytmem Apriori!");
                return;
            }
            
            // REGUŁY ASUCJACYJNE

            List<string> aReguly = new List<string>();
            for (int k = aZbioryF.Count - 1; k > 0; k--)
            {
                this.sLogi += "Ze zbioru F" + aZbioryF[k].nNumer + " mamy:\r\n";

                foreach (string zbior in aZbioryF[k].aZbior)
                {
                    List<string> aElementy = zbior.Split(' ').ToList();
                    var aPodzbiory = GetPermutations(aElementy, k);

                    foreach (var perm in aPodzbiory)
                    {
                        // konwersja na zbior przedstawiony w postaci "a ^ b ^ c" a nie {a} {b} {c}
                        string sShowPerm = "";
                        
                        foreach (var item in perm)
                        {
                            sShowPerm += item;

                            if (item != perm.Last())
                                sShowPerm += " ^ ";
                        }

                        sShowPerm += " => ";

                        //brakujacy element
                        string sBrakujacy = "";
                        foreach (string item in aElementy)
                        {
                            if (!perm.Contains(item))
                            {
                                sBrakujacy = item;
                            }
                        }

                        sShowPerm += sBrakujacy;

                        //roznica miedzy logami a wynikiem wiec zrzuc sShowPerm do logow
                        this.sLogi += sShowPerm;

                        double wsp = WyliczWsp(perm, sBrakujacy);
                        this.sLogi += " wsp = " + wsp;

                        double ufn = WyliczUfn(perm, sBrakujacy);
                        this.sLogi += ", ufn = " + ufn;

                        double prog = Math.Round(wsp * ufn, 2);
                        sShowPerm += ", wsp * ufn = " + prog; 
                        this.sLogi += ", wsp * ufn = " + prog;

                        this.sLogi += "\r\n";
                       
                        if (prog >= Math.Round(this.nProgLicznik / (float)this.nProgMianownik, 2))
                        {
                            aReguly.Add(sShowPerm);
                        }
                    }
                }
                this.sLogi += "\r\n";
            }

            this.rtxtLogi.Text = this.sLogi;

            string sWynik = "";
            //Generowanie Wyniku
            foreach (string item in aReguly)
            {
                sWynik += "- " + item + "\r\n";
            }
            this.rtxtWynik.Text = sWynik;

            return;
        }

        private double WyliczWsp(IEnumerable<string> zbior, string sBrakujacy)
        {
            double wsp = 0;

            int CoverObjD = 0;
            int AllObjD = this.aZbior.Count;

            bool lSpenia;
            foreach (List<string> Obj in this.aZbior)
            {
                lSpenia = true;
                foreach (string element in zbior)
                {
                    if (!Obj.Contains(element))
                    {
                        lSpenia = false;
                        break;
                    }
                }

                if (lSpenia && Obj.Contains(sBrakujacy))
                {
                    CoverObjD++;
                }
            }

            wsp = Math.Round(CoverObjD / (float)AllObjD, 2);

            return wsp;
        }

        private double WyliczUfn(IEnumerable<string> zbior, string sBrakujacy)
        {
            double ufn = 0;

            int CoverObjD = 0;
            int PopObj = 0;
            bool lSpenia;

            foreach (List<string> Obj in this.aZbior)
            {
                lSpenia = true;
                
                foreach (string element in zbior)
                {
                    if (!Obj.Contains(element))
                    {
                        lSpenia = false;
                        break;
                    }
                }

                if (lSpenia)
                {
                    PopObj++;
                    if (Obj.Contains(sBrakujacy))
                    {
                        CoverObjD++;
                    }
                }
            }
            
            ufn = Math.Round(CoverObjD / (float)PopObj, 2);

            return ufn;
        }

        private List<Zbior> AlgoApriori()
        {

            List<Zbior> aZbioryF = new List<Zbior>();
            Zbior F = new Zbior();

            this.sLogi += "Zbiór F1: {";
            foreach (List<string> aRow in this.aZbior)
            {
                foreach (string item in aRow)
                {

                    if (!F.aZbior.Contains(item) && ZbiorSpelniaProgCZ(item))
                    {
                        F.aZbior.Add(item);
                        this.sLogi += "{" + item + "},";
                    }
                }
            }
            this.sLogi += "}\r\n";

            this.sLogi += "Sortujemy F1.\r\n\r\n";
            F.aZbior.Sort();
            aZbioryF.Add(F);

            // k = 2
            F = new Zbior();
            this.sLogi += "Zbiór F2: {";
            foreach (string item1 in aZbioryF.Last().aZbior)
            {
                foreach (string item2 in aZbioryF.Last().aZbior)
                {
                    if (item1 != item2 && !F.aZbior.Contains(item1 + " " + item2) && !F.aZbior.Contains(item2 + " " + item1) && ZbiorSpelniaProgCZ(item1 + " " + item2))
                    {
                        F.aZbior.Add(item1 + " " + item2);
                        this.sLogi += "{" + item1 + ", " + item2 + "}, ";
                    }
                }
            }
            this.sLogi += "}\r\n\r\n";
            aZbioryF.Add(F);

            //k > 3 ++
            int k = 3;

            while (aZbioryF.Last().aZbior.Count > 1)
            {

                Zbior C = new Zbior(true);
                this.sLogi += "Zbiór kandydatow: {";
                foreach (string item1 in aZbioryF.Last().aZbior)
                {
                    foreach (string item2 in aZbioryF.Last().aZbior)
                    {
                        if (item1 == item2)
                            continue;

                        bool lRowne = true;
                        string sArgumenty = "";
                        string[] aItem1 = item1.Split(' ');
                        string[] aItem2 = item2.Split(' ');

                        for (int i = 0; i < k - 2; i++)
                        {
                            if (aItem1[i] != aItem2[i])
                            {
                                lRowne = false;
                                break;
                            }

                            if (sArgumenty != "")
                                sArgumenty += ' ';

                            sArgumenty += aItem1[i];
                        }

                        if (lRowne)
                        {
                            for (int i = k - 2; i < k - 1; i++)         // k-1 bo liczymy od zera
                            {
                                sArgumenty += ' ' + aItem1[i];
                                sArgumenty += ' ' + aItem2[i];
                            }

                            //sprawdzamy czy juz nie mamy tych elementow
                            bool lJest = false;
                            foreach (string zbior in C.aZbior)
                            {
                                foreach (string elem in sArgumenty.Split(' '))
                                {
                                    lJest = true;
                                    if (!zbior.Contains(elem))
                                    {
                                        lJest = false;
                                        break;
                                    }
                                }
                                if (lJest)
                                    break;
                            }

                            if (!lJest)
                            {
                                this.sLogi += "{" + sArgumenty + "}, ";
                                C.aZbior.Add(sArgumenty);
                            }
                        }
                    }
                }
                this.sLogi += "}\r\n\r\n";

                // Przeciecie własnościa Apriori
                this.sLogi += "Przecinamy zbiór kandydatów własnością Apriori.\r\n";
                List<string> aNieCzeste = new List<string>();
                foreach (string zbior in C.aZbior)
                {
                    this.sLogi += "Sprawdzamy zbiór: {" + zbior + "}\r\n";

                    List<string> aElementy = zbior.Split(' ').ToList();

                    bool lZawiera = true;
                    var aPodzbiory = GetPermutations(aElementy, k - 1);
                    foreach (var perm in aPodzbiory)
                    {
                        lZawiera = true;

                        // konwersja na zbior przedstawiony w postaci "a b c" a nie {a} {b} {c}
                        string sPerm = "";
                        foreach (var item in perm)
                        {
                            if (sPerm != "")
                                sPerm += ' ';

                            sPerm += item;
                        }

                        if (!aZbioryF.Last().aZbior.Contains(sPerm))
                        {
                            lZawiera = false;
                            this.sLogi += "- {" + sPerm + "} nie zawiera F" + (k - 1) + "\r\n";
                            break;
                        }

                        this.sLogi += "- {" + sPerm + "} zawiera F" + (k - 1) + "\r\n";
                    }

                    if (!lZawiera)
                    {
                        aNieCzeste.Add(zbior);
                    }

                }

                this.sLogi += "\r\n";

                //usuwamy ze zbioru kandydatow nie czeste
                foreach (string item in aNieCzeste)
                {
                    C.aZbior.Remove(item);
                    this.sLogi += "Zbiór (" + item + "} nie jest częsty usuwamy go ze zbioru kandydatów.\r\n";
                }

                this.sLogi += "\r\n";

                this.sLogi += "Sprawdzamu częstość pozostałych kandydatów.\r\n";
                List<string> aNieSpelnia = new List<string>();
                foreach (string zbior in C.aZbior)
                {
                    if (!ZbiorSpelniaProgCZ(zbior))
                    {
                        aNieCzeste.Add(zbior);
                        this.sLogi += "- Zbiór {" + zbior + "} nie spełnia progu częstości.\r\n";
                    }
                    this.sLogi += "- Zbiór {" + zbior + "} spełnia prog częstości.\r\n";
                }

                //usuwamy
                foreach (string item in aNieSpelnia)
                {
                    C.aZbior.Remove(item);
                }

                this.sLogi += "\r\n";

                //jezeli cos zostalo przepisujemy do F
                if (C.aZbior.Count > 0)
                {
                    F = new Zbior();
                    F.PrzepiszTempa(C);
                    aZbioryF.Add(F);
                    this.sLogi += "Zbiór F" + F.nNumer + ": {";
                    foreach (string elementy in F.aZbior)
                    {
                        string[] aElementy = elementy.Split(' ');
                        foreach (string element in aElementy)
                        {
                            this.sLogi += element;

                            if (element != aElementy.Last())
                                this.sLogi += ", ";
                        }
                    }
                    this.sLogi += "}\r\n\r\n";
                }
                else
                {
                    this.sLogi += "Ze zbioru kandydatów nie zostało żadnych elementów spełniające kryteria.";
                }

                k++;
            }

            this.sLogi += "KONIEC ALGORYTMU APRIORI\r\n\r\n";

            return aZbioryF;
        }

        private IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> items, int count)
        {
            int i = 0;
            foreach (var item in items)
            {
                if (count == 1)
                    yield return new T[] { item };
                else
                {
                    foreach (var result in GetPermutations(items.Skip(i + 1), count - 1))
                        yield return new T[] { item }.Concat(result);
                }

                ++i;
            }
        }

        private bool ZbiorSpelniaProgCZ(string sTab)
        {
            bool lCaly;
            int count = 0;

            int nRow = sTab.Split(' ').Length;
            string[] aTab = new string[nRow];
            aTab = sTab.Split(' ');

            foreach (List<string> aRow in this.aZbior)
            {
                lCaly = false;

                foreach (string item in aTab)
                {
                    if (!aRow.Contains(item))
                    {
                        lCaly = false;
                        break;
                    }

                    lCaly = true;
                }

                if (lCaly)
                {
                    count++;
                }
            }
            
            return( count >= this.nProgCzestosci );
        }

        private void btnWyjscie_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void nudProgL_ValueChanged(object sender, EventArgs e)
        {
            this.nProgLicznik = (int)this.nudProgL.Value;
        }

        private void nudProgM_ValueChanged(object sender, EventArgs e)
        {
            this.nProgMianownik = (int)this.nudProgM.Value;
        }

        private void nudProgCZ_ValueChanged(object sender, EventArgs e)
        {
            this.nProgCzestosci = (int)this.nudProgCZ.Value;
        }
    }
}
