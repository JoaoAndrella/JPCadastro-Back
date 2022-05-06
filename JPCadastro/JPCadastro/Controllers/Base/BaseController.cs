using JPCadastro.Core.Interfaces.UoW;
using Microsoft.AspNetCore.Mvc;

namespace JPCadastro.Controllers.Base
{
    public abstract class BaseController : ControllerBase
    {
        private readonly IUnitOfWork _uow;

        protected BaseController(IUnitOfWork uow)
        {
            _uow=uow;
        }
    }
}
