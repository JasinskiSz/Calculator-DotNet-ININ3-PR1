using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Calculator_DotNet_ININ3_PR1
{
    class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string własnaNazwa = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(własnaNazwa));
        }

        internal void Zeruj()
        {
            IO = "0";
            flagComma = false;
            flagaUłamka = false;
        }
        internal void UsuńZnak()
        {
            if (buforIO.Length == 1 || buforIO == "0," || buforIO == "-0,")
                Zeruj();
            else
            {
                char usuwanyZnak = buforIO[^1];
                IO = buforIO.Substring(0, buforIO.Length - 1);
                flagComma = false;
                if (buforIO[^1] == ',')
                {
                    flagaUłamka = false;
                    flagComma = true;
                }
            }
        }
        internal void DopiszCyfrę(string cyfra)
        {
            if (buforIO == "0")
                buforIO = "";
            else if (flagComma)
            {
                flagaUłamka = true;
                flagComma = false;
            }
            IO += cyfra;
        }
        internal void ZmieńZnak()
        {
            if (buforIO == "0")
                return;
            if (buforIO[0] == '-')
                IO = buforIO.Substring(1);
            else
                IO = "-" + buforIO;
        }
        internal void Przecinek()
        {
            if (flagaUłamka)
                return;
            else if (flagComma)
            {
                IO = buforIO.Substring(0, buforIO.Length - 1);
                flagComma = false;
            }
            else
            {
                IO += ",";
                flagComma = true;
            }
        }

        bool
            flagComma = false,
            flagaUłamka = false
            ;
        string buforIO = "0";
        public string IO
        {
            get { return buforIO; }
            set
            {
                buforIO = value;
                OnPropertyChanged();
            }
        }
    }
}