using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_tutorial.Stores;
using wpftutorial.Domain.Models;
using System.Windows.Input;
using wpf_tutorial.Commands;
using System.Collections.Specialized;

namespace wpf_tutorial.ViewModels
{
    public class YTVListingModelView : ViewModelBase
    {
        private readonly YTVStore _ytvStore;
        private readonly SelectedYTVStore _selectedYTViewerStore;
        private readonly ModelNavigationStore _modelNavigationStore;
        private readonly ObservableCollection<YTVLItemsViewModel> _ytvListingModelsView;

        public IEnumerable<YTVLItemsViewModel> YTVListingModelsView => _ytvListingModelsView;


        public YTVLItemsViewModel SelectedYTVListingItemViewModel
        {
            get { return _ytvListingModelsView.FirstOrDefault(y => y.YTViewer?.Id == _selectedYTViewerStore.SelectedYTViewer?.Id); }
            
            set
            {
                _selectedYTViewerStore.SelectedYTViewer = value?.YTViewer;
                OnPropertyChanged(nameof(SelectedYTVListingItemViewModel));
            }
        }

        public YTVListingModelView(YTVStore ytvStore, SelectedYTVStore selectedYTViewer, ModelNavigationStore modelNavigationStore)
        {
            _ytvStore = ytvStore;
            _selectedYTViewerStore = selectedYTViewer;
            _modelNavigationStore = modelNavigationStore;
            _ytvListingModelsView = new ObservableCollection<YTVLItemsViewModel>();

            _selectedYTViewerStore.SelectedYTVChanged += SelectedYTVStore_SelectedYTViewerChanged;

            _ytvStore.YTVLoaded += ytvStore_YTVLoaded;
            _ytvStore.YTVAddedEvent += ytvStore_YTVAddedEvent;
            _ytvStore.YTVUpdated += ytvStore_YTVUpdated;
            _ytvStore.YTVDeleted += ytvStore_YTVDeleted;

            _ytvListingModelsView.CollectionChanged += YtvListingModelsView_CollectionChanged;
        }

        private void YtvListingModelsView_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(SelectedYTVListingItemViewModel));
        }

        private void SelectedYTVStore_SelectedYTViewerChanged()
        {
            OnPropertyChanged(nameof(SelectedYTVListingItemViewModel));
        }

        private void ytvStore_YTVDeleted(Guid id)
        {
            var itemViewModel = _ytvListingModelsView.FirstOrDefault(y => y.YTViewer?.Id == id);

            if(itemViewModel != null)
            {
                _ytvListingModelsView.Remove(itemViewModel);
            }
        }

        private void ytvStore_YTVLoaded()
        {
            _ytvListingModelsView.Clear();

            foreach (YTViewer viewer in _ytvStore.YTViewers)
            {
                AddYTViewr(viewer);
            }
        }

        private void ytvStore_YTVUpdated(YTViewer viewer)
        {
            YTVLItemsViewModel ytvModel =  _ytvListingModelsView.FirstOrDefault(y => y.YTViewer.Id == viewer.Id);

            if( ytvModel != null)
            {
                ytvModel.Update(viewer);
            }
        }
        protected override void Dispose()
        {
            _selectedYTViewerStore.SelectedYTVChanged -= SelectedYTVStore_SelectedYTViewerChanged;
            _ytvStore.YTVLoaded -= ytvStore_YTVLoaded;
            _ytvStore.YTVAddedEvent -= ytvStore_YTVAddedEvent;
            _ytvStore.YTVUpdated -= ytvStore_YTVUpdated;
            _ytvStore.YTVDeleted -= ytvStore_YTVDeleted;

            base.Dispose();
        }

        private void ytvStore_YTVAddedEvent(YTViewer viewer)
        {
            AddYTViewr(viewer);
        }

        private void AddYTViewr(YTViewer ytViewr)
        {
            YTVLItemsViewModel itemsViewModel = new YTVLItemsViewModel(ytViewr, _ytvStore, _modelNavigationStore);

            _ytvListingModelsView.Add(itemsViewModel);
        }

    }
}
