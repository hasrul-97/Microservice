using System;
using System.Collections.Generic;
using System.Text;

namespace DMSManager.DataAccess.Core
{
    public class SQLQueries
    {
        public static readonly string GetUserFolders = "SELECT * FROM \"Folder\" WHERE \"UserID\"=@UserID AND \"TenantID\"=@TenantID AND \"Parent\"=@Parent AND\"IsDeleted\"='false'";
        public static readonly string CreateFolder = "INSERT INTO \"Folder\"(\"FolderID\", \"TenantID\", \"Name\", \"Type\", \"Parent\", \"UserID\", \"CreatedOn\", \"CreatedBy\", \"LastModifiedBy\", \"LastModifiedOn\") VALUES" +
            "(@FolderID, @TenantID, @Name, @Type, @Parent, @UserID, @CreatedOn,@CreatedBy,@LastModifiedBy,@LastModifiedOn);";

        public static readonly string CreateFile = "INSERT INTO \"Folder\"(\"FolderID\", \"TenantID\", \"Name\", \"Type\", \"Parent\", \"PhysicalLocation\", \"UserID\", \"CreatedOn\", \"FileType\", \"CreatedBy\", \"LastModifiedBy\", \"LastModifiedOn\",\"Version\",\"Size\") VALUES" +
           "(@FolderID, @TenantID, @Name, @Type, @Parent, @PhysicalLocation, @UserID, @CreatedOn,@FileType,@CreatedBy,@LastModifiedBy,@LastModifiedOn,@Version,@Size);";

        public static readonly string RenameFolder = "UPDATE \"Folder\" SET \"Name\"=@NewName,\"LastModifiedBy\"=@LastModifiedBy,\"LastModifiedOn\"=@LastModifiedOn WHERE \"FolderID\"=@FolderID AND \"TenantID\"=@TenantID AND \"UserID\"=@UserID AND \"Name\"=@PreviousName ";
        public static readonly string DeleteFolder = "UPDATE \"Folder\" SET \"IsDeleted\" = 'true' WHERE \"TenantID\" = @TenantID AND \"UserID\" = @UserID AND \"FolderID\" = @FolderID";
        public static readonly string FETCH_ALL_SUB_CONTENT_FOR_FOLDER = "WITH RECURSIVE folders AS (SELECT \"Name\",\"FolderID\",\"Parent\",\"TenantID\",\"Type\"," +
          "\"PhysicalLocation\",\"UserID\",\"CreatedOn\",\"FileType\",\"IsDeleted\",\"CreatedBy\",\"LastModifiedBy\",\"LastModifiedOn\",\"Version\" FROM \"Folder\" WHERE " +
          "\"FolderID\" = @FolderID UNION SELECT f.\"Name\",f.\"FolderID\",f.\"Parent\",f.\"TenantID\",f.\"Type\",f.\"PhysicalLocation\"," +
          "f.\"UserID\",f.\"CreatedOn\",f.\"FileType\",f.\"IsDeleted\",f.\"CreatedBy\",f.\"LastModifiedBy\",f.\"LastModifiedOn\",\"Version\" FROM \"Folder\" f INNER JOIN " +
          "folders h ON h.\"FolderID\" = f.\"Parent\") SELECT \"Name\",\"FolderID\",\"Parent\",\"TenantID\",\"Type\"," +
          "\"PhysicalLocation\",\"UserID\",\"CreatedOn\",\"FileType\",\"IsDeleted\",\"CreatedBy\",\"LastModifiedBy\",\"LastModifiedOn\",\"Version\" FROM folders";

        public static readonly string SaveFile = "";
    }
}
