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

namespace hci_projekat
{
    /// <summary>
    /// Interaction logic for Logging.xaml
    /// </summary>
    public partial class Logging : Window
    {
        public static Dictionary<string, Korisnik> korisnici = new Dictionary<string,Korisnik>();
        public Logging()
        {
            InitializeComponent();
          double x=  System.Windows.SystemParameters.WorkArea.Width;
           double y= System.Windows.SystemParameters.WorkArea.Height;

            ucitajKorisnike();
        }
        public void ucitajKorisnike()
        {
            Console.WriteLine("Usao u ucitavanje");
            // StreamReader sr = null;
            //korisnici.Clear();
            try
            {
                StreamReader file = new StreamReader("korisniciFajl.txt");

                String line= null;
                
                while ((line = file.ReadLine()) != null)
                {
                    Console.WriteLine(line);
                    line = line.Trim();
                    string[] delovi = line.Split(';');
                    Console.WriteLine();
                    
                    string imeprezime = delovi[0].Trim();
                    Console.WriteLine(imeprezime);
                   string email = delovi[1];
                    Console.WriteLine(email);
                    string korisnicko = delovi[2];
                    Console.WriteLine(korisnicko);
                    string lozinka = delovi[3];
                    Console.WriteLine(lozinka);

                    Console.WriteLine(korisnicko);
                    Console.WriteLine(lozinka);

                  Korisnik k = new Korisnik(imeprezime, email, korisnicko, lozinka);
                    korisnici.Add(k.korisnickoime, k);
                    Console.WriteLine("KORICNISKO  U UCITAVANJU" + k.korisnickoime);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("exception");
            }


        }
        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            new hci_projekat.Prozori.Registracija().ShowDialog();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           

            string korisnicko = korisnickoPrijava.Text;
            string lozinka = lozinkaPrijava.Text;
            Console.WriteLine(korisnicko);

           /* if (korisnicko.Equals("ivana123") && lozinka.Equals("ivana"))
            {

                this.Visibility = Visibility.Hidden;
                var s = new hci_projekat.MainWindow();
                s.Show();
            }
            else {
                MessageBox.Show("Pogrešno korisničko ime ili lozinka!");
            }
            */
            foreach(Korisnik k in korisnici.Values) {
                Console.WriteLine("USAOUFOREACH");
                if (korisnicko == k.korisnickoime)
                {
                    Console.WriteLine("USAOUif");
                    //MessageBox.Show("Korisnik postoji!");
                    this.Visibility = Visibility.Hidden;
                   var  s = new hci_projekat.MainWindow();
                    s.Show();
                    break;
                }
                else {
                    Console.WriteLine("USAOUelse");
                    MessageBox.Show("Ne postoji korisnik sa tim korisnickim imenom!");
                }
               
            }



           
        }
    }
}
