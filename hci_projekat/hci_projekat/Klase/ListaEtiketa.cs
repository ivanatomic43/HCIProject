using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hci_projekat
{
    [Serializable]
    public class ListaEtiketa : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public bool isChecked;
        public string item;

        public ListaEtiketa() { }

        public ListaEtiketa(string item, bool isChecked = false)
        {
            this.item = item;
            this.isChecked = isChecked;
        }

        public string Item
        {
            get { return item; }
            set
            {
                item = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("Item"));
            }
        }

        public bool IsChecked
        {
            get { return isChecked; }
            set
            {
                isChecked = value;
                if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs("IsChecked"));
            }
        }
    }
}