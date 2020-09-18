using hci_projekat.Klase;
using hci_projekat.Prozori;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace hci_projekat.Izmena
{
    /// <summary>
    /// Interaction logic for DodajEtiketuIzmena.xaml
    /// </summary>
    public partial class EtiketaIzmena : Window
    {

        public string _oznaka;
        public string _opis;
        public Color _boja;
        
       
       
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

        public Color Boja
        {
            get
            {
                return _boja;
            }
            set
            {
                if (value != _boja)
                {
                    _boja = value;
                    OnPropertyChanged("Boja");
                }
            }
        }

        public virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Button_Click_1(object sender, RoutedEventArgs e) {

            this.Close();
        }

        public EtiketaIzmena() {

            InitializeComponent();
            this.DataContext = this;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Etiketa et = new Etiketa();

            et.oznakaEtikete = Oznaka;
            et.opisEtikete = Opis;
            et.boja = Boja;
            et.eBoja = Boja.ToString();

           // mapa[et.oznakaEtikete] = et;

            PregledSpomenik.etikete[PregledSpomenik.indeksSelektovaneEtikete] = et;
            foreach (KeyValuePair<Guid,Etiketa> ke in MainWindow.re.iscitaj()){
                if (ke.Value.oznakaEtikete.Equals(et.oznakaEtikete)) {
                    MainWindow.re.izmeni(ke.Key, et);
                    break;

                }
            }
            Close();
        }
    }
}