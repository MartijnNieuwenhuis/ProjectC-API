using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace DAL
{
    public class Context : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Score> Scores { get; set; }
        public Context()
        {
        }


        public static void SetInitializer()
        {
        }
    }

    public static class ContextExtensions
    {
        public static String GetTableName<T>(this DbContext context) where T : class
        {
            ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;

            return objectContext.GetTableName<T>();
        }

        public static String GetTableName<T>(this ObjectContext context) where T : class
        {
            try
            {
                String sql = context.CreateObjectSet<T>().ToTraceString();
                Regex regex = new Regex("FROM (?<table>.*) AS");
                Match match = regex.Match(sql);

                String table = match.Groups["table"].Value;
                return table;
            }
            catch
            {
                return String.Empty;
            }
        }
    }
}