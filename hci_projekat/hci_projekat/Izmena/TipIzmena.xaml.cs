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

namespace hci_projekat.Izmena
{
    /// <summary>
    /// Interaction logic for TipIzmena.xaml
    /// </summary>



    public partial class TipIzmena : Window
    {
        public string _ime { get; set; }
        public string _oznaka { get; set; }
        public string _opis { get; set; }
        public BitmapImage _ikonica;

        //public string imagePath { get; set; }

        public bool valid;
        public bool noPicture = true;
        public string imagePath;
       

        public static Dictionary<string, Tip> tipovi = new Dictionary<string, Tip>();
        RepozitorijumTip rt = new RepozitorijumTip();
        //ObservableCollection<Klase.Tip> tipovi = new ObservableCollection<Tip>();
        public Dictionary<Klase.Tip, BitmapImage> tipImageMap = new Dictionary<Tip, BitmapImage>();

        public string OznakaT
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

        public string ImeT
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

        public string OpisT
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
        public virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public TipIzmena() { 
        
            
            InitializeComponent();
            this.DataContext = this;
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;




        }
        //button izmeni
     

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imagePath = op.FileName;
                image1.Source = new BitmapImage(new Uri(op.FileName));
                //izabranaIzSpomenika = true;
            }

    


        }
        
        private void Button_Click_2(object sendet, RoutedEventArgs e) {
            this.Close();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            Tip t = new Tip();

            t.oznakaTipa = OznakaT;
            t.opisTipa = OpisT;
            t.nazivTipa = ImeT;
           // t.imagepath = ikonicaT;
            if (ikonicaT != null)
                t.path = imagePath;
            tipovi[t.oznakaTipa] = t;

           Prozori.PregledSpomenik.tipovi2[Prozori.PregledSpomenik.indeksSelektovanogTipa] = t;

            foreach (KeyValuePair<Guid, Tip> kt in MainWindow.rt.iscitaj())
            {
                if (kt.Value.oznakaTipa.Equals(t.oznakaTipa))
                {
                    Console.Write("Nasao!");
                    MainWindow.rt.izmeni(kt.Key, t);
                    break;
                }
            }

            Close();

        }
    }

}
