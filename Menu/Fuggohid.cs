using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu
{
    public class Fuggohid
    {
        public Fuggohid(int helyezes, string hidNev, string foldrajziHely, string orszag, int hidHossz, int atadasEve)
        {
            Helyezes = helyezes;
            HidNev = hidNev;
            FoldrajziHely = foldrajziHely;
            Orszag = orszag;
            HidHossz = hidHossz;
            AtadasEve = atadasEve;
        }

        public int Helyezes { get; set; }
        public string HidNev { get; set; }
        public string FoldrajziHely { get; set; }
        public string Orszag { get; set; }
        public int HidHossz { get; set; }
        public int AtadasEve { get; set; }
    }
}
