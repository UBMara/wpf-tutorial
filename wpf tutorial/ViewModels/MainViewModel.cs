using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_tutorial.Stores;

namespace wpf_tutorial.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly ModelNavigationStore _modelNavigationStore;

        public ViewModelBase CurrentViewModel => _modelNavigationStore.CurrentViewModel;

        public bool IsModelOpen => _modelNavigationStore.IsOpen;

        public YTVViewModel YTVViewModel { get; }


        public MainViewModel(ModelNavigationStore modelNavigationStore, YTVViewModel yTVViewModel)
        {
            _modelNavigationStore = modelNavigationStore;
            YTVViewModel = yTVViewModel;

            _modelNavigationStore.CurrentViewModelChanged += ModelNavigationStore_CurrentViewModelChanged;
        }

        private void ModelNavigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
            OnPropertyChanged(nameof(IsModelOpen));
        }
    }
}
