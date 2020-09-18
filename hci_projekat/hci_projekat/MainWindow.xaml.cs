using hci_projekat.Klase;
using hci_projekat.Prozori;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using static hci_projekat.Klase.Etiketa;
using static hci_projekat.Klase.Spomenik;
using static hci_projekat.Klase.Tip;

namespace hci_projekat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
       //public static ObservableCollection<Klase.Tip> tipovi = new ObservableCollection<Tip>();
      // public static  ObservableCollection<Klase.Etiketa> etikete = new ObservableCollection<Etiketa>();
       public static ObservableCollection<Spomenik> spomenici { get; set; }
        public static ObservableCollection<Spomenik> prebaceniSpomenici { get; set; }

        public Dictionary<Klase.Tip, BitmapImage> tipImageMap = new Dictionary<Tip, BitmapImage>();
        public Dictionary<Klase.Spomenik, BitmapImage> spomenikImageMap = new Dictionary<Spomenik, BitmapImage>();

        public static RepozitorijumEtiketa re { get; set; }
       public static RepozitorijumTip rt { get; set; }
        public static RepozitorijumSpomenika rs { get; set; }

        Point startPoint = new Point();
       

    

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            
            rs = new RepozitorijumSpomenika();
            rt = new RepozitorijumTip();
            re = new RepozitorijumEtiketa();

            spomenici = new ObservableCollection<Spomenik>();
            prebaceniSpomenici = new ObservableCollection<Spomenik>();
            
            List<Spomenik> spom = new List<Spomenik>();

            foreach (KeyValuePair<Guid, Spomenik> s in MainWindow.rs.iscitaj()) {
                if (s.Value.x == 0 && s.Value.y == 0)
                    spomenici.Add(s.Value);
                else
                    prebaceniSpomenici.Add(s.Value);
            }
        }

        public void refreshListView() {
            listViewMapa.ItemsSource = spomenici;
        }

        public void izmeni(Guid kr)
        {
            Console.Write(kr);
           spomenici.Clear();
            canvas.Children.Clear();

            foreach (KeyValuePair<Guid, Spomenik> k in MainWindow.rs.iscitaj())
            {
                if (k.Value.x == 0 && k.Value.y == 0)
                    spomenici.Add(k.Value);
                else
                {
                    prebaceniSpomenici.Add(k.Value);


                    MyImage ikonica = new MyImage
                    {
                        Source = new BitmapImage(new Uri(k.Value.spomenikpath,UriKind.RelativeOrAbsolute)),
                        VerticalAlignment = VerticalAlignment.Center,
                        id = k.Key,
                    };

                    ikonica.Width = 50;
                    ikonica.Height = 50;

                    Canvas.SetLeft(ikonica, k.Value.x - 25);
                    Canvas.SetTop(ikonica, k.Value.x - 25);
                    Canvas.SetBottom(ikonica, k.Value.y - 25);
                    Canvas.SetRight(ikonica, k.Value.y - 25);
                    canvas.Children.Add(ikonica);


                }
            }


        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new hci_projekat.Prozori.DodajTip(this).ShowDialog();
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            new hci_projekat.Prozori.DodajEtiketu(this).ShowDialog();
        }


        //DRAG&DROP
        private void ListView_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }
        private void ListView_MouseMove(object sender, MouseEventArgs e)
        {

            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {


                ListView listView = sender as ListView;
                ListViewItem listViewItem =
                    FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

                Console.Write("\nSource:\n");
                Console.Write(listViewItem);
                try
                {
                    // Find the data behind the ListViewItem
                    Spomenik spomenik = (Spomenik)listView.ItemContainerGenerator.
                        ItemFromContainer(listViewItem);

                    Console.Write("\nSource:\n");
                    Console.Write(spomenik.spomenikpath);
                    Console.Write("\n\n");
                    Console.Write(spomenik.oznakaSpomenik);

                    // Initialize the drag & drop operation
                    Console.Write(spomenik.spomenikpath);
                    DataObject dragData = new DataObject("myFormat", spomenik);
                    DragDrop.DoDragDrop((ListView)e.Source, (ListView)e.Source, DragDropEffects.Move);

                    Console.Write("\n\n\n\n");
                }
                catch (Exception)
                {

                }
            }
        }

       /* public void loadMap()
        {

            foreach (KeyValuePair<Guid, Spomenik> sp in rs.iscitaj()) {
                spomenikImageMap.Add(sp, sp.Value.ikonicaR);

            }

            Console.WriteLine("Usao");
            foreach (Spomenik s in spomenici)
            {
                Console.WriteLine("Usao");
                if (!String.Equals(s.locationX, "-") && !String.Equals(s.locationY, "-"))
                {

                    Console.WriteLine("Prva " + s.locationX + "Druga " + s.locationY);
                    Image i = new Image();
                    i.Source = spomenikImageMap[s];
                    i.Width = 64;
                    i.Height = 64;
                    i.Stretch = Stretch.None;
                    canvas.Children.Add(i);
                    Canvas.SetLeft(i, Convert.ToDouble(s.locationX) - 32);
                    Canvas.SetTop(i, Convert.ToDouble(s.locationY) - 32);
                    Console.WriteLine(s.oznakaSpomenik);
                    
                }
            }
        }
        */
        private void Canvas_Drop(object sender, DragEventArgs e)
        {
            Point p = e.GetPosition(canvas);
            if (e.Data.GetDataPresent("myFormat") && p.X < canvas.Width - 32 && p.Y < canvas.Height - 32)
            {
                Spomenik s = e.Data.GetData("myFormat") as Spomenik;
                Spomenik old = s;
                if (String.Equals(s.locationX, "-") && String.Equals(s.locationY, "-"))
                {
                    Image i = new Image();
                    i.Source = spomenikImageMap[s];
                    i.Width = 64;
                    i.Height = 64;
                    i.Stretch = Stretch.None;
                    canvas.Children.Add(i);
                    //Point p = PointToScreen();
                    //Point p = Mouse.GetPosition(this);
                    Console.WriteLine(p.X + " " + p.Y);
                    Canvas.SetLeft(i, p.X - 32);
                    Canvas.SetTop(i, p.Y - 32);
                    Console.WriteLine(s.oznakaSpomenik);
                    s.locationX = p.X.ToString();
                    s.locationY = p.Y.ToString();
                    RepozitorijumSpomenika r = new RepozitorijumSpomenika();

                    r.azurirajMapu(s, s.locationX, s.locationY);


                }

            }

            foreach (Spomenik s in spomenici)
            {
                Console.WriteLine(s.locationX);
                Console.WriteLine(s.locationY);
            }
        }
        private void ListView_DragEnter(object sender, DragEventArgs e)
        {
            if (!e.Data.GetDataPresent("myFormat") || sender == e.Source)
            {
                e.Effects = DragDropEffects.None;
            }
        }

        private void ListView_Drop(object sender, DragEventArgs e)
        {
            //Image image = e.Source as Image;

            Point p = e.GetPosition(canvas);

            var source = e.Data.GetData("System.Windows.Controls.ListView") as ListView;

            Console.Write("\n\n\n");
            Console.Write(source.ToString());
            Console.Write("\n");

            var spomenik = source.SelectedItem as Spomenik;
            Console.Write("\nProba:\n");
            Console.Write(spomenik.spomenikpath);


            MyImage ikonica = new MyImage
            {
                Source = new BitmapImage(new Uri(spomenik.spomenikpath, UriKind.RelativeOrAbsolute)),
                VerticalAlignment = VerticalAlignment.Center,
                id =spomenik.ID,
            };

            ikonica.ToolTip = "Oznaka: " + spomenik.oznakaSpomenik + "\n" + "Naziv:" + spomenik.nazivSpomenik;
            //ikonica.ToolTip = spomenik.nazivSpomenik;

            base.OnDrop(e);
            try
            {

                Point mousePos = e.GetPosition(canvas);
                ikonica.Width = 50;
                ikonica.Height = 50;

                //Point mouse = new Point(pk.x, pk.y);
                Console.Write("\nOvo je dropovana ikonica:\n");
                Console.Write(mousePos.X);
                Console.Write("\n\n");
                Console.Write(mousePos.Y);
                Console.Write("\n\n");

                Canvas.SetLeft(ikonica, mousePos.X - 25);
                Canvas.SetTop(ikonica, mousePos.Y - 25);
                Canvas.SetBottom(ikonica, mousePos.X - 25);
                Canvas.SetRight(ikonica, mousePos.Y - 25);

                Console.Write("\nDodata slika:\n");
                Console.Write(ikonica.id);

                spomenik.x = mousePos.X;
                spomenik.y = mousePos.Y;

                MainWindow.rs.izmeni(spomenik.ID, spomenik);

                foreach (KeyValuePair<Guid, Spomenik> kr in MainWindow.rs.iscitaj())
                {
                    if (kr.Key.Equals(ikonica.id))
                    {
                       
                    }
                }
                prebaceniSpomenici.Add(spomenik);
                canvas.Children.Add(ikonica);
                e.Handled = true;

            }
            catch (Exception)
            {
                Console.Write("\nVan granica ste!\n");
                MessageBox.Show("Otišli ste van granica!");
            }


          // ((ObservableCollection<Spomenik>)source.ItemsSource).Remove(spomenik);
        }

        private void Icon_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }
        MyImage vucemo;
        Point mousePos = new Point();
        private void canvas_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

            MyImage slika = e.Source as MyImage;

            if (slika != null && canvas.CaptureMouse())
            {
                mousePos = e.GetPosition(canvas);
                vucemo = slika;
            }
        }

        Point end = new Point();

        private void canvas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

            canvas.ReleaseMouseCapture();
            end = e.GetPosition(canvas);


            Console.Write("\n");
            Console.Write("\nKooridinate enda:\n");
            Console.Write(end.X);
            Console.Write("\n\n");
            Console.Write(end.Y);

            bool moze = false;


            if (vucemo != null && end.X <= canvas.ActualWidth - 25 && end.Y <= canvas.ActualHeight - 25 && end.X >= 25 && end.Y >= 25 && (Math.Abs(end.X) > SystemParameters.MinimumHorizontalDragDistance || Math.Abs(end.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                Console.Write("\nUsao u promenu!\n");
                foreach (KeyValuePair<Guid, Spomenik> kr in MainWindow.rs.iscitaj())
                {

                    Spomenik spomenik = kr.Value;
                    if (spomenik.ID.Equals(vucemo.id))
                    {
                        spomenik.x = end.X;
                        spomenik.y = end.Y;
                        prebaceniSpomenici.Add(spomenik);
                        MainWindow.rs.izmeni(vucemo.id, spomenik);
                        break;
                    }
                }



                foreach (Spomenik kr in prebaceniSpomenici)
                {
                    foreach (MyImage img in canvas.Children)
                    {
                        if (kr.ID.Equals(img.id) && !img.id.Equals(vucemo.id))
                        {
                            Console.Write("\nKoordinate deteta\n");
                            Console.Write(kr.x);
                            Console.Write("\n\n");
                            Console.Write(kr.y);

                            if (end.X > kr.x - 25 && end.X < kr.x + 25 && end.Y > kr.y - 25 && end.Y < kr.y + 25)
                                moze = true;

                        }
                    }

                }
                if (!moze)
                {


                    Canvas.SetLeft(vucemo, end.X - 25);
                    Canvas.SetTop(vucemo, end.Y - 25);
                    Canvas.SetBottom(vucemo, end.X - 25);
                    Canvas.SetRight(vucemo, end.Y - 25);


                }
                else
                {
                    MessageBox.Show("Ne mogu da se preklapaju ikonice!");

                }

                prebaceniSpomenici.Clear();

                foreach (KeyValuePair<Guid, Spomenik> kr in MainWindow.rs.iscitaj())
                {
                    if (kr.Value.x != 0 && kr.Value.y != 0)
                    {
                        prebaceniSpomenici.Add(kr.Value);
                    }
                }
            }

            vucemo = null;

        }
        public string _tooltip;

        public string tooltip
        {
            get
            {
                return _tooltip;
            }

            set
            {
                if (_tooltip != value)
                {
                    _tooltip = value;
                    OnPropertyChanged("tooltip");
                }
            }
        }
        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            end = e.GetPosition(canvas);

            bool nasao = false;

            foreach (Spomenik kr in prebaceniSpomenici)
            {
                if (end.X >= kr.x - 25 && end.X <= kr.x + 25 && end.Y >= kr.y - 25 && end.Y <= kr.y + 25)
                {
                    foreach (MyImage img in canvas.Children)
                    {
                        if (kr.ID.Equals(img.id))
                        {
                            nasao = true;
                            tooltip = kr.oznakaSpomenik;
                        }
                    }
                }
            }

            if (!nasao)
                tooltip = "";


            if (vucemo != null)
            {
                Console.Write("\nPomeramo sliku sa id:\n");
                Console.Write(vucemo.id);

            }


        }

        private void Canvas_DragOver(object sender, DragEventArgs e)
        {

        }

        private void listViewMapa_MouseMove(object sender, MouseEventArgs e)
        {
            Point mousePos = e.GetPosition(null);
            Vector diff = startPoint - mousePos;

            if (e.LeftButton == MouseButtonState.Pressed &&
                (Math.Abs(diff.X) > SystemParameters.MinimumHorizontalDragDistance ||
                Math.Abs(diff.Y) > SystemParameters.MinimumVerticalDragDistance))
            {
                // Get the dragged ListViewItem
                ListView listView = sender as ListView;
                ListViewItem listViewItem =
                    FindAncestor<ListViewItem>((DependencyObject)e.OriginalSource);

                // Find the data behind the ListViewItem
                Spomenik s = (Spomenik)listView.ItemContainerGenerator.
                    ItemFromContainer(listViewItem);

                // Initialize the drag & drop operation
                DataObject dragData = new DataObject("myFormat", s);
                DragDrop.DoDragDrop(listViewItem, dragData, DragDropEffects.Move);
            }


        }


        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }
      
        private void listViewMapa_Drop(object sender, DragEventArgs e)
        {

        }

        private void listViewMapa_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            startPoint = e.GetPosition(null);
        }

        private void listViewMapa_PreviewMouseMove(object sender, MouseEventArgs e)
        {

        }

        public void refreshSListMain()
        {
            listViewMapa.ItemsSource = spomenici;
            //treeSpomenik.ItemsSource = spomenici;
        }

        /* private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
         {
             Spomenik m = (Spomenik)dataGrid1.SelectedItem;
             if (m != null)
             {

                 //slikaman.Source = spomenikImageMap[m];

             }


         }
         */
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            var s = new Prozori.DodajSpomenik();
            s.Show();
            //frame.Content = new DodavanjeSpomenika(this, tipovi,etikete);
        }

       

        /* private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
         {
             IInputElement focusedControl = FocusManager.GetFocusedElement(Application.Current.Windows[0]);
             if (focusedControl is DependencyObject)
             {
                 string str = HelpSystem.HelpProvider.GetHelpKey((DependencyObject)focusedControl);
                 HelpSystem.HelpProvider.ShowHelp(str, this);
             }
         }
         */
        public void doThings(string param)
        {
            //btnOK.Background = new SolidColorBrush(Color.FromRgb(32, 64, 128));
            Title = param;
        }

        private void tabcontrol_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

       

        private void Button_Click_4(object sender, RoutedEventArgs e) {
            new hci_projekat.Prozori.DodajEtiketu(this).ShowDialog();
        }



        private void AddPresetButton_Click(object sender, RoutedEventArgs e)
        {
            var addButton = sender as FrameworkElement;
            if (addButton != null)
            {
                addButton.ContextMenu.IsOpen = true;
            }
        }

        private void DropDownButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
             new hci_projekat.Prozori.PregledSpomenik(this).ShowDialog();
            //frame.Content = new PregledSpomenik();
            //vidljivostLista = Visibility.Hidden;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        private void odjava(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Hidden;
            var s = new hci_projekat.Logging();
            s.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            new hci_projekat.HelpSystem.HelpViewer("Pomoc", this).ShowDialog();
        }
        private void Spomenik_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
        private void Spomenik_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var s = new Prozori.DodajSpomenik();
            s.Show();
        }

        private void Etiketa_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Etiketa_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var s = new Prozori.DodajEtiketu(this);
            s.Show();
        }

        private void Tip_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Tip_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var s = new Prozori.DodajTip(this);
            s.Show();
        }
        private void Pregled_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Pregled_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            var s = new Prozori.PregledSpomenik(this);
            s.Show();

        }
        private void Pomoc_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void Pomoc_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            new hci_projekat.HelpSystem.HelpViewer("Pomoc", this).ShowDialog();
        }

        public void obrisiLista(Spomenik spom)
        {
            spomenici.Clear();
            foreach (KeyValuePair<Guid, Spomenik> kr in MainWindow.rs.iscitaj())
            {
                if (kr.Value.x == 0 && kr.Value.y == 0)
                    spomenici.Add(kr.Value);
            }

        }
    }

}

