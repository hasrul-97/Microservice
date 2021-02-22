using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TenantManager.Abstraction.Business;
using TenantManager.Entities;

namespace TenantManager.Controllers
{
    [Route("{tenant}")]
    [ApiController]
    public class TenantController : ControllerBase
    {
        private readonly IBusinessManager _businessManager;
        public TenantController(IBusinessManager businessManager)
        {
            _businessManager = businessManager;
        }

        [HttpGet]
        public async Task<Tenant> GetTenantDetails(string tenant)
        {
            return await _businessManager.GetRootFolderDetails(tenant,"M1056247");
        }

        [HttpGet]
        [Route("Token")]
        public async Task<string> GetToken(string tenant)
        {
            return await _businessManager.GenerateToken();
        }
    }
}
