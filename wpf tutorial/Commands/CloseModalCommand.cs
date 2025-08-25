using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_tutorial.Stores;

namespace wpf_tutorial.Commands
{
    public class CloseModalCommand : CommandBase
    {
        private readonly ModelNavigationStore _modelNavigationStore;

        public CloseModalCommand(ModelNavigationStore modelNavigationStore)
        {
            _modelNavigationStore = modelNavigationStore;
        }

        public override void Execute(object parameter)
        {
            _modelNavigationStore.Close();
        }
    }
}
