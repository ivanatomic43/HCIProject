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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using hci_projekat.Klase;
using Microsoft.Win32;
using hci_projekat;
using System.Media;

namespace hci_projekat.Prozori
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    ///



    public partial class DodajSpomenik : Window
    {


        MainWindow parent;
       
        public static ObservableCollection<string> tipovi { get; set; }
        public static ObservableCollection<ListaEtiketa> etiketee { get; set; }
        
        public static Dictionary<string, Spomenik> spomenici = new Dictionary<string, Spomenik>();
    

        public bool valid;
        public string imagePath1 { get; set; }
        public bool noPicture = true;

        public string _ime { get; set; }
        public string _oznaka { get; set; }
        public string _datum { get; set; }
        public string _opis { get; set; }
        public string _prihod { get; set; }
        public string _status { get; set; }
        public string _klima { get; set; }
        public bool _ekoloski { get; set; }
        public bool _staniste { get; set; }

        public bool _region { get; set; }
        public List<string> _etikete;
        [NonSerialized]
        public BitmapImage _ikonicaR;
        public Point _p;

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
        public BitmapImage ikonicaR
        {
            get
            {
                return _ikonicaR;
            }
            set
            {
                if (value != _ikonicaR)
                {
                    _ikonicaR = value;
                    OnPropertyChanged("ikonicaR");
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
                if (_region == value) return;
                _region = value;
                OnPropertyChanged("Region");

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
                    _prihod= value;
                    OnPropertyChanged("Prihod");
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
        public DodajSpomenik()
        {
            InitializeComponent();
            this.DataContext = this;
            //parent = mw;
            tipovi = new ObservableCollection<string>();

            foreach (KeyValuePair<Guid, Tip> kt in MainWindow.rt.iscitaj())
            {
                tipovi.Add(kt.Value.nazivTipa);
            }


            etiketee = new ObservableCollection<ListaEtiketa>();

            foreach (KeyValuePair<Guid, Etiketa> ke in MainWindow.re.iscitaj())
            {
                ListaEtiketa le = new ListaEtiketa(ke.Value.oznakaEtikete, false);
                etiketee.Add(le);
            }

            foreach (ListaEtiketa let in etiketee) {
                Console.WriteLine("!!!!!!!!!!!!!!!!");
                Console.WriteLine("Etikete : " + let.item + let.isChecked);
            }

            listViewEtiketeD.ItemsSource = etiketee;
            comboBoxTipD.ItemsSource = tipovi;

            /* List<String> imena = new List<String>();
             foreach (Tip t1 in t) {

                 Console.WriteLine("IMEtipa " + t1.nazivTipa);
                 imena.Add(t1.nazivTipa);

             }

             Console.WriteLine("IMENA TIPOVA: " + imena.ToString());
             */
             

        }


        //dodajtipbuton
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            new hci_projekat.Prozori.DodajTip(parent).ShowDialog();
            // var t = new hci_projekat.Prozori.DodajTip(parent);
            //t.ShowDialog();

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
       
        //dodaj spomenik
        private void dodajspomenik(object sender, RoutedEventArgs e)
        {

            valid = true;
            noPicture = true;
            validateAllForms();

            if (ikonicaR == null) {

                noPicture = false;
            }
            
            


            if (valid && (!noPicture))
            {
                Spomenik m = new Spomenik();

                m.oznakaSpomenik = Oznaka;
                m.nazivSpomenik = Ime;
                m.opisSpomenik = Opis;
                m.tipSpomenik = Tip;
                m.spomenikpath = imagePath1;
                m.ikonicaR = ikonicaR;
                m.ekoloskiUgrozen = Ekoloski;
                m.stanisteUV = Staniste;
                m.naseljenRegion = Region;
                m.datumOtkrivanja = _datum;
                //m.turistickiStatus = Status;
                m.godisnjiPrihod = Prihod;

                /*if (m.ikonicaR == null) {
                    MessageBox.Show("NEMA");
                    foreach (KeyValuePair<Guid, Tip> kt in MainWindow.rt.iscitaj())
                    {
                        if (kt.Value.nazivTipa.Equals(m.tipSpomenik))
                            Console.WriteLine(m.tipSpomenik);
                            m.ikonicaR = kt.Value.imagepath;
                        m.spomenikpath = kt.Value.path;
                    }

    
                }
               */
                foreach (ListaEtiketa let in etiketee)
                {
                    Console.WriteLine("!!!!!!!!!!!!!!!!");
                    Console.WriteLine("Etikete : " + let.item + let.isChecked);
                }

                //etikete
                foreach (ListaEtiketa et in etiketee)
                {
                    if (et.isChecked == true)
                    {
                        //Console.WriteLine("USAO U TRUEEEEE");

                        m.etikette.Add(et.item);
                        Console.WriteLine("etiketa za spomenik:" + et.item);
                    }
                }
                
                //tipovi
                if (m.oznakaSpomenik != null && !m.oznakaSpomenik.Equals(" ") && m.nazivSpomenik != null && Klima != null && Status != null && Tip != null)
                {

                    foreach (KeyValuePair<Guid, Tip> kt in MainWindow.rt.iscitaj())
                    {
                        if (kt.Value.oznakaTipa.Equals(Tip))
                        {
                            m.kltip = kt.Value;
                        }
                    }
                    m.klima = comboBoxKlima.SelectionBoxItem.ToString();

                    m.turistickiStatus = comboBoxStatus.SelectionBoxItem.ToString();

                    bool nasao = false;
                    foreach (KeyValuePair<Guid, Spomenik> kr in MainWindow.rs.iscitaj())
                    {
                        if (kr.Value.oznakaSpomenik.Equals(m.oznakaSpomenik))
                            nasao = true;
                    }

                    if (nasao)
                    {
                        SystemSounds.Beep.Play();
                        MessageBox.Show("Već postoji resurs sa tom oznakom");
                    }
                    else
                    {


                        if (!spomenici.ContainsKey(m.oznakaSpomenik))
                        {
                            MainWindow.spomenici.Add(m);
                            spomenici.Add(m.oznakaSpomenik, m);
                            MainWindow.rs.Dodaj(m);
                            
                            Close();
                        }
                        else
                        {
                            SystemSounds.Beep.Play();
                            System.Windows.MessageBox.Show("Već postoji tip sa tom oznakom");
                        }
                    }

                }
            }
            else
            {
                SystemSounds.Beep.Play();
                System.Windows.MessageBox.Show("Niste popunili sva obavezna polja");
            }


        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
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

        private void comboBoxTip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void textBoxImeSpomenik_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void validate(DependencyObject element)
        {
            if (valid)
            {
                if (Validation.GetHasError(element))
                    valid = false;
                else
                    return;
            }
        }
        private void validateAllForms()
        {
            textBoxImeSpomenik.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textBoxPrihod.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            //date.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textBoxOpisSpomenik.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            if (comboBoxTipD.SelectedItem == null)
            {
                comboBoxTipD.SetValue(Border.BorderBrushProperty, Brushes.Red);
                valid = false;
                return;
            }
            if (comboBoxKlima.SelectedItem == null)
            {
                comboBoxKlima.SetValue(Border.BorderBrushProperty, Brushes.Red);
                valid = false;
                return;
            }
            if (comboBoxStatus.SelectedItem == null) {
                comboBoxStatus.SetValue(Border.BorderBrushProperty, Brushes.Red);
                valid = false;
                return;
            }

            validate(textBoxImeSpomenik);
           // validate(date);
            validate(textBoxPrihod);
            validate(textBoxOpisSpomenik);
            
        }
    }
}
