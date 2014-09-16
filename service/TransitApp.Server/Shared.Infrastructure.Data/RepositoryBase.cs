using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TransitApp.Server.Shared.Core.Interfaces;

namespace TransitApp.Server.Shared.Infrastructure.Data
{
    public abstract class RepositoryBase<T> : IDisposable, IGTFSRepository<T>
    {
        private readonly IList<ColumnMapping> _columnMappings;
        private readonly string _connectionString;
        private SqlConnection _connection;
        private readonly string _tableName;
        protected DataTable InsertDataTable;
        private bool _disposed;

        protected RepositoryBase(string tableName, IList<ColumnMapping> columnMappings)
        {
            _tableName = tableName;
            _columnMappings = columnMappings;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void CreateDataTableFromItems(IEnumerable<T> items)
        {
            InsertDataTable = new DataTable();
            foreach (var columnMapping in _columnMappings) {
                InsertDataTable.Columns.Add(columnMapping.DataTableColumnName, columnMapping.DataTableColumnType);
            }
        }

        public virtual Dictionary<string, string> CreateMappingDictionary()
        {
            return _columnMappings.ToDictionary(columnMapping => columnMapping.DatabaseColumnName,
                columnMapping => columnMapping.DataTableColumnName);
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
                if (null != ConnectionString && null != _connection)
                {
                    _connection.Dispose();
                }
            }

            // release any unmanaged objects
            // set the object references to null

            _disposed = true;
        }

        public void AddRange(IEnumerable<T> items)
        {
            CreateDataTableFromItems(items);
            var map = CreateMappingDictionary();
            var bulk = new BulkWriter(_tableName, map) {Connection = Connection};
            bulk.WriteWithRetries(InsertDataTable);
        }

        public void ClearAll()
        {
//            using (var conn = new SqlConnection(_connectionString))
            {
                using (var cmd = new SqlCommand(string.Format("TRUNCATE TABLE {0}", _tableName), Connection))
                {
//                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public string ConnectionString
        {
            get { return _connectionString; }
        }

        public SqlConnection Connection
        {
            get
            {
                if (null == _connection && null != _connectionString)
                {
                    _connection = new SqlConnection(_connectionString);
                    _connection.Open();
                }
                return _connection;
            }
            set { _connection = value; }
        }


    }
}