using ProjectTemplate.Infrastructure.Common;
using ProjectTemplate.Infrastructure.DataBaseContext.Interfaces;

namespace ProjectTemplate.Infrastructure.DataBaseContext
{
    public class DataBaseFactory : Disposable,  IDataBaseFactory
    {
        private ProjectTemplateDbContext _context;

        public ProjectTemplateDbContext GetContext()
        {
            return _context ?? (_context = new ProjectTemplateDbContext());
        }

        protected override void DisposeUnmanagedResourses()
        {
            if(_context != null)
                _context.Dispose();
        }
    }
}