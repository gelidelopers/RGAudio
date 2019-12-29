using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using RAudioDataAccess.Models;

namespace RAudioDataAccess
{
    public class MySqlRAudioDataAccess : IRAudioDataAccess
    {
        private MySqlConnection mySqlConnection;
        public MySqlRAudioDataAccess(string connectionString)
        {
            Connect(connectionString);
        }
        public void ExecuteQuery(string query, string[] parameters)
        {
            throw new NotImplementedException();
        }

        public List<Artist> GetArtists()
        {
            List<Artist> artists = new List<Artist>();
            using (MySqlCommand cmd = new MySqlCommand("SELECT id, name FROM ra_artist", mySqlConnection))
            {
                mySqlConnection.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Artist item = new Artist
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1)
                        };
                        artists.Add(item);

                    }
                }
                mySqlConnection.Close();
            }
            return artists;
        }

        public List<Arxiu> GetArxiusByCategory(Category category, int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategories()
        {
            throw new NotImplementedException();
        }
        private void Connect(string connectionString)
        {
            mySqlConnection = new MySqlConnection(connectionString);
        }
    }
}
