using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace SolrIndexer
{
    public class TextFileRepository
    {
        #region Members

        private string connectionString;

        #endregion

        #region Constructors

        public TextFileRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        #endregion

        #region Methods

        public IEnumerable<TextFile> GetTextFiles()
        {
            return ExecuteSql("SELECT * FROM FILES");
        }

        public IEnumerable<TextFile> GetTextFiles(IEnumerable<int> fileIds)
        {
            if (!fileIds.Any()) { yield break; }
            string sql = String.Format("SELECT * FROM FILES WHERE FILEID IN({0})", fileIds);
            foreach (var item in ExecuteSql(sql))
            {
                yield return item;
            }
        }

        private IEnumerable<TextFile> ExecuteSql(string sql)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = sql;
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return FromReader(reader);
                }
            }
        }

        private TextFile FromReader(SqlDataReader reader)
        {
            var result = new TextFile();
            result.FileID = (int)reader["FileID"];
            result.Title = reader["Title"] as string;
            result.FileLocation = reader["FileLocation"] as string;
            var date = reader["DateCreated"];
            result.DateCreated = date == DBNull.Value ? (DateTime?)null : date as DateTime?;

            return result;
        }

        #endregion
    }
}
