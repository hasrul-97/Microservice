using System;
using System.Collections.Generic;
using System.Text;

namespace TenantManager.DataAccess.Core
{
    public class SQLQueries
    {
        public static readonly string GetFolder = "SELECT * FROM \"User\" WHERE \"UserID\"=@UserID AND \"TenantID\"=@TenantID";
        public static readonly string CreateRootFolder = "INSERT INTO \"Folder\"(\"FolderID\", \"TenantID\", \"Name\", \"Type\", \"Parent\", \"PhysicalLocation\", \"UserID\", \"CreatedOn\",\"CreatedBy\",\"LastModifiedBy\",\"LastModifiedOn\") VALUES" +
            "(@FolderID, @TenantID, @Name, @Type, @Parent, @PhysicalLocation, @UserID, @CreatedOn,@CreatedBy,@LastModifiedBy,@LastModifiedOn);";
        public static readonly string GetUserRootFolder = "SELECT \"FolderID\", \"TenantID\", \"Name\", \"Type\", \"Parent\", \"PhysicalLocation\", \"UserID\", \"CreatedOn\", \"FileType\",\"LastModifiedOn\",\"LastModifiedBy\" FROM \"Folder\" WHERE \"UserID\"=@UserID AND \"TenantID\"=@TenantID AND \"FolderID\"=@RootFolderID";
    }
}
