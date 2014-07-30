using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace TransitApp.Server.GTFSRealtime.Infrastructure.Data
{
    public abstract class RepositoryBase<T> : IDisposable
    {
        protected string TableName;
        private bool _disposed;
        protected string InsertCmdText;
        private readonly string _connectionString;

        protected RepositoryBase(string connectionString)
        {
            _connectionString = connectionString;
        }

        public abstract DataTable CreateDataTableFromItems(IEnumerable<T> items);

        public abstract Dictionary<string, string> CreateMappingDictionary();

        protected void SqlBulkInsertTable(IEnumerable<T> items)
        {
            var table = CreateDataTableFromItems(items);
            var map = CreateMappingDictionary();
            var bulk = new BulkWriter(TableName, map, _connectionString);
            bulk.WriteWithRetries(table);
        }

        protected void PurgeTable()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand(string.Format("TRUNCATE TABLE {0}", TableName), conn))
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~RepositoryBase()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) {
                return;
            }

            if (disposing) {
                // free other managed objects that implement
                // IDisposable only
                
            }

            // release any unmanaged objects
            // set the object references to null

            _disposed = true;
        }
    }
}