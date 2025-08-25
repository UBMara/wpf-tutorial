using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpf_tutorial.Commands;
using wpftutorial.Domain.Commands;
using wpftutorial.Domain.Models;
using wpftutorial.Domain.Queries;

namespace wpf_tutorial.Stores
{
    public class YTVStore
    {
        private readonly IGetAllYTVQuery _getAllYTVQuery;
        private readonly ICreateCommand _createCommand;
        private readonly IUpdateCommand _updateCommand;
        private readonly IDeleteCommand _deleteCommand;
        private readonly List<YTViewer> _ytviewers;

        public YTVStore(IGetAllYTVQuery getAllYTVQuery, ICreateCommand createCommand, IUpdateCommand updateCommand, IDeleteCommand deleteCommand)
        {
            _getAllYTVQuery = getAllYTVQuery;
            _createCommand = createCommand;
            _updateCommand = updateCommand;
            _deleteCommand = deleteCommand;

            _ytviewers = new List<YTViewer>();

        }

        public IEnumerable<YTViewer> YTViewers => _ytviewers;

        public event Action YTVLoaded;
        public event Action<YTViewer> YTVAddedEvent;
        public event Action<YTViewer> YTVUpdated;
        public event Action<Guid> YTVDeleted;

        public async Task Load()
        {
            IEnumerable<YTViewer> yTViewers = await _getAllYTVQuery.Execute();

            _ytviewers.Clear();
            _ytviewers.AddRange(yTViewers);

            YTVLoaded?.Invoke();
        }

        public async Task Add(YTViewer yTViewer)
        {
            await _createCommand.Execute(yTViewer);

            _ytviewers.Add(yTViewer);
            YTVAddedEvent?.Invoke(yTViewer);
        }

        public async Task Update(YTViewer yTViewer)
        {
            await _updateCommand.Execute(yTViewer);

            int currentIndex = _ytviewers.FindIndex(y => y.Id == yTViewer.Id);

            if (currentIndex != -1)
            {
                _ytviewers[currentIndex] = yTViewer;
            }
            else
            {
                _ytviewers.Add(yTViewer);
            }

                YTVUpdated?.Invoke(yTViewer);
        }

        public async Task Delete(Guid id)
        {
            await _deleteCommand.Execute(id);

            _ytviewers.RemoveAll(y => y.Id == id);

            YTVDeleted?.Invoke(id);
        }

    }
}
