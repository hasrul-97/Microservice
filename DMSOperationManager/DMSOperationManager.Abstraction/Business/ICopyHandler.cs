using DMSOperationManager.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DMSOperationManager.Abstraction.Business
{
    public interface ICopyHandler
    {
        Task<string> Copy(CopyAttributes folder);
    }
}