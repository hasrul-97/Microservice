using System;
using System.Collections.Generic;
using System.Text;

namespace TenantManager.Entities
{
    public class Payload<T>
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
        public List<T> List { get; set; }

        public bool IsStatusCodeSuccess()
        {
            if (this.StatusCode == 200)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
