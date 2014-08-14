﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using Microsoft.Practices.EnterpriseLibrary.TransientFaultHandling;

namespace TransitApp.Server.Shared.Infrastructure.Data
{
    public class BulkWriter
    {
        private const int MaxRetry = 5;
        private const int DelayMs = 100;

        private readonly string _connString;
        private readonly Dictionary<string, string> _tableMap;
        private readonly string _tableName;

        public BulkWriter(string tableName, Dictionary<string, string> tableMap, string connString)
        {
            _tableName = tableName;
            _tableMap = tableMap;

            // get your connection string
            _connString = connString;
        }

        public void WriteWithRetries(DataTable datatable)
        {
            TryWrite(datatable);
        }

        private void TryWrite(DataTable datatable)
        {
            var policy = MakeRetryPolicy();
            try
            {
                policy.ExecuteAction(() => Write(datatable));
            }
            catch (Exception ex)
            {
                //TODO: Add logging logic

                Trace.TraceError(ex.ToString());
                throw;
            }
        }

        private void Write(DataTable datatable)
        {
            // connect to SQL
            using (var connection = new SqlConnection(_connString))
            {
                var bulkCopy = MakeSqlBulkCopy(connection);

                // set the destination table name
                connection.Open();

                using (var dataTableReader = new DataTableReader(datatable))
                {
                    bulkCopy.WriteToServer(dataTableReader);
                }

                //connection.Close();
            }
        }

        private RetryPolicy<SqlDatabaseTransientErrorDetectionStrategy> MakeRetryPolicy()
        {
            var fromMilliseconds = TimeSpan.FromMilliseconds(DelayMs);
            var policy = new RetryPolicy<SqlDatabaseTransientErrorDetectionStrategy>(MaxRetry, fromMilliseconds);
            return policy;
        }

        private SqlBulkCopy MakeSqlBulkCopy(SqlConnection connection)
        {
            var bulkCopy = new SqlBulkCopy(connection,
                SqlBulkCopyOptions.TableLock | SqlBulkCopyOptions.FireTriggers |
                SqlBulkCopyOptions.UseInternalTransaction, null)
            {
                DestinationTableName = _tableName,
                EnableStreaming = true
            };

            _tableMap.ToList().ForEach(kp => bulkCopy.ColumnMappings.Add(kp.Key, kp.Value));
            return bulkCopy;
        }
    }
}