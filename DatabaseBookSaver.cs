using System.Data.SqlClient;

namespace BookImport
{
    public class DatabaseBookSaver : IBookSaver
    {
        readonly string ConnectionString;

        public DatabaseBookSaver(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void SaveBooks(IEnumerable<Book> books)
        {
            try
            {
                using (var conn = new SqlConnection(ConnectionString))
                using (var comm = conn.CreateCommand())
                {
                    using (var trans = conn.BeginTransaction())
                    {
                        foreach (var b in books)
                        {
                            // build sql or call sp to insert book
                            comm.ExecuteNonQuery();
                        }
                        trans.Commit();
                        // save books to the database
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Books could not be saved in the Database");
            }
        }
    }
}