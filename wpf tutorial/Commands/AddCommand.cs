using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpftutorial.Domain.Models;
using wpf_tutorial.Stores;
using wpf_tutorial.ViewModels;

namespace wpf_tutorial.Commands
{
    public class AddCommand : AsyncCommandBase
    {
        private readonly AddYTVViewModel _addYTVViewModel;
        private readonly YTVStore _ytvStore;
        private readonly ModelNavigationStore _modelNavigationStore;
        public AddCommand(AddYTVViewModel addYTVViewModel, YTVStore ytvStore, ModelNavigationStore modelNavigationStore)
        {
            _addYTVViewModel = addYTVViewModel;
            _ytvStore = ytvStore;
            _modelNavigationStore = modelNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            YTVDetailsFormViewModel formViewModel = _addYTVViewModel.YTVDetailsFormViewModel;

            formViewModel.ErrorMessage = null;
            formViewModel.IsSubmitting = true;

            YTViewer ytv = new YTViewer(
                Guid.NewGuid(),
                formViewModel.UserName,
                formViewModel.IsSubscribed,
                formViewModel.IsMember);

            try
            {
                await _ytvStore.Add(ytv);
                _modelNavigationStore.Close();
            }
            catch (Exception) { formViewModel.ErrorMessage = "Failed to add"; }
            finally
            {
                formViewModel.IsSubmitting = false;

            }
        }
    }
}
