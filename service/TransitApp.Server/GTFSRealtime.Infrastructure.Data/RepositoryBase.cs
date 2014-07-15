using System;
using System.Data;
using System.Data.SqlClient;

namespace TransitApp.Server.GTFSRealtime.Infrastructure.Data
{
    public abstract class RepositoryBase : IDisposable
    {
        protected SqlConnection Connection;
        protected string TableName;
        private bool _disposed;
        protected string InsertCmdText;

        protected RepositoryBase(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void PurgeTable()
        {
            var cmd = new SqlCommand(string.Format("TRUNCATE TABLE {0}", TableName), Connection);
            try {
                Connection.Open();
                cmd.ExecuteNonQuery();
            } finally {
                cmd.Dispose();
                Connection.Close();
            }
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
                if (Connection.State == ConnectionState.Open) {
                    Connection.Close();
                }
                Connection.Dispose();
            }

            // release any unmanaged objects
            // set the object references to null

            _disposed = true;
        }
    }
}