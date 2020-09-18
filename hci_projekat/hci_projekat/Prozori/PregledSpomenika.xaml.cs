using hci_projekat.Klase;
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
using hci_projekat.Izmena;

namespace hci_projekat.Prozori
{
    /// <summary>
    /// Interaction logic for Pregled.xaml
    /// </summary>
    public partial class PregledSpomenika : Window
    {

        MainWindow parent;
    public static ObservableCollection<Klase.Spomenik> spomenici = new ObservableCollection<Spomenik>();
     public static   ObservableCollection<Klase.Tip> tipovi = new ObservableCollection<Tip>();
     public static   ObservableCollection<Klase.Etiketa> etikete = new ObservableCollection<Etiketa>();
       // public static ObservableCollection<string> etiket { get; set; }

        //public static ObservableCollection<Spomenik> spomenici{ get; set; }

       public static RepozitorijumSpomenika rm = new RepozitorijumSpomenika();
        public static RepozitorijumTip rt = new RepozitorijumTip();
       public static RepozitorijumEtiketa re = new RepozitorijumEtiketa();
        MainWindow mw;

        public static int indeksSelektovanog { get; set; }

        public void ispisietikete() {
            foreach (Etiketa h in re.getAll().Values) {
                Console.WriteLine("ETIKETE:" + h.oznakaEtikete);
            }

        }
        public PregledSpomenika(MainWindow mw) 
        {
            InitializeComponent();
            this.DataContext = this;
            parent = mw;
            ispisietikete();

           // listViewMapa1.SelectedItem = s;
           // comboBoxKlimaP.Text = s.klima;

            foreach (Spomenik m in rm.getAll().Values)
            {
                Console.WriteLine("spomenici repoz" + m.nazivSpomenik);
                spomenici.Add(m);

                //slikaman.Source = new BitmapImage(new Uri(m.spomenikpath));
                //spomenikImageMap.Add(m, slikaman.Source as BitmapImage);
                refreshSList();



            }


            foreach (Tip tipp in rt.getAll().Values)
            {

                tipovi.Add(tipp);
                // slikaTipa.Source = new BitmapImage(new Uri(tipp.path));
                // tipImageMap.Add(tipp, slikaTipa.Source as BitmapImage);
                refreshTList();



            }
            foreach (Etiketa etik in re.getAll().Values)
            {
                etikete.Add(etik);
                Console.WriteLine("ETIKETA" + etik.oznakaEtikete);
                refreshEList();
            }

            //etiket = new ObservableCollection<string>();

        }

        
        public void refreshSList()
        {
            listViewMapa1.ItemsSource = spomenici;
            //treeSpomenik.ItemsSource = spomenici;
        }
        public void refreshTList()
        {
            listViewMapa2.ItemsSource = tipovi;
        }
        public void refreshEList() {
            listViewMapa3.ItemsSource = etikete;
            
        }

        public bool IsCheckBoxChecked
        {
            get { return (bool)GetValue(IsCheckBoxCheckedProperty); }
            set { SetValue(IsCheckBoxCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for 
        //IsCheckBoxChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsCheckBoxCheckedProperty =
            DependencyProperty.Register("IsCheckBoxChecked", typeof(bool),
            typeof(PregledSpomenika), new UIPropertyMetadata(false));

        private bool m_c1 = true;
        public event PropertyChangedEventHandler PropertyChanged;
        public bool ekoloski
        {
            get { return m_c1; }
            set
            {
                if (m_c1 != value)
                {
                    m_c1 = value;
                    if (PropertyChanged != null)
                        PropertyChanged(this, new PropertyChangedEventArgs("ekoloski"));
                }
            }
        }

        private void listViewMapa1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            RepozitorijumSpomenika rS = new RepozitorijumSpomenika();
            RepozitorijumTip rT = new RepozitorijumTip();
            RepozitorijumEtiketa eT = new RepozitorijumEtiketa();

            if (listViewMapa1.SelectedItem != null)
            {
                Spomenik spom = (Spomenik)listViewMapa1.SelectedItem;

                spomenici.Remove(spom);
                refreshSList();
                //refreshSListMain();
                rS.Obrisi(spom);
            }
           

            if (listViewMapa2.SelectedItem != null)
            {
                Tip t = (Tip)listViewMapa2.SelectedItem;
                tipovi.Remove(t);
                refreshTList();
                //rT.Obrisi(t);
            }
           

            if (listViewMapa3.SelectedItem != null)
            {
                Etiketa et = (Etiketa)listViewMapa3.SelectedItem;
                etikete.Remove(et);
                refreshEList();
                //eT.Obrisi(et);
            }
           

        }

        public void Izmena(object sender, RoutedEventArgs e)
        {
           /* var p = new SpomenikIzmena();

            Spomenik s = new Spomenik();

            if (listViewMapa1.SelectedIndex > -1)
            {
                indeksSelektovanog = listViewMapa1.SelectedIndex;
                s = spomenici[indeksSelektovanog];

               

                p.Oznaka = s.oznakaSpomenik;
                p.ime = s.nazivSpomenik;
                p.opis = s.opisSpomenik;
                p.ekoloski = s.ekoloskiUgrozen;
                p.staniste = s.stanisteUV;
                p.region = s.naseljenRegion;
                p.tip = s.tip;
                p.klima = s.klima;
                p.status = s.turistickiStatus;
                p.prihod = s.godisnjiPrihod;
                p.datum = s.datumOtkrivanja;

                if (s.spomenikpath != null) 
                  //p.ikonicaS = new BitmapImage(new Uri(s.spomenikpath));

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
            }*/
        }

       private void izmena_etikete(object sender, RoutedEventArgs e)
        {
            /* 
            var eti = new EtiketaIzmena(mw);

            Etiketa et = new Etiketa();

            if (listViewMapa3.SelectedIndex > -1) {


                indeksSelektovanog = listViewMapa3.SelectedIndex;
                et = etikete[indeksSelektovanog];

                eti.oznaka = et.oznakaEtikete;
                eti.boja = et.boja;
                eti.opis = et.opisEtikete;

                eti.ShowDialog();
            }
*/
        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    }
