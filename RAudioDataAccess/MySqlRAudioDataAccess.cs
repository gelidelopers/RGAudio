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

        public int DeleteSong(int id)
        {
            throw new NotImplementedException();
        }

        public int ExecuteQuery(string query, string[] parameters,object[] paramValues)
        {
            int result = -1;
            try
            {
                using (MySqlCommand cmd = new MySqlCommand())
                {               
                    cmd.Connection = mySqlConnection;
                    cmd.CommandText = query;
                    if(parameters.Length == paramValues.Length)
                    {
                        for(int i = 0; i < parameters.Length; i++)
                        {
                            cmd.Parameters.AddWithValue(parameters[i],paramValues[i]);
                        }
                    }
                    else
                    {
                        throw new RAudioDataAccessException("Numero d'arguments i valors incoherent", new ArgumentException());
                    }
                    
                    mySqlConnection.Open();
                    result = cmd.ExecuteNonQuery();
                    mySqlConnection.Close();
                }
            }
            catch(Exception e)
            {
                throw new RAudioDataAccessException(query, e);
            }
            return result;
        }

        public List<Artist> GetArtists()
        {
            List<Artist> artists = new List<Artist>();
            try
            {
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
            }
            catch(Exception e)
            {
                throw new RAudioDataAccessException("Error al obtenir la llista d'artistes", e);
            }
            return artists;
        }

        public List<Audio> GetArxiusByCategory(Category category, int offset, int limit)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public int InsertSong(Song song)
        {
            int r = 0;
            r += ExecuteQuery("INSERT INTO ra_audio (filename) values (@filename)", new string[] { "@filename" }, new string[] { song.Audio.fileName });
            r += ExecuteQuery("INSERT INTO ra_song (name, duration, id_audio) values (@name, @duration, (select id from ra_audio where filename = @filename))", new string[] { "@name","@duration","@filename" }, new object[] { song.Name, song.Duration, song.Audio.fileName });
            return r;
        }

        public int UpdateSong(Song song)
        {
            throw new NotImplementedException();
        }

        public int UpdateSong(Song oldSong, Song newSong)
        {
            throw new NotImplementedException();
        }

        private void Connect(string connectionString)
        {
            mySqlConnection = new MySqlConnection(connectionString);
        }
    }
}
