using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_tutorial.Stores;
using wpf_tutorial.ViewModels;

namespace wpf_tutorial.Commands
{
    public class LoadCommand : AsyncCommandBase
    {
        private readonly YTVViewModel _yTVViewModel;
        private readonly YTVStore _yTVStore;

        public LoadCommand(YTVViewModel yTVViewModel, YTVStore yTVStore)
        {
            _yTVViewModel = yTVViewModel;
            _yTVStore = yTVStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _yTVViewModel.ErrorMessage = null;
            _yTVViewModel.IsLoading = true;

            try
            {
                await _yTVStore.Load();
            }
            catch (Exception) { _yTVViewModel.ErrorMessage = "Failed to load."; }
            finally { _yTVViewModel.IsLoading = false; }
        }
    }
}
