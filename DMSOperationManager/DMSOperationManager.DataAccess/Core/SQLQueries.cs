using System;
using System.Collections.Generic;
using System.Text;

namespace DMSOperationManager.DataAccess.Core
{
    public class SQLQueries
    {
        public static readonly string FETCH_ALL_SUB_CONTENT_FOR_FOLDER = "WITH RECURSIVE folders AS (SELECT \"Name\",\"FolderID\",\"Parent\",\"TenantID\",\"Type\"," +
            "\"PhysicalLocation\",\"UserID\",\"CreatedOn\",\"FileType\",\"IsDeleted\",\"CreatedBy\",\"LastModifiedBy\",\"LastModifiedOn\" FROM \"Folder\" WHERE " +
            "\"FolderID\" = @FolderID UNION SELECT f.\"Name\",f.\"FolderID\",f.\"Parent\",f.\"TenantID\",f.\"Type\",f.\"PhysicalLocation\"," +
            "f.\"UserID\",f.\"CreatedOn\",f.\"FileType\",f.\"IsDeleted\",f.\"CreatedBy\",f.\"LastModifiedBy\",f.\"LastModifiedOn\" FROM \"Folder\" f INNER JOIN " +
            "folders h ON h.\"FolderID\" = f.\"Parent\") SELECT \"Name\",\"FolderID\",\"Parent\",\"TenantID\",\"Type\"," +
            "\"PhysicalLocation\",\"UserID\",\"CreatedOn\",\"FileType\",\"IsDeleted\",\"CreatedBy\",\"LastModifiedBy\",\"LastModifiedOn\" FROM folders WHERE \"IsDeleted\"='false'";

        public static readonly string FETCH_ALL_SUB_CONTENT_FOR_FOLDER_EXCLUDING_ROOT_FOLDER = "WITH RECURSIVE folders AS (SELECT \"Name\",\"FolderID\",\"Parent\",\"TenantID\",\"Type\"," +
        "\"PhysicalLocation\",\"UserID\",\"CreatedOn\",\"FileType\",\"IsDeleted\",\"CreatedBy\",\"LastModifiedBy\",\"LastModifiedOn\" FROM \"Folder\" WHERE " +
        "\"FolderID\" = @FolderID UNION SELECT f.\"Name\",f.\"FolderID\",f.\"Parent\",f.\"TenantID\",f.\"Type\",f.\"PhysicalLocation\"," +
        "f.\"UserID\",f.\"CreatedOn\",f.\"FileType\",f.\"IsDeleted\",f.\"CreatedBy\",f.\"LastModifiedBy\",f.\"LastModifiedOn\" FROM \"Folder\" f INNER JOIN " +
        "folders h ON h.\"FolderID\" = f.\"Parent\") SELECT \"Name\",\"FolderID\",\"Parent\",\"TenantID\",\"Type\"," +
        "\"PhysicalLocation\",\"UserID\",\"CreatedOn\",\"FileType\",\"IsDeleted\",\"CreatedBy\",\"LastModifiedBy\",\"LastModifiedOn\" FROM folders WHERE \"FolderID\" != @FolderID AND \"IsDeleted\"='false'";

        public static readonly string GET_CONTENT_DATA_FOR_FOLDER = "SELECT \"Name\",\"FolderID\",\"Parent\",\"TenantID\",\"Type\"," +
            "\"PhysicalLocation\",\"UserID\",\"CreatedOn\",\"FileType\",\"IsDeleted\",\"CreatedBy\",\"LastModifiedBy\",\"LastModifiedOn\" FROM \"Folder\" WHERE \"FolderID\" = @FolderID AND \"IsDeleted\"='false'";

        public static readonly string SAVE_FOLDERS = "INSERT INTO \"Folder\"(\"FolderID\", \"TenantID\", \"Name\", \"Type\", \"Parent\", \"PhysicalLocation\", \"UserID\", \"CreatedOn\", \"FileType\"," +
            " \"CreatedBy\", \"LastModifiedBy\", \"LastModifiedOn\") VALUES(@FolderID, @TenantID, @Name, @Type, @Parent, @PhysicalLocation, @UserID, @CreatedOn, @FileType, @CreatedBy," +
            " @LastModifiedBy,@LastModifiedOn);";

        public static readonly string FETCH_CHILD_FOLDERS = "SELECT\"Name\",\"FolderID\",\"Parent\",\"TenantID\",\"Type\"," +
            "\"PhysicalLocation\",\"UserID\",\"CreatedOn\",\"FileType\",\"IsDeleted\",\"CreatedBy\",\"LastModifiedBy\",\"LastModifiedOn\" FROM \"Folder\" WHERE \"Parent\"= @Parent AND \"IsDeleted\"='false'";
    }
}