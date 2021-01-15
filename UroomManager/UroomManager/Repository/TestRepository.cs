using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;
using UroomManager.Entities;

namespace UroomManager.Repository
{
    public class TestRepository
    {
        private string connection =
                    @"Data Source=DESKTOP-DKBV2B9\SQLEXPRESS;Initial Catalog=URmanager;Integrated Security=SSPI";
        
        public void testInsert()
        {
            
            using (var db = new SqlConnection(connection))
            {
                var sqlinsert = "insert into TestTable(Name) Values(@Name)";
                var result = db.Execute(sqlinsert, new { Name = "Alejandro" });

            }
        }
    }
}
