using Folder.Command.Entities;
using Folder.ServiceWrapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Folder.Command.Controllers
{
    [Route("/{tenant}")]
    [ApiController]
    public class FolderController : ControllerBase
    {
        private readonly UserServiceWrapper _userService;
        private readonly DMSServiceWrapper _dmsService;
        public FolderController(UserServiceWrapper userServiceWrapper, DMSServiceWrapper dmsServiceWrapper)
        {
            _userService = userServiceWrapper;
            _dmsService = dmsServiceWrapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetRootFolder(string tenant)
        {
            string tenantRootFolder = await _userService.GetUserRootFolder(tenant);
            if (!string.IsNullOrEmpty(tenantRootFolder))
            {
                var responseData = await _dmsService.GetFolders(tenant, "M1056247");
                return StatusCode(Convert.ToInt32(responseData.StatusCode), responseData.Content.ReadAsStringAsync().Result);
            }
            else
            {
                return BadRequest("The specified user is not found. Kindly verify your credentials");
            }
        }


        [HttpPost]
        [Route("CreateFolder")]
        public async Task<IActionResult> CreateFolder(string tenant, [FromBody] FolderDetail folder)
        {
            string rootFolderId = await _userService.GetUserRootFolder(tenant);
            if (rootFolderId != "" && rootFolderId != null)
            {
                var responseData = await _dmsService.CreateFolder(folder);
                return StatusCode(Convert.ToInt32(responseData.StatusCode), responseData.Content.ReadAsStringAsync().Result);
            }
            else
            {
                return BadRequest("The specified user is not found. Kindly verify your credentials");
            }
        }

        [HttpPut]
        [Route("RenameFolder")]
        public async Task<IActionResult> RenameFolder(string tenant, [FromBody] FolderManager folder)
        {
            ActionResult response;
            string rootFolderId = await _userService.GetUserRootFolder(tenant);
            if (rootFolderId != "" && rootFolderId != null)
            {
                var responseData = await _dmsService.RenameFolder(folder);
                return StatusCode(Convert.ToInt32(responseData.StatusCode), responseData.Content.ReadAsStringAsync().Result);
            }
            else
            {
                return BadRequest("The specified user is not found. Kindly verify your credentials");
            }
        }

        [HttpDelete]
        [Route("DeleteFolder")]
        public async Task<IActionResult> DeleteFolder(string tenant, [FromBody] FolderDetail folder)
        {
            ActionResult response;
            string rootFolderId = await _userService.GetUserRootFolder(tenant);
            if (rootFolderId != "" && rootFolderId != null)
            {
                var responseData = await _dmsService.DeleteFolder(folder);
                return StatusCode(Convert.ToInt32(responseData.StatusCode), responseData.Content.ReadAsStringAsync().Result);
            }
            else
            {
                return BadRequest("The specified user is not found. Kindly verify your credentials");
            }
        }
    }
}
