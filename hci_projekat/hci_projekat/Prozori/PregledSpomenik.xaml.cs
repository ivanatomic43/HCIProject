using hci_projekat.Izmena;
using hci_projekat.Klase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Media;
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

namespace hci_projekat.Prozori
{
    /// <summary>
    /// Interaction logic for PregledSpomenik.xaml
    /// </summary>
    public partial class PregledSpomenik : Window, INotifyPropertyChanged
    {

        public static ObservableCollection<Spomenik> spomenici { get; set; }
        public static ObservableCollection<Tip> tipovi2 { get; set; }
        public static ObservableCollection<Etiketa> etikete { get; set; }
        public static ObservableCollection<string> etiketeBox { get; set; }
        MainWindow mw;

        public static int indeksSelektovanogSpomenika { get; set; }
        public static int indeksSelektovanogTipa { get; set; }
        public static int indeksSelektovaneEtikete { get; set; }

        //filtriranje i pretraga
        public string _selektovano;
        public Visibility _vidljivostTip = Visibility.Hidden;
        public Visibility _vidljivostOznaka =Visibility.Hidden;
        public Visibility _vidljivostNaziv= Visibility.Hidden;

        public string _oznaka;
        public string _naziv;
        public string _tip;
        public PregledSpomenik(MainWindow mw)
        {
            InitializeComponent();
            this.DataContext = this;
            this.mw = mw;

            //RepozitorijumSpomenika rm = new RepozitorijumSpomenika();
           // RepozitorijumTip rt = new RepozitorijumTip();
           // RepozitorijumEtiketa re = new RepozitorijumEtiketa();

            spomenici = new ObservableCollection<Spomenik>();
            tipovi2 = new ObservableCollection<Tip>();
            etikete = new ObservableCollection<Etiketa>();
            etiketeBox = new ObservableCollection<string>();
            tipoviFilter  = new ObservableCollection<string>();

            foreach (KeyValuePair<Guid, Spomenik> ks in MainWindow.rs.iscitaj())
            {
                Console.WriteLine("USAOUCITAVANJESPOMENIKA");
                spomenici.Add(ks.Value);
                Console.WriteLine("oznakaspomenika:" + ks.Value.oznakaSpomenik);
                
            }

            foreach (KeyValuePair<Guid, Tip> kt in MainWindow.rt.iscitaj())
            {
                tipovi2.Add(kt.Value);
            }
            Console.WriteLine("STIGAOOVDE");

            foreach (KeyValuePair<Guid, Etiketa> ke in MainWindow.re.iscitaj())
            {
                
              etikete.Add(ke.Value);
            }
 
           
        }
        public Visibility vidljivostTip
        {
            get
            {
                return _vidljivostTip;
            }

            set
            {
                if (_vidljivostTip != value)
                {
                    _vidljivostTip = value;
                    OnPropertyChanged("vidljivostTip");
                }
            }
        }
        public Visibility vidljivostOznaka
        {
            get
            {
                return _vidljivostOznaka;
            }

            set
            {
                if (_vidljivostOznaka != value)
                {
                    _vidljivostOznaka = value;
                    OnPropertyChanged("vidljivostOznaka");
                }
            }
        }
        public Visibility vidljivostNaziv
        {
            get
            {
                return _vidljivostNaziv;
            }

            set
            {
                if (_vidljivostNaziv != value)
                {
                    _vidljivostNaziv= value;
                    OnPropertyChanged("vidljivostNaziv");
                }
            }
        }
        public string selektovano
        {
            get
            {
                return _selektovano;
            }

            set
            {
                if (_selektovano != value)
                {
                    _selektovano = value;
                    OnPropertyChanged("selektovano");
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
                if (_oznaka != value)
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
                if (_naziv != value)
                {
                    _naziv = value;
                    OnPropertyChanged("Naziv");
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
                if (_tip!= value)
                {
                    _tip = value;
                    OnPropertyChanged("Tip");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public void Izmena(object sender, RoutedEventArgs e)
        {
             var p = new SpomenikIzmena(mw);

             Spomenik s = new Spomenik();

             if (gridS.SelectedIndex > -1)
             {
                 indeksSelektovanogSpomenika = gridS.SelectedIndex;
                 s = spomenici[indeksSelektovanogSpomenika];



                 p.Oznaka = s.oznakaSpomenik;
                 p.Ime = s.nazivSpomenik;
                 p.Opis = s.opisSpomenik;
                 p.Ekoloski = s.ekoloskiUgrozen;
                 p.Staniste = s.stanisteUV;
                 p.Region = s.naseljenRegion;
                 p.tip = s.kltip;
                 p.Klima = s.klima;
                 p.Status = s.turistickiStatus;
                 p.Prihod = s.godisnjiPrihod;
                 p.Datum = s.datumOtkrivanja;


                p.ikonicaT = new BitmapImage(new Uri(s.spomenikpath));
                int i = 0;
                foreach (KeyValuePair<Guid, Spomenik> kr in MainWindow.rs.iscitaj())
                {

                    if (kr.Value.oznakaSpomenik.Equals(s.tipSpomenik))
                    {
                        Console.Write("\nNasao\n");
                        p.index3 = i;
                        break;
                    }
                    i++;
                }

                if (s.klima.Equals("Polarna"))
                     p.index2 = 0;
                 if (s.klima.Equals("Kontinentalna"))
                     p.index2 = 1;
                 if (s.klima.Equals("Umereno Kontinentalna"))
                     p.index2 = 2;
                 if (s.klima.Equals("Pustinjska"))
                     p.index2 = 3;
                 if (s.klima.Equals("Suptropska"))
                     p.index2 = 4;
                 if (s.klima.Equals("Tropska"))
                     p.index2 = 5;

                 if (s.turistickiStatus.Equals("Eksploatisan"))
                     p.index = 0;
                 if (s.turistickiStatus.Equals("Dostupan"))
                     p.index = 1;
                 if (s.turistickiStatus.Equals("Nedostupan"))
                     p.index = 2;

                 p.ShowDialog();
             }
             else
             {
                 SystemSounds.Beep.Play();
                 MessageBox.Show("Nije selektovan resurs");
             }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
           // RepozitorijumSpomenika rS = new RepozitorijumSpomenika();
            //RepozitorijumTip rT = new RepozitorijumTip();
            //RepozitorijumEtiketa eT = new RepozitorijumEtiketa();

            if (gridS.SelectedItem != null)
            {
                Spomenik spom = (Spomenik)gridS.SelectedItem;

                spomenici.Remove(spom);
                refreshSTable();
                MainWindow.rs.Obrisi(spom);
                mw.obrisiLista(spom);
                MainWindow.prebaceniSpomenici.Remove(spom);
                //refreshSListMain();
                //rS.Obrisi(spom);

            }


            if (gridT.SelectedItem != null)
            {
                Tip t = (Tip)gridT.SelectedItem;


                DodajTip.tipovi.Remove(t.nazivTipa);
                tipovi2.RemoveAt(gridT.SelectedIndex);
                foreach (KeyValuePair<Guid, Tip> tipp in MainWindow.rt.iscitaj())
                {

                    if (tipp.Value.nazivTipa.Equals(t.nazivTipa))
                    {
                        MainWindow.rt.Obrisi(tipp.Key);
                    }

                }
                refreshTTable();
                //rT.Obrisi(t);
            }


            if (gridE.SelectedItem != null)
            {
                Etiketa et = (Etiketa)gridE.SelectedItem;
                etikete.Remove(et);
                refreshETable();
                foreach (KeyValuePair<Guid, Etiketa> ett in MainWindow.re.iscitaj())
                {

                    if (ett.Value.oznakaEtikete.Equals(et.oznakaEtikete))
                    {
                        MainWindow.re.Obrisi(ett.Key);
                    }

                }

               // MainWindow.re.Obrisi(et.oznakaEtikete);
               // eT.Obrisi(et);
            }
            

        }

        public void refreshSTable()
        {
            gridS.ItemsSource = spomenici;
            mw.refreshListView();
            //treeSpomenik.ItemsSource = spomenici;
        }
        public void refreshTTable()
        {
            gridT.ItemsSource = tipovi2;
           // DodajSpomenik.comboBoxTipD.ItemsSource = tipovi2.ToString();
        }
        public void refreshETable()
        {
            gridE.ItemsSource = etikete;

        }

        private void izmenatip(object sender, RoutedEventArgs e)
        {

            var p = new TipIzmena();

            Tip t = new Tip();

            if (gridT.SelectedIndex > -1)
            {

                indeksSelektovanogTipa = gridT.SelectedIndex;
                t = tipovi2[indeksSelektovanogTipa];

                p.OznakaT = t.oznakaTipa;
                p.OpisT = t.opisTipa;
                p.ImeT = t.nazivTipa;
                if (t.path != null)
                {
                    p.ikonicaT = new BitmapImage(new Uri(t.path));
                }
                p.ShowDialog();
            }
            else {
                SystemSounds.Beep.Play();
                System.Windows.MessageBox.Show("Nije selektovan tip!");
            }




        }

        private void izmenaetiketa( object sender, RoutedEventArgs e) {

            var p = new EtiketaIzmena();

            Etiketa et = new Etiketa();

            if (gridE.SelectedIndex > -1)
            {

                indeksSelektovaneEtikete = gridE.SelectedIndex;
                et = etikete[indeksSelektovaneEtikete];

                p.Oznaka = et.oznakaEtikete;
                p.Boja = et.boja;
                et.eBoja = p.Boja.ToString();
                
                p.Opis = et.opisEtikete;
                
               
                p.ShowDialog();
            }
            else
            {
                SystemSounds.Beep.Play();
                System.Windows.MessageBox.Show("Nije selektovana etiketa!");
            }


        }
        //promena comboboxa kod filtracije
        public static ObservableCollection<string> tipoviFilter { get; set; }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
       
            string sel = selektovano.Split(':')[1];
            Console.WriteLine("Se;ektovano:" + sel);
            if (sel.Equals(" Oznaka"))
            {
                Console.WriteLine("USAO U VIDLJIVOST OZNAKA");
                vidljivostOznaka = Visibility.Visible;
                
                vidljivostNaziv = Visibility.Hidden;
                vidljivostTip = Visibility.Hidden;
                

                spomenici.Clear();

                foreach (KeyValuePair<Guid, Spomenik> kr in MainWindow.rs.iscitaj())
                {

                    spomenici.Add(kr.Value);
                }
                
            }

            else if (sel.Equals(" Naziv"))
            {

                vidljivostOznaka = Visibility.Hidden;
                vidljivostNaziv = Visibility.Visible;
                vidljivostTip = Visibility.Hidden;

            }

            else if (sel.Equals(" Tip"))
            {
                vidljivostOznaka = Visibility.Hidden;
                vidljivostNaziv = Visibility.Hidden;
                vidljivostTip = Visibility.Visible;

                if (tipoviFilter != null)
                    tipoviFilter.Clear();
                foreach (KeyValuePair<Guid, Tip> kt in MainWindow.rt.iscitaj())
                {
                    tipoviFilter.Add(kt.Value.nazivTipa);
                }

            }
            else {
                Console.WriteLine("Nista od navedenog");
            }

        }


        //filtracija po oznaci
        private void oznakaChanged(object sender, TextChangedEventArgs e)
        {
            if (vidljivostOznaka == Visibility.Visible)
            {
                spomenici.Clear();
                foreach (KeyValuePair<Guid, Spomenik> kr in MainWindow.rs.iscitaj())
                {

                    spomenici.Add(kr.Value);
                }


                List<Spomenik> lista = new List<Spomenik>(spomenici);

                Console.Write(FilterOznaka.Text);

                foreach (Spomenik spomenik in lista)
                {
                    Console.Write("\nOvde\n");
                    if (!spomenik.oznakaSpomenik.StartsWith(FilterOznaka.Text))
                    {
                        Console.Write("\nBrise se \n");
                        spomenici.Remove(spomenik);
                    }
                }
            }
        }
        //filtracija po nazivu 
        private void nazivChanged(object sender, TextChangedEventArgs e)
        {
            if (vidljivostNaziv == Visibility.Visible)
            {
                spomenici.Clear();
                foreach (KeyValuePair<Guid, Spomenik> kr in MainWindow.rs.iscitaj())
                {

                    spomenici.Add(kr.Value);
                }


                List<Spomenik> lista = new List<Spomenik>(spomenici);

                Console.Write(FilterNaziv.Text);

                foreach (Spomenik spomenik in lista)
                {
                    
                    if (!spomenik.nazivSpomenik.StartsWith(FilterNaziv.Text))
                    {
                       
                        spomenici.Remove(spomenik);
                    }
                }
            }
        }
        public string selektovanTip
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
                    OnPropertyChanged("selektovanTip");
                }
            }
        }
        //filtracija po tipu
        private void tipChanged(object sender, SelectionChangedEventArgs e)
        {

            if (selektovanTip != null)

            {
                Console.Write("\nUsao u promenu tipa\n");
                string sel = selektovanTip;
                spomenici.Clear();
                foreach (KeyValuePair<Guid, Spomenik> kr in MainWindow.rs.iscitaj())
                {

                    spomenici.Add(kr.Value);
                }


                List<Spomenik> lista = new List<Spomenik>(spomenici);

                //double broj = Double.Parse(pretragaCena.Text);

                foreach (Spomenik spom in lista)
                {

                    if (!(spom.tipSpomenik.Equals(sel)))
                    {
                        Console.Write("\nBrise se \n");
                        spomenici.Remove(spom);
                    }
                }
            }

        }

        private void PretragaProzor(object sender, RoutedEventArgs e)
        {
            var s = new Prozori.Pretraga(this);
            s.Show();
        }
        //pretraga
        public void filOznaku(string ozn)
        {
            Console.Write("\nFilter oznake\n");
            ObservableCollection<Spomenik> lista = new ObservableCollection<Spomenik>(spomenici);
            foreach (Spomenik s in lista)
            {
                if (!s.oznakaSpomenik.StartsWith(ozn))
                    spomenici.Remove(s);
            }
        }

        public void filIme(string ime)
        {
            Console.Write("\nFilter imena\n");
            ObservableCollection<Spomenik> lista = new ObservableCollection<Spomenik>(spomenici);
            foreach (Spomenik kr in lista)
            {
                if (!kr.nazivSpomenik.StartsWith(ime))
                    spomenici.Remove(kr);
            }
        }

        public void filPrihod(string ozn)
        {
            Console.Write("\nFilter oznake\n");
            ObservableCollection<Spomenik> lista = new ObservableCollection<Spomenik>(spomenici);
            foreach (Spomenik kr in lista)
            {
                if (kr.godisnjiPrihod != null)
                {
                    if (!kr.godisnjiPrihod.Equals(ozn))
                        spomenici.Remove(kr);
                }
                else
                {
                    spomenici.Remove(kr);
                }
            }
        }

        public void filKlima(string klima)
        {
            
            Console.Write(klima);
            string klima1 = klima.Split(':')[1];

            ObservableCollection<Spomenik> lista = new ObservableCollection<Spomenik>(spomenici);
            foreach (Spomenik kr in lista)
            {
                if (!kr.klima.Equals(klima))
                    spomenici.Remove(kr);
            }
        }

        public void filStatus(string status)
        {
            
            //Console.Write(klima);
            string status1 = status.Split(':')[1];

            ObservableCollection<Spomenik> lista = new ObservableCollection<Spomenik>(spomenici);
            foreach (Spomenik kr in lista)
            {
                if (!kr.turistickiStatus.Equals(status))
                    spomenici.Remove(kr);
            }
        }

        public void EkJeste()
        {
            Console.Write("\nFilter oznake\n");
            ObservableCollection<Spomenik> lista = new ObservableCollection<Spomenik>(spomenici);
            foreach (Spomenik kr in lista)
            {
                if (!kr.ekoloskiUgrozen)
                    spomenici.Remove(kr);
            }
        }

        public void StJeste()
        {
            Console.Write("\nFilter oznake\n");
            ObservableCollection<Spomenik> lista = new ObservableCollection<Spomenik>(spomenici);
            foreach (Spomenik kr in lista)
            {
                if (!kr.stanisteUV)
                    spomenici.Remove(kr);
            }
        }

        public void ReJeste()
        {
            Console.Write("\nFilter oznake\n");
            ObservableCollection<Spomenik> lista = new ObservableCollection<Spomenik>(spomenici);
            foreach (Spomenik kr in lista)
            {
                if (!kr.naseljenRegion)
                    spomenici.Remove(kr);
            }
        }

        public void EkNije()
        {
            Console.Write("\nFilter oznake\n");
            ObservableCollection<Spomenik> lista = new ObservableCollection<Spomenik>(spomenici);
            foreach (Spomenik kr in lista)
            {
                if (kr.ekoloskiUgrozen)
                    spomenici.Remove(kr);
            }
        }

        public void StNije()
        {
            Console.Write("\nFilter oznake\n");
            ObservableCollection<Spomenik> lista = new ObservableCollection<Spomenik>(spomenici);
            foreach (Spomenik kr in lista)
            {
                if (kr.stanisteUV)
                    spomenici.Remove(kr);
            }
        }

        public void ReNije()
        {
            Console.Write("\nFilter oznake\n");
            ObservableCollection<Spomenik> lista = new ObservableCollection<Spomenik>(spomenici);
            foreach (Spomenik kr in lista)
            {
                if (kr.naseljenRegion)
                    spomenici.Remove(kr);
            }
        }
        public void filTip(string mera1)
        {
            Console.Write("\n!!\n");
            Console.Write(mera1);
            ObservableCollection<Spomenik> lista = new ObservableCollection<Spomenik>(spomenici);
            foreach (Spomenik kr in lista)
            {
                if (!kr.tipSpomenik.Equals(mera1))
                    spomenici.Remove(kr);
            }
        }
        public void filDatum(string mera)
        {

            Console.Write(mera);
            ObservableCollection<Spomenik> lista = new ObservableCollection<Spomenik>(spomenici);
            foreach (Spomenik kr in lista)
            {
                if (kr.datumOtkrivanja != null)
                {
                    if (!kr.datumOtkrivanja.Equals(mera))
                        spomenici.Remove(kr);
                }
                else
                {
                    spomenici.Remove(kr);
                }
            }
        }

        private void ponistavanje(object sender, RoutedEventArgs e)
        {
           spomenici.Clear();
            foreach (KeyValuePair<Guid, Spomenik> kr in MainWindow.rs.iscitaj())
            {
                spomenici.Add(kr.Value);
            }
        }
        private void DelS_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DelS_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Button_Click(sender, e);
        }
        private void DelT_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DelT_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Button_Click(sender, e);
        }


        private void DelE_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void DelE_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Button_Click(sender, e);
        }
    }
}
