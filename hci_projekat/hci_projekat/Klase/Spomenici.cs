using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace hci_projekat.Klase
{



    public class Spomenici : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private string _naziv;
        public string Naziv
        {
            get
            {
                return _naziv;
            }
            set
            {
                if (_naziv != value)
                {
                    _naziv = value;
                    OnPropertyChanged("Naziv");
                }
            }
        }



        public ObservableCollection<Spomenik> SpomeniciStablo
        {
            get;
            set;
        }

        public Spomenici()
        {
            SpomeniciStablo = new ObservableCollection<Spomenik>();
            // Add = new AddCommand(this);
        }








    }
}