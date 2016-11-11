using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class MyConfig : Entities
    {
        /// <summary>
        /// 封装EF实体模型，供Dao使用，
        /// </summary>
        public System.Data.Entity.DbContext db { get; private set; }

        public MyConfig()
        {
            db = new Entities();
        }

        public static string DefaultConnectionString = "";

        /// <summary>
        /// 通用数据库链接对象配置
        /// </summary>
        public static IDbConnection DefaultConnection
        {
            get
            {
                IDbConnection defaultConn = null;
                string action = ConfigurationManager.AppSettings["daoType"];
                switch (action)
                {
                    case "mssql":
                        defaultConn = new System.Data.SqlClient.SqlConnection();
                        DefaultConnectionString = ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
                        break;
                    default:
                        break;
                }
                return defaultConn;
            }
        }

        /// <summary>
        /// 构造数据库连接字符串 注：数据库切换要修改
        /// </summary>
        /// <param name="EntityName"></param>
        /// <returns></returns>
        public static string DataBaseConnectionString(string EntityName)
        {
            IDbConnection con = DefaultConnection;
            return EFConnectionStringModle(EntityName, DefaultConnectionString);
        }

        static string EFConnectionStringModle(string EntityName, string DBsoure)
        {
            return string.Concat("metadata=res://*/",
                EntityName, ".csdl|res://*/",
                EntityName, ".ssdl|res://*/",
                EntityName, ".msl;provider=System.Data.SqlClient;provider connection string='",
                DBsoure, "'");
        }
    }
}
