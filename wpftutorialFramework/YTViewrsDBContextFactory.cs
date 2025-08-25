using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpftutorialFramework
{
    public class YTViewrsDBContextFactory
    {
        private readonly DbContextOptions _options;

        public YTViewrsDBContextFactory(DbContextOptions options)
        {
            _options = options;
        }

        public YTViewrsDBContext Create()
        {
            return new YTViewrsDBContext(_options);
        }
    }
}
