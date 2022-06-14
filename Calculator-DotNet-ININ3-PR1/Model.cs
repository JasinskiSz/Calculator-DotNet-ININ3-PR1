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
            input = "0";
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
                input = buforIO.Substring(0, buforIO.Length - 1);
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
            input += cyfra;
        }
        internal void ZmieńZnak()
        {
            if (buforIO == "0")
                return;
            if (buforIO[0] == '-')
                input = buforIO.Substring(1);
            else
                input = "-" + buforIO;
        }
        internal void Przecinek()
        {
            if (flagaUłamka)
                return;
            else if (flagComma)
            {
                input = buforIO.Substring(0, buforIO.Length - 1);
                flagComma = false;
            }
            else
            {
                input += ",";
                flagComma = true;
            }
        }

        bool
            flagComma = false,
            flagaUłamka = false
            ;
        string buforIO = "0";
        public string input
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