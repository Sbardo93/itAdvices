using ITAdvices.Business;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITAdvices.SmartGridEntity
{
    public partial class Log
    {
        [SmartGrid("Data", new SmartGridAttribute.ColumnTypeEnum[] { SmartGridAttribute.ColumnTypeEnum.Date }, 1)]
        public System.DateTime Data { get; set; }
        [SmartGrid("Username", 1)]
        public string Username { get; set; }
        [SmartGrid("Categoria", new SmartGridAttribute.ColumnTypeEnum[] { SmartGridAttribute.ColumnTypeEnum.Select }, 2)]
        public string Category { get; set; }
        [SmartGrid("Message", 1)]
        public string Message { get; set; }
        [SmartGrid("SessionId", 1)]
        public string SessionId { get; set; }
        [SmartGrid("SessionState", 1)]
        public string SessionState { get; set; }

        public Log(Entity.DB.Log l)
        {
            this.Data = l.Data;
            this.Username = l.Username;
            this.Category = l.Category;
            this.Message = l.Message;
            this.SessionId = l.SessionId;
            this.SessionState = l.SessionState;
        }
    }
}
