using System.Configuration;
using System.Data.Entity;
using System.Data.SqlClient;

namespace BusinessLogic.DB
{
    public partial class DBEntities : DbContext
    {
        public DBEntities(string ConnectionString)
          : base("name=DBEntities")
        {
            Database.SetInitializer<DBEntities>(null);

            var c = new SqlConnectionStringBuilder(ConnectionString);

            Database.Connection.ConnectionString = c.ConnectionString;
        }
    }

}
