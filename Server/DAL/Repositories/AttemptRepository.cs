using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public class AttemptRepository
    {
        private readonly ApplicationContext context;
        public AttemptRepository(ApplicationContext context)
        {
            this.context = context;
        }
    }
}
