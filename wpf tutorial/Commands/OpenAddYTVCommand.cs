using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using wpftutorial.Domain.Models;
using wpf_tutorial.Stores;
using wpf_tutorial.ViewModels;
using wpf_tutorial.Views;

namespace wpf_tutorial.Commands
{
    public class OpenAddYTVCommand : CommandBase
    {
        private readonly YTVStore _ytvStore;
        private readonly ModelNavigationStore _modelNavigationStore;

        public OpenAddYTVCommand(YTVStore ytvStore, ModelNavigationStore modelNavigationStore)
        {
           _ytvStore = ytvStore;
            _modelNavigationStore = modelNavigationStore;
        }

        public override void Execute(object parameter)
        {
            AddYTVViewModel editYTVViewModel = new AddYTVViewModel(_ytvStore, _modelNavigationStore);

            _modelNavigationStore.CurrentViewModel = editYTVViewModel;
        }
    }
}
