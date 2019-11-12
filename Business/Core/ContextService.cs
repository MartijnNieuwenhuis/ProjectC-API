using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using DAL;

namespace Business.Core
{
    public class ContextService : IDisposable
    {
        internal Context Context { get; private set; }

        #region Constructor

        public ContextService()
        {
            this.Context = new Context();
        }

        public ContextService(Context context)
        {
            this.Context = context;
        }

        #endregion

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.Context.Dispose();
            }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }

        public static void SetDbInitializer()
        {
            Context.SetInitializer();
        }
    }
}