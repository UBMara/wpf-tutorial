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
    public class EditCommand : AsyncCommandBase
    {
        private readonly EditYTVViewModel _editYTVViewModel;
        private readonly YTVStore _ytvStore;
        private readonly ModelNavigationStore _modelNavigationStore;
        public EditCommand(EditYTVViewModel editYTVViewModel, YTVStore ytvStore, ModelNavigationStore modelNavigationStore)
        {
            _editYTVViewModel = editYTVViewModel;
            _ytvStore = ytvStore;
            _modelNavigationStore = modelNavigationStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            YTVDetailsFormViewModel formViewModel = _editYTVViewModel.YTVDetailsFormViewModel;

            formViewModel.ErrorMessage = null;
            formViewModel.IsSubmitting = true;

            YTViewer ytv = new YTViewer(
                _editYTVViewModel.viewrID,
                formViewModel.UserName,
                formViewModel.IsSubscribed,
                formViewModel.IsMember);

            try
            {
                await _ytvStore.Update(ytv);
                _modelNavigationStore.Close();
            }
            catch (Exception) { formViewModel.ErrorMessage = "Failed to update"; }
            finally { formViewModel.IsSubmitting = false; }

        }
    }
}
