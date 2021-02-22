using DMSAPI.Entities;
using DMSAPI.Entities.ReadonlyConstants;
using DMSAPI.ServiceWrapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMSApi.Controllers
{
    [Route("{tenant}")]
    [ApiController]
    public class DMSAPIController : ControllerBase
    {
        private readonly TenantServiceWrapper _tenantService;
        private readonly FolderServiceWrapper _folderService;
        private readonly FolderCopyMoveServiceWrapper _folderCopyMoveService;
        public DMSAPIController(TenantServiceWrapper tenantServiceWrapper, FolderServiceWrapper folderServiceWrapper, FolderCopyMoveServiceWrapper folderCopyServiceWrapper)
        {
            _tenantService = tenantServiceWrapper;
            _folderService = folderServiceWrapper;
            _folderCopyMoveService = folderCopyServiceWrapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetFolderContents(string tenant)
        {
            if (!string.IsNullOrEmpty(tenant))
            {
                Tenant tenantDetail = await _tenantService.GetTenantAsync(tenant);
                if (tenantDetail != null)
                {
                    return Ok(await _folderService.GetAsync(tenantDetail.TenantID, tenantDetail.UserID, tenantDetail.RootFolderID));
                }
            }
            return BadRequest(ResponseMessage.User_Not_Found);
        }

        [HttpGet]
        [Route("{folderId}")]
        public async Task<IActionResult> GetFolderContents(string tenant, string folderId)
        {
            if (!string.IsNullOrEmpty(tenant))
            {
                Tenant tenantDetail = await _tenantService.GetTenantAsync(tenant);
                if (tenantDetail != null)
                {
                    return Ok(await _folderService.GetAsync(tenantDetail.TenantID, tenantDetail.UserID, folderId));
                }
            }
            return BadRequest(ResponseMessage.User_Not_Found);
        }


        [HttpPost]
        [Route("CreateFolder")]
        public async Task<IActionResult> CreateFolder(string tenant, [FromBody] FolderDetail folder)
        {
            if (!string.IsNullOrEmpty(tenant))
            {
                Tenant tenantDetail = await _tenantService.GetTenantAsync(tenant);
                if (tenantDetail != null)
                {
                    return Ok(await _folderService.CreateAsync(folder));
                }
            }
            return BadRequest(ResponseMessage.User_Not_Found);
        }

        [HttpPut]
        [Route("RenameFolder")]
        public async Task<IActionResult> RenameFolder(string tenant, [FromBody] FolderManager folder)
        {
            if (!string.IsNullOrEmpty(tenant))
            {
                Tenant tenantDetail = await _tenantService.GetTenantAsync(tenant);
                if (tenantDetail != null)
                {
                    return Ok(await _folderService.RenameAsync(folder));
                }
            }
            return BadRequest(ResponseMessage.User_Not_Found);
        }

        [HttpDelete]
        [Route("DeleteFolder")]
        public async Task<IActionResult> DeleteFolder(string tenant, [FromBody] FolderDetail folder)
        {
            if (!string.IsNullOrEmpty(tenant))
            {
                Tenant tenantDetail = await _tenantService.GetTenantAsync(tenant);
                if (tenantDetail != null)
                {
                    return Ok(await _folderService.DeleteAsync(folder));
                }
            }
            return BadRequest(ResponseMessage.User_Not_Found);
        }

        [HttpPost]
        [Route("Folder/Copy")]
        public async Task<IActionResult> Copy(string tenant, [FromBody] CopyMoveAttributes detail)
        {
            Tenant tenantDetail = await _tenantService.GetTenantAsync(tenant);
            if (tenantDetail != null)
            {
                return Ok(await _folderCopyMoveService.InvokeCopyAsync(detail.SourceFolders, detail.Target, detail.UserID, detail.ConnectionID, detail.CanMerge));
            }
            else
            {
                return BadRequest(ResponseMessage.User_Not_Found);
            }
        }

        [HttpPost]
        [Route("Folder/Move")]
        public async Task<IActionResult> Move(string tenant, [FromBody] CopyMoveAttributes detail)
        {
            Tenant tenantDetail = await _tenantService.GetTenantAsync(tenant);
            if (tenantDetail != null)
            {
                return Ok(await _folderCopyMoveService.InvokeMoveAsync(detail.SourceFolders, detail.Target, detail.UserID, detail.ConnectionID, detail.CanMerge, tenantDetail.TenantID));
            }
            else
            {
                return BadRequest(ResponseMessage.User_Not_Found);
            }
        }

        [HttpPost]
        [Route("File/Save")]
        public async Task<IActionResult> Save(string tenant, [FromBody] FileDetail file)
        {
            Tenant tenantDetail = await _tenantService.GetTenantAsync(tenant);
            if (tenantDetail != null)
            {
                return Ok(await _folderService.CreateAsync(file));
            }
            else
            {
                return BadRequest(ResponseMessage.User_Not_Found);
            }
        }

        [HttpGet]
        [Route("Token")]
        public async Task<IActionResult> GetToken(string tenant)
        {
            if (!string.IsNullOrEmpty(tenant))
            {
                Tenant tenantDetail = await _tenantService.GetTenantAsync(tenant);
                if (tenantDetail != null)
                {
                    return Ok(await _tenantService.GetTokenAsync(tenant));
                }
            }
            return BadRequest(ResponseMessage.User_Not_Found);
        }
    }
}
