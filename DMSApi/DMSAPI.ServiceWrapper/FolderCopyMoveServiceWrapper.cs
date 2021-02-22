using DMSAPI.Entities;
using DMSAPI.Entities.ReadonlyConstants;
using DMSAPI.ServiceWrapper.Utility;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DMSAPI.ServiceWrapper
{
    public class FolderCopyMoveServiceWrapper
    {
        private WrapperUtility _utility;
        private string serviceId = string.Empty;
        private readonly FolderServiceWrapper _folderService;
        public FolderCopyMoveServiceWrapper(WrapperUtility utility, IConfiguration configuration, FolderServiceWrapper folderService)
        {
            _utility = utility;
            serviceId = configuration.GetSection("DMSOperationManager").Value;
            _folderService = folderService;
        }

        public async Task<string> InvokeCopyAsync(StorageItem sourcefile, StorageItem target, string userID, string connectionId, bool canMerge)
        {
            var url = string.Format("{0}Copy", await _utility.GetInstanceURI(serviceId));
            return await _utility.PostAsync<CopyMoveAttributes>(new CopyMoveAttributes(sourcefile, target, userID, connectionId, canMerge), url);
        }

        public async Task<string> InvokeMoveAsync(StorageItem sourcefile, StorageItem target, string userID, string connectionId, bool canMerge, string tenantId)
        {
            var url = string.Format("{0}Copy", await _utility.GetInstanceURI(serviceId));
            await _utility.PostAsync<CopyMoveAttributes>(new CopyMoveAttributes(sourcefile, target, userID, connectionId, canMerge), url);
            await _folderService.DeleteAsync(new FolderDetail(sourcefile.Id, sourcefile.Name, sourcefile.Parent, sourcefile.CreatedOn, tenantId, sourcefile.Type, userID));
            return ResponseMessage.Task_Completed;
        }

    }
}
