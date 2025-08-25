using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wpftutorial.Domain.Models;
using wpftutorial.Domain.Queries;
using wpftutorialFramework.DTOs;

namespace wpftutorialFramework.Querues
{
    public class GetAllYTVQuery : IGetAllYTVQuery
    {
        private readonly YTViewrsDBContextFactory _contextFactory;

        public GetAllYTVQuery(YTViewrsDBContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<IEnumerable<YTViewer>> Execute()
        {
            using(YTViewrsDBContext context = _contextFactory.Create())
            {
                IEnumerable<YTViewerDTO> ytvDTOs = await context.YTViewers.ToListAsync();

                return ytvDTOs.Select(y => new YTViewer(
                    y.Id,
                    y.UserName,
                    y.IsSubscribed,
                    y.IsMember));
            }
        }
    }
}
