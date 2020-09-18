using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace hci_projekat.Prozori
{
    /// <summary>
    /// Interaction logic for Pretraga.xaml
    /// </summary>
    public partial class Pretraga : Window, INotifyPropertyChanged

    {

        PregledSpomenik ps;
        public string _oznaka;
        public string _naziv;
        public string _opis;
        public bool _ekoloski;
        public bool _staniste;
        public bool _region;
        public List<string> _etikete;
        public string _klima;
        public string _status;
        public string _prihod;
        public string _datum;

        private void Datum(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var picker = sender as DatePicker;
            DateTime? date = picker.SelectedDate;
            if (date == null)
            {
                this.Title = "No date";
            }
            else
            {
                _datum = date.Value.ToShortDateString();
            }
        }
        public string Oznaka
        {
            get
            {
                return _oznaka;
            }
            set
            {
                if (value != _oznaka)
                {
                    _oznaka = value;
                    OnPropertyChanged("Oznaka");
                }
            }
        }

        public string Naziv
        {
            get
            {
                return _naziv;
            }
            set
            {
                if (value != _naziv)
                {
                    _naziv
                        = value;
                    OnPropertyChanged("Naziv");
                }
            }
        }

        public string Opis
        {
            get
            {
                return _opis;
            }
            set
            {
                if (value != _opis)
                {
                    _opis = value;
                    OnPropertyChanged("Opis");
                }
            }
        }

        public bool Ekoloski
        {
            get
            {
                return _ekoloski;
            }
            set
            {
                if (_ekoloski == value) return;
                _ekoloski = value;
                OnPropertyChanged("Ekoloski");

            }
        }
        public bool Staniste
        {
            get
            {
                return _staniste;
            }
            set
            {
                if (_staniste == value) return;
                _staniste = value;
                OnPropertyChanged("Staniste");

            }
        }
        public bool Region
        {
            get
            {
                return _region;
            }
            set
            {
                if (_region == value) return;
                _region = value;
                OnPropertyChanged("Region");

            }
        }
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private string _tip;

        public string Tip
        {
            get
            {
                return _tip;
            }
            set
            {
                if (value != _tip)
                {
                    _tip = value;
                    OnPropertyChanged("Tip");
                }
            }
        }
        public string Prihod
        {
            get
            {
                return _prihod;
            }
            set
            {
                if (value != _prihod)
                {
                    _prihod = value;
                    OnPropertyChanged("Prihod");
                }
            }
        }
        public string Klima
        {
            get
            {
                return _klima;
            }
            set
            {
                if (value != _klima)
                {
                    _klima = value;
                    OnPropertyChanged("Klima");
                }
            }
        }
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                if (value != _status)
                {
                    _status = value;
                    OnPropertyChanged("Status");
                }
            }
        }
        public List<string> etikete
        {
            get
            {
                return _etikete;
            }
            set
            {
                if (value != _etikete)
                {
                    _etikete = value;
                    OnPropertyChanged("Etikete");
                }
            }
        }
        public Pretraga(PregledSpomenik ps)
        {
            InitializeComponent();
            this.DataContext = this;
            this.ps = ps;



        }

        private void odustani(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void pretrazi(object sender, RoutedEventArgs e)
        {
            Console.Write(Oznaka);
            if (Oznaka != null)
                ps.filOznaku(Oznaka);
            if (Naziv != null)
                ps.filIme(Naziv);
            if (Prihod != null)
                ps.filPrihod(Prihod);

            if (Klima != null)
                ps.filKlima(Klima);

            if (Status != null)
                ps.filStatus(Status);

            if (_datum != null)
                ps.filDatum(_datum);

            if (Tip != null)
                ps.filTip(Tip);

            if (radio1.IsChecked == true)
                ps.EkJeste();

            if (radio2.IsChecked == true)
                ps.EkNije();

            if (radio3.IsChecked == true)
                ps.StJeste();

            if (radio4.IsChecked == true)
                ps.StNije();

            if (radio5.IsChecked == true)
                ps.ReJeste();

            if (radio6.IsChecked == true)
                ps.ReNije();

            Close();
        }
    }
}
