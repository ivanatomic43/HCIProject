using hci_projekat.Klase;
using Microsoft.Win32;
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
using static hci_projekat.Klase.Tip;

namespace hci_projekat.Prozori
{

    /// <summary>
    /// Interaction logic for DodajTip.xaml
    /// </summary>
    public partial class DodajTip : Window
    {
        public string ime { get; set; }
        public string oznaka { get; set; }
        public string opis { get; set; }

        public string imagePath { get; set; }

        public bool valid;
        public string oznakatip;
        public bool noPicture = true;
        MainWindow parent;
        public static Dictionary<string, Tip> tipovi = new Dictionary<string, Tip>();
        

        public DodajTip(MainWindow mw)
        {
            InitializeComponent();
            this.DataContext = this;
            parent = mw;
            foreach (KeyValuePair<Guid, Tip> t in MainWindow.rt.iscitaj())
            {
                if (!tipovi.ContainsKey(t.Value.oznakaTipa))
                {
                    tipovi.Add(t.Value.oznakaTipa, t.Value);
                }
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
                imagePath = op.FileName;
                image1.Source = new BitmapImage(new Uri(op.FileName));
            }
        }
        //dodajbuton
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            valid = true;
            validateAllForms();

            if (image1.Source == null)
            {
                noPicture = true;
                imageBorder.BorderBrush = Brushes.Red;
            }
            else
            {
                noPicture = false;
                imageBorder.BorderBrush = Brushes.Black;
            }

            //provera jedinstvenosti tipa
            oznakatip = textBoxOznakaTipa.Text;
            /*foreach (KeyValuePair<Guid, Tip> kt in MainWindow.rt.iscitaj()) {
                if (kt.Value.oznakaTipa.Equals(oznakatip))
                    MessageBox.Show("Vec postoji tip sa tom oznakom!");
            }
            */
            if (valid && !noPicture)
            {
                Tip t = new Tip(textBoxOznakaTipa.Text, textBoxNazivTipa.Text, textBoxOpisTipa.Text, imagePath);

                MainWindow.rt.Dodaj(t);
                tipovi.Add(t.oznakaTipa, t);
                
               // parent.addTip(t);
                // parent.opisTipaTabela.;
                
                parent.tipImageMap.Add(t, image1.Source as BitmapImage);


                this.Close();
            }
            else
                return;



        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private double _test1;


        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }

        }

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
            textBoxNazivTipa.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textBoxOpisTipa.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            validate(textBoxNazivTipa);
            validate(textBoxOpisTipa);
        }

        private void textBoxNazivTipa_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}