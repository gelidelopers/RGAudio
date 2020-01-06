using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RAudioDataAccess.Models;

namespace RAudioDataAccess
{
    public interface IRAudioDataAccess
    {
        int ExecuteQuery(string query, Dictionary<string,string> parameters);
        List<Audio> GetArxiusByCategory(Category category, int offset,int limit);
        List<Category> GetCategories();
        List<Artist> GetArtists();
    }
}
