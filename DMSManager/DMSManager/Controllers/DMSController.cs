using DMSManager.Abstraction.Business;
using DMSManager.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DMSManager.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DMSController : ControllerBase
    {
        private readonly IBusinessManager _businessManager;
        public DMSController(IBusinessManager businessManager)
        {
            _businessManager = businessManager;
        }

        [HttpGet]
        public async Task<FolderData> GetRootFolder(string tenant, string userID, string rootFolderId)
        {
            return await _businessManager.GetFolders(tenant, userID, rootFolderId);
        }

        [HttpPost]
        public async Task<string> CreateFolder(FolderDetail folder)
        {
            return await _businessManager.CreateFolder(folder);
        }

        [HttpPut]
        public async Task<string> RenameFolder(FolderManager folder)
        {
            return await _businessManager.RenameFolder(folder);
        }

        [HttpDelete]
        public async Task<string> DeleteFolder(FolderDetail folder)
        {
            return await _businessManager.DeleteFolder(folder);
        }

        [HttpPost]
        [Route("File/Save")]
        public async Task<string> Save(FileDetail file)
        {
            return await _businessManager.SaveFile(file);
        }
    }
}
