using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpftutorial.Domain.Commands;
using wpftutorial.Domain.Models;
using wpftutorialFramework.DTOs;

namespace wpftutorialFramework.Commands
{
    public class UpdateViewerCommand : IUpdateCommand
    {
        private readonly YTViewrsDBContextFactory _contextFactory;
        public UpdateViewerCommand(YTViewrsDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task Execute(YTViewer ytv)
        {
            using (YTViewrsDBContext context = _contextFactory.Create())
            {

                YTViewerDTO ytvDTO = new YTViewerDTO
                {
                    Id = ytv.Id,
                    UserName = ytv.UserName,
                    IsSubscribed = ytv.IsSubscribed,
                    IsMember = ytv.IsMember
                };
                context.YTViewers.Update(ytvDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}
