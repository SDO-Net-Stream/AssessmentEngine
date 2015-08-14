using System;
using System.Web.Mvc;
using Olts.DataAccess;

namespace Olts.WebUi.Controllers.Base
{
    public abstract class OltsControllerBase : Controller
    {
        protected OltsControllerBase()
            : base()
        {
            _context = new OltsContext();
        }

        // TODO: This should be refactored in order to inject context using some DI framework
        protected OltsContext Context
        {
            get { return _context; }   
        }
        
        protected override void Dispose(Boolean disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private readonly OltsContext _context;
    }
}
