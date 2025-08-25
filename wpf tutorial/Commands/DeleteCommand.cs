using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_tutorial.Stores;
using wpf_tutorial.ViewModels;
using wpftutorial.Domain.Models;

namespace wpf_tutorial.Commands
{
    public class DeleteCommand : AsyncCommandBase
    {
        private readonly YTVLItemsViewModel _yTVLItemsViewModel;
        private readonly YTVStore _ytvStore;

        public DeleteCommand(YTVLItemsViewModel yTVLItemsViewModel, YTVStore ytvStore)
        {
            _yTVLItemsViewModel = yTVLItemsViewModel;
            _ytvStore = ytvStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _yTVLItemsViewModel.IsDeleting = true;
            _yTVLItemsViewModel.ErrorMessage = null;

            YTViewer viewer = _yTVLItemsViewModel.YTViewer;

            try
            {
                await _ytvStore.Delete(viewer.Id);
            }
            catch (Exception) { _yTVLItemsViewModel.ErrorMessage = "Failed to delete"; }
            finally { _yTVLItemsViewModel.IsDeleting = false; }
            }
    }
}
