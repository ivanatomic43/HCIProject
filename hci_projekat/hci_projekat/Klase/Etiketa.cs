using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace hci_projekat.Klase
{
    [Serializable]
    public class Etiketa
    {

        public Guid ID
        {
            get;
            set;
        }

        public string oznakaEtikete { get; set; }
        [NonSerialized]
        public Color boja;
        public string opisEtikete { get; set; }
        public string eBoja { get; set; }
     

        public Etiketa() {

        }
        
        
    }

    public class RepozitorijumEtiketa
    {
        private Dictionary<Guid, Etiketa> _r = new Dictionary<Guid, Etiketa>();
        private readonly string _datoteka;

        public RepozitorijumEtiketa()
        {
            _datoteka = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "repozitorijumEtiketa.podaci");
            UcitajDatoteku();
        }

        public void Dodaj(Etiketa et)
        {
            // int pom;
            //int.TryParse(o.Oznaka, out int pom);
            if (et.ID == Guid.Empty)
                et.ID = Guid.NewGuid();
            if (!_r.ContainsKey(et.ID))
                _r.Add(et.ID, et);
            MemorisiDatoteku();
        }

        public Dictionary<Guid, Etiketa> iscitaj()
        {
            return _r;
        }

        public void Obrisi(Guid g)
        {
            UcitajDatoteku();
            _r.Remove(g);

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

        public void izmeni(Guid id, Etiketa g)
        {

            UcitajDatoteku();
            Console.Write("\nID:\n");
            Console.Write(id);

            int i = 1;



            foreach (KeyValuePair<Guid, Etiketa> t in MainWindow.re.iscitaj())
            {
                Console.Write("\n\n");
                Console.Write(i);
                Console.Write(" ");
                Console.Write(t.Key);
                //etik.Add(t.Value);
                i++;
            }

            Etiketa ke = _r[id];
            Console.Write("\nOpis pre:\n");
            Console.Write(ke.opisEtikete);

            Console.Write("\nOpis posle:\n");
            Console.Write(g.opisEtikete);


            _r[id] = g;

            Etiketa kee = _r[id];
            Console.Write("\nOpis nakon izmene:\n");
            Console.Write(kee.opisEtikete);

            i = 1;

            foreach (KeyValuePair<Guid, Etiketa> t in MainWindow.re.iscitaj())
            {
                Console.Write("\n\n");
                Console.Write(i);
                Console.Write(" ");
                Console.Write(t.Key);
                //etik.Add(t.Value);
                i++;
            }

            MemorisiDatoteku();

            i = 1;

            UcitajDatoteku();
            foreach (KeyValuePair<Guid, Etiketa> t in MainWindow.re.iscitaj())
            {
                Console.Write("\n\n");
                Console.Write(i);
                Console.Write(" ");
                Console.Write(t.Key);
                //etik.Add(t.Value);
                i++;
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
                    _r = (Dictionary<Guid, Etiketa>)formatter.Deserialize(stream);
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
                _r = new Dictionary<Guid, Etiketa>();
        }

        public Dictionary<Guid, Etiketa> getAll()
        {
            return _r;
        }
    }
}

