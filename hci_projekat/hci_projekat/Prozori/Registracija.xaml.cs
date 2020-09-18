using hci_projekat.Klase;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for Registracija.xaml
    /// </summary>
    public partial class Registracija : Window
    {

        private static Dictionary<string, Korisnik> korisnici = new Dictionary<string, Korisnik>();
        private static List<Korisnik> korisniciLista = new List<Korisnik>();
        public Registracija()
        {
            InitializeComponent();

        }

        public void dodajKorisnika(Korisnik k)
        {

            korisnici.Add(k.korisnickoime, k);
            korisniciLista.Add(k);
            sacuvajKorisnika();

        }
        public void sacuvajKorisnika()
        {

            StreamWriter korisniciFajl = new StreamWriter("korisniciFajl.txt");
            int brojac = 0;
            var listcount = korisnici.Count;
            foreach (Korisnik k in korisnici.Values)
            {
                korisniciFajl.Write(k.imeprezime, k.email, k.korisnickoime, k.lozinka);
            }

            korisniciFajl.Close();
        }





        private void Button_Click1(object sender, RoutedEventArgs e)
        {
           // valid = true;
           // validateAllForms();

           
                Korisnik k = new Korisnik();

                k.imeprezime = imeprezime.Text;
                k.email = email.Text;
                k.korisnickoime = korisnickoime.Text;
                k.lozinka = lozinka.Text;


                dodajKorisnika(k);


                this.Visibility = Visibility.Hidden;
                var s = new hci_projekat.MainWindow();
                s.Show();
            
            
        }

        private void validateAllForms()
        {
            imeprezime.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            email.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            //date.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            korisnickoime.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            lozinka.GetBindingExpression(TextBox.TextProperty).UpdateSource();


            validate(imeprezime);
            validate(email);
            validate(korisnickoime);
            validate(lozinka);

        }
        public bool valid;
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
    }
}