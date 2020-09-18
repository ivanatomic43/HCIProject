using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace hci_projekat.Klase
{
    [Serializable]
    public class Spomenik : INotifyPropertyChanged
    {
        public Guid ID
        {
            get;
            set;
        }
        public string oznakaSpomenik { get; set; }
        public string nazivSpomenik { get; set; }
        public string opisSpomenik { get; set; }
        public string tipSpomenik { get; set; }
        public string klima { get; set; }
        public bool ekoloskiUgrozen { get; set; }
        public bool stanisteUV { get; set; }
        public bool naseljenRegion { get; set; }
        public string turistickiStatus { get; set; }
        public string godisnjiPrihod { get; set; }
        public string datumOtkrivanja { get; set; }
        public List<string> etikette { get; set; }
        public string spomenikpath { get; set; }
        public string locationX { get; set; }
        public string locationY { get; set; }
        public Tip kltip { get; set; }
        [NonSerialized]
        public BitmapImage ikonicaR;
        public double x { get; set; }
        public double y { get; set; }
        public ObservableCollection<String> etikete { get; set; }

        public string Ime
        {
            get
            {
                return nazivSpomenik;
            }
            set
            {
                if (value != nazivSpomenik)
                {
                    nazivSpomenik = value;
                    OnPropertyChanged("Ime");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

       protected virtual void OnPropertyChanged(string v)
        {
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangedEventArgs(v));
            }
        }

        public Spomenik() {
            etikette = new List<string>();
        }
        public Spomenik(string o, string naz, string op, String tipp, string kl, bool ek, bool p, bool mo, string kat, string pub, string dat, ObservableCollection<String> et, string path, string x, string y)
        {
            oznakaSpomenik = o;
            nazivSpomenik = naz;
            tipSpomenik = tipp;
            opisSpomenik = op;
            klima = kl;
            ekoloskiUgrozen = ek;
            stanisteUV = p;
            naseljenRegion = mo;
            turistickiStatus = kat;
            godisnjiPrihod = pub;
            datumOtkrivanja = dat;
            etikete = et;
            spomenikpath = path;
            locationX = x;
            locationY = y;
        }
    }

    public class RepozitorijumSpomenika
    {
        private Dictionary<Guid, Spomenik> _r = new Dictionary<Guid, Spomenik>();
        private readonly string _datoteka;

        public RepozitorijumSpomenika()
        {
            _datoteka = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "repozitorijum.podaci");
            UcitajDatoteku();
        }

        public void Dodaj(Spomenik o)
        {
            /*int pom;
            int.TryParse(o.Oznaka, out int pom);
            if (o.ID == Guid.Empty)
                o.ID = Guid.NewGuid();
            if (!_r.ContainsKey(o.ID))
                _r.Add(o.ID, o);
            MemorisiDatoteku();*/

            Console.Write("Usao");
            if (o.ID == Guid.Empty)
            {

                o.ID = Guid.NewGuid();
            }
            if (!_r.ContainsKey(o.ID))
            {
                _r.Add(o.ID, o);
            }
            else
            {
                _r[o.ID] = o;
            }
            MemorisiDatoteku();
        }

        public void Obrisi(Spomenik o)
        {
            if (_r.ContainsKey(o.ID))
                _r.Remove(o.ID);

            MemorisiDatoteku();


        }
        public void izmeni(Guid id, Spomenik g)
        {
            _r[id] = g;
            MemorisiDatoteku();
            UcitajDatoteku();
        }

        public Dictionary<Guid, Spomenik> iscitaj()
        {
            return _r;
        }
        public void azurirajMapu(Spomenik o, string x, string y)
        {
            if (_r.ContainsKey(o.ID))
            {
                o.locationX = x;
                o.locationY = y;
            }
            MemorisiDatoteku();
        }



        private void MemorisiDatoteku()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            try
            {
                stream = File.Open(_datoteka, FileMode.OpenOrCreate);
                formatter.Serialize(stream, _r);
            }
            catch
            {
                // 
            }
            finally
            {
                if (stream != null)
                    stream.Dispose();
            }
        }

        private void UcitajDatoteku()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = null;

            if (File.Exists(_datoteka))
            {
                try
                {
                    stream = File.Open(_datoteka, FileMode.Open);
                    _r = (Dictionary<Guid, Spomenik>)formatter.Deserialize(stream);
                }
                catch
                {
                    // 
                }
                finally
                {
                    if (stream != null)
                        stream.Dispose();
                }

            }
            else
                _r = new Dictionary<Guid, Spomenik>();
        }

        public Dictionary<Guid, Spomenik> getAll()
        {
            return _r;
        }

       



    }

  





}

