using System;
using System.Collections.Generic;
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
    public class Tip
    {
        public Guid ID
        {
            get;
            set;
        }
        public string oznakaTipa { get; set; }
        public string nazivTipa { get; set; }
        public string opisTipa { get; set; }
        public string path { get; set; }
        [NonSerialized]
        public BitmapImage imagepath;
        public Tip() {

        }
        public Tip(string o, string i, string op, string p)
        {
            oznakaTipa = o;
            nazivTipa = i;
            opisTipa = op;
            path = p;
        }
    }

    public class RepozitorijumTip
    {
        private Dictionary<Guid, Tip> _r = new Dictionary<Guid, Tip>();
        private readonly string _datoteka;

        public RepozitorijumTip()
        {
            _datoteka = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "repozitorijumTip.podaci");
            UcitajDatoteku();
        }

        public void Dodaj(Tip o)
        {
            // int pom;
            //int.TryParse(o.Oznaka, out int pom);
            if (o.ID == Guid.Empty)
                o.ID = Guid.NewGuid();
            if (!_r.ContainsKey(o.ID))
                _r.Add(o.ID, o);
            MemorisiDatoteku();
        }

        public void Obrisi(Guid g)
        {
            UcitajDatoteku();
            _r.Remove(g);


            MemorisiDatoteku();

        }

        public Dictionary<Guid, Tip> iscitaj()
        {
            return _r;
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

        public void izmeni(Guid id, Tip g)
        {
            UcitajDatoteku();
            _r[id] = g;
            MemorisiDatoteku();
            
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
                    _r = (Dictionary<Guid, Tip>)formatter.Deserialize(stream);
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
                _r = new Dictionary<Guid, Tip>();
        }

        public Dictionary<Guid, Tip> getAll()
        {
            return _r;
        }
    }
}