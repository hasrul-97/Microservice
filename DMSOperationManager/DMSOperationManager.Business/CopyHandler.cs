using DMSOperationManager.Abstraction.Business;
using DMSOperationManager.Abstraction.DataAccess;
using DMSOperationManager.Entities;
using DMSOperationManager.Entities.ReadonlyValues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMSOperationManager.Business
{
    public class CopyHandler : ICopyHandler
    {
        private readonly IDataHandler _dataHandler;
        public CopyHandler(IDataHandler dataHandler)
        {
            _dataHandler = dataHandler;
        }

        public async Task<string> Copy(CopyAttributes attributes)
        {
            List<ContentData> sourceFolderDetails = await _dataHandler.GetFolderDetails(attributes.SourceFolders);
            List<ContentData> targetFolderDetails = await _dataHandler.GetFolderDetailsExcludingRoot(attributes.Target);


            Dictionary<string, ContentData> sourceDictionary = GetConstructedDictionary(sourceFolderDetails, await _dataHandler.GetContentDataForFolder(attributes.SourceFolders));
            Dictionary<string, ContentData> targetDictionary = GetConstructedDictionary(targetFolderDetails, await _dataHandler.GetContentDataForFolder(attributes.Target), false);

            return await Save(sourceDictionary, targetDictionary, attributes.Target);
        }

        public async Task<string> Save(Dictionary<string, ContentData> source, Dictionary<string, ContentData> target, StorageItem targetRoot)
        {
            foreach (var item in source)
            {
                if (!target.ContainsKey(item.Key))
                {
                    var parentName = item.Key.Split(string.Format(@"_{0}", item.Value.Name)).First();
                    item.Value.FolderID = Guid.NewGuid().ToString();
                    if (target.ContainsKey(parentName))
                    {
                        ContentData parentFolder = target[parentName];
                        item.Value.Parent = parentFolder.FolderID;
                        target.Add(string.Format(@"{0}_{1}", parentName, item.Value.Name), item.Value);
                    }
                    else
                    {
                        item.Value.Parent = targetRoot.Id;
                        target.Add(item.Key, item.Value);
                    }
                    await _dataHandler.Save(item.Value);
                }
            }
            return Constants.TaskCompleted;
        }

        private Dictionary<string, ContentData> GetConstructedDictionary(List<ContentData> content, ContentData folder, bool shouldIncludeRoot = true)
        {
            Dictionary<string, ContentData> constuctedDictionary = new Dictionary<string, ContentData>();
            if (folder != null)
            {
                constuctedDictionary.Add(folder.Name, folder);
            }
            string rootFolder = shouldIncludeRoot ? folder.Parent : folder.FolderID;
            foreach (var folderOrFile in content)
            {
                List<ContentData> temporaryList = new List<ContentData>();
                temporaryList.Add(folderOrFile);

                var currentFolderOrFile = folderOrFile;
                while (currentFolderOrFile.Parent != rootFolder)
                {
                    var currentParent = content.Find(_ => _.FolderID == currentFolderOrFile.Parent);
                    currentFolderOrFile = currentParent;
                    temporaryList.Add(currentParent);
                }

                string key = string.Empty;
                temporaryList.Reverse();
                foreach (var temporaryItem in temporaryList)
                {
                    if (string.IsNullOrEmpty(key))
                    {
                        key = temporaryItem.Name;
                    }
                    else
                    {
                        key = string.Format(@"{0}_{1}", key, temporaryItem.Name);
                    }

                    if (!constuctedDictionary.ContainsKey(key))
                    {
                        constuctedDictionary.Add(key, temporaryItem);
                    }
                }
            }
            return constuctedDictionary;
        }

        //public static StorageItem ConvertCollection(ContentData content)
        //{
        //    if (content.Type.Equals("Folder"))
        //    {
        //        return new Folder(content.FolderID, content.Name, content.CreatedOn, content.CreatedBy, content.LastModifiedOn, content.LastModifiedBy, content.Parent);
        //    }
        //    else
        //    {
        //        return new File(content.FolderID, content.Name, content.CreatedOn, content.FileType, content.CreatedBy, content.LastModifiedOn, content.LastModifiedBy, content.Parent, content.PhysicalLocation);
        //    }
        //}
    }
}
