using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RAudioDataAccess.Models;

namespace RAudioDataAccess
{
    public interface IRAudioDataAccess
    {
        int ExecuteQuery(string query, string[] parameters, object[] paramvalues);
        List<Audio> GetArxiusByCategory(Category category, int offset,int limit);
        List<Category> GetCategories();
        List<Artist> GetArtists();
        int InsertSong(Song song);
        int UpdateSong(Song song);
        int UpdateSong(Song oldSong, Song newSong);
        int DeleteSong(int id);


    }
}
