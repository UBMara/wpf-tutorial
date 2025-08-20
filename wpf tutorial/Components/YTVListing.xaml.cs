using System;
using System.Collections.Generic;
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
using wpf_tutorial.Stores;
using wpf_tutorial.ViewModels;

namespace wpf_tutorial.Components
{
    /// <summary>
    /// Interaction logic for YTVListing.xaml
    /// </summary>
    public partial class YTVListing : UserControl
    {
        public YTVListing()
        {
            InitializeComponent();
            if (DataContext == null)
            {
                DataContext = new YTVListingModelView(new SelectedYTVStore());
            }
        }

        public YTVListing(SelectedYTVStore selectedYTViewer)
        {
            InitializeComponent();
            DataContext = new YTVListingModelView(selectedYTViewer);
        }
    }
}
