namespace effectively.StaticCling {
    using System;
    using System.Collections.Generic;

    public class Database {
        public static Database Instance = new Database();

        public IEnumerable<T> QueryInternal<T>(string sql) where T : class
        {
            Logger.Log(sql);
            return DoQueryInternal<T>(sql);
        }

        protected virtual IEnumerable<T> DoQueryInternal<T>(string sql) where T : class
        {
            throw new Exception("Database access!");
        }

        public static IEnumerable<T> Query<T>(string sql) where T : class
        {
            return Instance.QueryInternal<T>(sql);
        }
    }
}