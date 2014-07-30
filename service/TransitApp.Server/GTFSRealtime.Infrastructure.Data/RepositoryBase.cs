using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace TransitApp.Server.GTFSRealtime.Infrastructure.Data
{
    public abstract class RepositoryBase<T> : IDisposable
    {
        private readonly string _tableName;
        private readonly IList<ColumnMapping> _columnMappings;
        private bool _disposed;
        private readonly string _connectionString;
        protected DataTable InsertDataTable;

        protected RepositoryBase(string connectionString, string tableName, IList<ColumnMapping> columnMappings)
        {
            _connectionString = connectionString;
            _tableName = tableName;
            _columnMappings = columnMappings;
        }

        public virtual void CreateDataTableFromItems(IEnumerable<T> items)
        {
            InsertDataTable = new DataTable();
            foreach (var columnMapping in _columnMappings)
            {
                InsertDataTable.Columns.Add(columnMapping.DataTableColumnName, columnMapping.DataTableColumnType);
            }
        }

        public virtual Dictionary<string, string> CreateMappingDictionary()
        {
            return _columnMappings.ToDictionary(columnMapping => columnMapping.DatabaseColumnName, columnMapping => columnMapping.DataTableColumnName);
        }

        protected void SqlBulkInsertTable(IEnumerable<T> items)
        {
            CreateDataTableFromItems(items);
            var map = CreateMappingDictionary();
            var bulk = new BulkWriter(_tableName, map, _connectionString);
            bulk.WriteWithRetries(InsertDataTable);
        }

        protected void PurgeTable()
        {
            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand(string.Format("TRUNCATE TABLE {0}", _tableName), conn))
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