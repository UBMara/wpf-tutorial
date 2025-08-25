using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpftutorial.Domain.Commands;
using wpftutorialFramework.DTOs;

namespace wpftutorialFramework.Commands
{
    public class DeleteViewerCommand : IDeleteCommand
    {
        private readonly YTViewrsDBContextFactory _contextFactory;

        public DeleteViewerCommand(YTViewrsDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task Execute(Guid id)
        {

            using (YTViewrsDBContext context = _contextFactory.Create())
            {

                YTViewerDTO ytvDTO = new YTViewerDTO
                {
                    Id = id
                };
                context.YTViewers.Remove(ytvDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}
