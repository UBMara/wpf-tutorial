using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_tutorial.Stores;
using wpf_tutorial.Models;

namespace wpf_tutorial.ViewModels
{
    internal class YTVListingModelView : ViewModelBase
    {
        private readonly SelectedYTVStore _selectedYTViewerStore;

        private readonly ObservableCollection<YTVLItemsViewModel> _ytvListingModelsView;

        public IEnumerable<YTVLItemsViewModel> YTVListingModelsView => _ytvListingModelsView;

        private YTVLItemsViewModel _selectedYTVListingItemViewModel;

        public YTVLItemsViewModel SelectedYTVListingItemViewModel
        {
            get { return _selectedYTVListingItemViewModel; }
            
            set
            {
                _selectedYTVListingItemViewModel = value;
                OnPropertyChanged(nameof(SelectedYTVListingItemViewModel));

                _selectedYTViewerStore.SelectedYTViewer = _selectedYTVListingItemViewModel?.YTViewer;
            }
        }

        public YTVListingModelView(SelectedYTVStore selectedYTViewer)
        {
            _selectedYTViewerStore = selectedYTViewer;
            _ytvListingModelsView = new ObservableCollection<YTVLItemsViewModel>();

            _ytvListingModelsView.Add(new YTVLItemsViewModel(new YTViewer("Mary", true, false)));
            _ytvListingModelsView.Add(new YTVLItemsViewModel(new YTViewer("John", false, false)));
            _ytvListingModelsView.Add(new YTVLItemsViewModel(new YTViewer("Alice", true, true)));
            
        }

    }
}
