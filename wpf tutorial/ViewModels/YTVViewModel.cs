using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using wpf_tutorial.Stores;

namespace wpf_tutorial.ViewModels
{
    internal class YTVViewModel :ViewModelBase
    {
        public YTVListingModelView YTVListingModelView { get;}
        public YTVDetailsModelView YTVDetailsModelView { get; }

        public ICommand AddYTViewerCommand { get; }

        public YTVViewModel(SelectedYTVStore _selectedYTViewer)
        {
            YTVListingModelView = new YTVListingModelView(_selectedYTViewer);
            YTVDetailsModelView = new YTVDetailsModelView(_selectedYTViewer);
        }
    }
}
