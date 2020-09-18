using hci_projekat.Klase;
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
using static hci_projekat.Klase.Etiketa;

namespace hci_projekat.Prozori
{
    /// <summary>
    /// Interaction logic for DodajEtiketu.xaml
    /// </summary>
    public partial class DodajEtiketu : Window
    {

        MainWindow parent;
        RepozitorijumEtiketa re = new RepozitorijumEtiketa();

        public bool valid;
        public string _oznaka { get; set; }
        public string _opis { get; set; }
        public Color _boja;

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

        public DodajEtiketu(MainWindow mw)
        {
            InitializeComponent();
            this.DataContext = this;
            parent = mw;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            valid = true;
            validateAllForms();
            Etiketa et = new Etiketa();
            et.oznakaEtikete = textBox1.Text;
            et.opisEtikete = textBox2.Text;
            et.boja = Boja;
            et.eBoja = Boja.ToString();

            if (valid)
            {
                
                //RepozitorijumEtiketa re = new RepozitorijumEtiketa();
                MainWindow.re.Dodaj(et);
                //parent.addEtiketa(et);
                //parent.refreshETable();
                //parent.selectTab(2);
                
                this.Close();
            }
            else
                return;


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
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
            textBox1.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            textBox2.GetBindingExpression(TextBox.TextProperty).UpdateSource();

            validate(textBox1);
            validate(textBox2);
        }


    }
}
