using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpftutorial.Domain.Models;
using wpf_tutorial.Stores;
using wpf_tutorial.ViewModels;
using wpf_tutorial.Views;

namespace wpf_tutorial.Commands
{
    public class OpenEditCommand : CommandBase
    {
        private readonly YTVLItemsViewModel _yTVLItemsViewModel;
        private readonly YTVStore _ytvStore;
        private readonly ModelNavigationStore _modelNavigationStore;

        public OpenEditCommand(YTVLItemsViewModel yTVLItemsViewModel, YTVStore ytvStore, ModelNavigationStore modelNavigationStore)
        {
            _yTVLItemsViewModel = yTVLItemsViewModel;
            _ytvStore = ytvStore;
            _modelNavigationStore = modelNavigationStore;
        }

        public override void Execute(object parameter)
        {
            YTViewer viewer = _yTVLItemsViewModel.YTViewer;

            EditYTVViewModel addYTVViewModel = new EditYTVViewModel(viewer, _ytvStore ,_modelNavigationStore);

            _modelNavigationStore.CurrentViewModel = addYTVViewModel;
        }
    }
}
