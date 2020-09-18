using hci_projekat.Klase;
using Microsoft.Win32;
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
using hci_projekat;
using System.Media;

namespace hci_projekat.Izmena
{
    /// <summary>
    /// Interaction logic for SpomenikIzmena.xaml
    /// </summary>
    public partial class SpomenikIzmena : Window
    {


        MainWindow parent;
        public static Dictionary<string, Spomenik> spomenici = new Dictionary<string, Spomenik>();

        // public static ObservableCollection<Tip> tipovi = new ObservableCollection<Tip>();
        public static ObservableCollection<string> tipovi = new ObservableCollection<string>();

        //RepozitorijumSpomenika r = new RepozitorijumSpomenika();
        public static ObservableCollection<ListaEtiketa> etiketee { get; set; }
       
        public bool valid;
        public string imagePath1 { get; set; }
        public bool noPicture = true;
        public List<string> _etikete;
        public string _ime { get; set; }
        public string _oznaka { get; set; }
        public string _datum { get; set; }
        public string _opis { get; set; }
        public bool _ekoloski { get; set; }
        public bool _staniste { get; set; }
        public bool _region { get; set; }
         public Tip tip { get; set; }
        public string _klima { get; set; }
        public string _status { get; set; }
        public string _prihod { get; set; }
        public string _tip { get; set; }
        public BitmapImage _ikonica;

        public int _index { get; set; }
        public int _index2 { get; set; }
        public int _index3 { get; set; }
        

        public int index
        {
            get
            {
                return _index;
            }

            set
            {
                if (value != _index)
                {
                    _index = value;
                    OnPropertyChanged("index");
                }
            }
        }

        public int index2
        {
            get
            {
                return _index2;
            }

            set
            {
                if (value != _index2)
                {
                    _index2 = value;
                    OnPropertyChanged("index2");
                }
            }
        }

        public int index3
        {
            get
            {
                return _index3;
            }

            set
            {
                if (value != _index3)
                {
                    _index3 = value;
                    OnPropertyChanged("index3");
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
        public string Ime
        {
            get
            {
                return _ime;
            }
            set
            {
                if (value != _ime)
                {
                    _ime = value;
                    OnPropertyChanged("Ime");
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
                if (value != _ekoloski)
                {
                    _ekoloski = value;
                    OnPropertyChanged("Ekoloski");
                }
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
                if (value != _staniste)
                {
                    _staniste = value;
                    OnPropertyChanged("Staniste");
                }
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
                if (value != _region)
                {
                    _region = value;
                    OnPropertyChanged("Region");
                }
            }
        }
        public string Datum
        {
            get
            {
                return _datum;
            }
            set
            {
                if (value != _datum)
                {
                    _datum = value;
                    OnPropertyChanged("Datum");
                }
            }
        }

        public BitmapImage ikonicaT
        {
            get
            {
                return _ikonica;
            }
            set
            {
                if (value != _ikonica)
                {
                    _ikonica = value;
                    OnPropertyChanged("ikonicaT");
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
                    _klima= value;
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
        public SpomenikIzmena(MainWindow mw)
        {
            InitializeComponent();
            this.DataContext = this;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.parent = mw;
            tipovi = new ObservableCollection<string>();
            etiketee = new ObservableCollection<ListaEtiketa>();

            foreach (KeyValuePair<Guid, Etiketa> ke in MainWindow.re.iscitaj()) {
                ListaEtiketa le = new ListaEtiketa(ke.Value.oznakaEtikete);
                etiketee.Add(le);
            }

            foreach (KeyValuePair<Guid, Spomenik> spom in MainWindow.rs.iscitaj()) {
                if (!spomenici.ContainsKey(spom.Value.oznakaSpomenik)) {
                    spomenici.Add(spom.Value.oznakaSpomenik, spom.Value);
                    
                }
            }

            foreach (KeyValuePair<Guid, Tip> t in MainWindow.rt.iscitaj()) {
                tipovi.Add(t.Value.nazivTipa);
            }
            comboBoxTip.ItemsSource = tipovi;
        }



     
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }


        private double _test1;

        public double Test1
        {
            get
            {
                return _test1;
            }
            set
            {
                if (value != _test1)
                {
                    _test1 = value;
                    OnPropertyChanged("Test1");
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

        //dodaj spomenik


        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void izmeni_spomenik(object sender, RoutedEventArgs e)
        {
            Spomenik kr = new Spomenik();

            kr.oznakaSpomenik = Oznaka;
            kr.nazivSpomenik = Ime;
            kr.opisSpomenik = Opis;
            kr.ekoloskiUgrozen =Ekoloski;
            kr.stanisteUV = Staniste;
            kr.naseljenRegion = Region;
            kr.kltip = tip;
            kr.klima = Klima;
            kr.turistickiStatus = Status;
            kr.godisnjiPrihod = Prihod;
            //kr.spomenikpath = ikonicaT ;
           // kr.etikete = etiketee;
            
            //kr.datum = _datum;

            //Console.Write(Datum.ToString());




            


                kr.klima = comboBoxKlima.SelectionBoxItem.ToString();
                kr.turistickiStatus = comboBoxStatus.SelectionBoxItem.ToString();
                
                if (etikete != null)
                    kr.etikette = new List<string>(etikete);

            kr.spomenikpath = ikonicaT.ToString();

                /*if (ikonicaT == null)
                {
                    foreach (KeyValuePair<Guid, Tip> kt in MainWindow.rt.iscitaj())
                    {
                        if (Tip.Equals(kt.Value.oznakaTipa))
                        {
                            kr.ikonicaR = new BitmapImage(new Uri(kt.Value.path));
                        }
                    }
                }
                else
                {
                    kr.ikonicaR = ikonicaT;
                }
                */
                // kr.spomenikpath = 

                //kr.ikonicaR = ikonicaR;
                kr.tipSpomenik = Tip;

                //kr.etikete.Clear();

                foreach (var et in etiketee)
                {
                    if (et.isChecked == true)
                    {
                        kr.etikete.Add(et.Item);
                    }
                }

                

                if (kr.oznakaSpomenik != null && !kr.oznakaSpomenik.Equals(" ") && kr.Ime != null && Klima != null && Status != null)
                {

                    Prozori.PregledSpomenik.spomenici[Prozori.PregledSpomenik.indeksSelektovanogSpomenika] = kr;
                    

                    foreach (KeyValuePair<Guid, Spomenik> ke in MainWindow.rs.iscitaj())
                    {
                        if (ke.Value.oznakaSpomenik.Equals(kr.oznakaSpomenik))
                        {
                            kr.x = ke.Value.x;
                            kr.y = ke.Value.y;
                            MainWindow.rs.izmeni(ke.Key, kr);
                            parent.izmeni(ke.Key);
                         
                            break;
                        }
                    }

                    Close();
                }
                else
                {
                    SystemSounds.Beep.Play();
                    System.Windows.MessageBox.Show("Niste popunili sva obavezna polja");
                }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Izaberi sliku";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imagePath1 = op.FileName;
                slikaSpomenika.Source = new BitmapImage(new Uri(op.FileName));
            }
        }
    }
}
