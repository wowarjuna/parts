using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolrIndexer
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "";
            string solrUrl = "";

            BasicIndexer indexer = new BasicIndexer(connectionString, solrUrl);
            indexer.IndexFiles();
        }
    }
}
