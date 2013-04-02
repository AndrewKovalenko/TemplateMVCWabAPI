using System;

namespace ProjectTemplate.Infrastructure.Common
{
    public abstract class Disposable : IDisposable
    {
        private bool _disposed = false;

        public void Dispose()
        {
            ClealUp();
            GC.SuppressFinalize(this);
        }

        private void ClealUp()
        {
            if(!this._disposed)
            {
                DisposeUnmanagedResourses();
            }

            _disposed = true;
        }

        protected abstract void DisposeUnmanagedResourses();
        
        ~Disposable()
        {
            ClealUp();
        }
    }
}