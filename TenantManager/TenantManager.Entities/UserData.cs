using System;
using System.Collections.Generic;
using System.Text;

namespace TenantManager.Entities
{
    public class UserData
    {
        public string UserID { get; set; }
        public string TenantID { get; set; }
        public string RootFolderID { get; set; }
    }
}
