using System;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Text;

namespace hci_projekat
{
    public class MyImage : Image
    {
        public Guid id;

        public MyImage() {

        }

        public Guid getId()
        {
            return id;
        }

        public void setId(Guid id)
        {
            this.id = id;
        }

    }
}