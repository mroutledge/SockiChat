using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.SqlServer; 

namespace SockChat
{
    public class SockiChat_dbConfig
    {
        public class MyConfiguration : DbConfiguration
        {
            public MyConfiguration()
            {
                SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
                SetDefaultConnectionFactory(new LocalDbConnectionFactory("v11.0"));
            }
        } 
    }
}