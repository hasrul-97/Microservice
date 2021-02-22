using DMSOperationManager.Abstraction.Business;
using DMSOperationManager.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMSOperationManager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CopyController : ControllerBase
    {
        private readonly ICopyHandler _copyHandler;
        public CopyController(ICopyHandler copyHandler)
        {
            _copyHandler = copyHandler;
        }

        [HttpPost]
        public async Task<string> Copy(CopyAttributes detail)
        {
            return await _copyHandler.Copy(detail);
        }
    }
}
