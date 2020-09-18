using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace hci_projekat
{
    public static class Mnemonic
    {


        public static readonly RoutedUICommand DelS = new RoutedUICommand(
            "DelS",
            "DelS",
            typeof(Mnemonic),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Delete)
            }
            );

        public static readonly RoutedUICommand DelE = new RoutedUICommand(
            "DelE",
            "DelE",
            typeof(Mnemonic),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Delete)
            }
            );

        public static readonly RoutedUICommand DelT = new RoutedUICommand(
            "DelT",
            "DelT",
            typeof(Mnemonic),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Delete)
            }
            );

        public static readonly RoutedUICommand EnterF = new RoutedUICommand(
            "EnterRe",
            "EnterRe",
            typeof(Mnemonic),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Enter)
            }
            );


        public static readonly RoutedUICommand EnterRe = new RoutedUICommand(
            "EnterRe",
            "EnterRe",
            typeof(Mnemonic),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Enter)
            }
            );


        public static readonly RoutedUICommand EnterT = new RoutedUICommand(
            "EnterT",
            "EnterT",
            typeof(Mnemonic),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Enter)
            }
            );

        public static readonly RoutedUICommand EnterR = new RoutedUICommand(
            "EnterR",
            "EnterR",
            typeof(Mnemonic),
            new InputGestureCollection()
            {
                new KeyGesture(Key.Enter)
            }
            );


        public static readonly RoutedUICommand Spomenik = new RoutedUICommand(
            "Spomenik",
            "Spomenik",
            typeof(Mnemonic),
            new InputGestureCollection()
            {
                new KeyGesture(Key.S, ModifierKeys.Control)
            }
            );
        public static readonly RoutedUICommand Pomoc = new RoutedUICommand(
            "Pomoc",
            "Pomoc",
            typeof(Mnemonic),
            new InputGestureCollection()
            {
                new KeyGesture(Key.H, ModifierKeys.Control)
            }
            );
        public static readonly RoutedUICommand Pregled = new RoutedUICommand(
           "Pregled",
           "Pregled",
           typeof(Mnemonic),
           new InputGestureCollection()
           {
                new KeyGesture(Key.P, ModifierKeys.Control)
           }
           );

        public static readonly RoutedUICommand Etiketa = new RoutedUICommand(
            "Etiketa", "Etiketa", typeof(Mnemonic),
            new InputGestureCollection()
            {
                new KeyGesture(Key.E, ModifierKeys.Control)
            }
            );

        public static readonly RoutedCommand Tip = new RoutedUICommand(
            "Tip", "Tip", typeof(Mnemonic),
            new InputGestureCollection()
            {
                new KeyGesture(Key.T, ModifierKeys.Control)
            }

            );


        public static readonly RoutedCommand tabelaEtiketa = new RoutedUICommand(
            "tabelaE", "tabelaE", typeof(Mnemonic),
            new InputGestureCollection()
            {
                new KeyGesture(Key.S, ModifierKeys.Control)
            }
            );

        public static readonly RoutedCommand tabelaTipova = new RoutedUICommand(
            "tabelaT", "tabelaT", typeof(Mnemonic),
            new InputGestureCollection()
            {
                new KeyGesture(Key.D, ModifierKeys.Control)
            }

            );

        public static readonly RoutedCommand tabelaResursa = new RoutedUICommand(
            "tabelaR", "tabelaR", typeof(Mnemonic),
            new InputGestureCollection()
            {
                new KeyGesture(Key.A , ModifierKeys.Control)
            }
            );
    }
}
