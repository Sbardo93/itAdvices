using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DB
{
    [MetadataType(typeof(LogMetaData))]
    public partial class Log
    {
    }

    public class LogMetaData
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
    }
}
