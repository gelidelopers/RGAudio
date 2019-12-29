using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RAudioDataAccess.Models;

namespace RAudioDataAccess
{
    public interface IRAudioDataAccess
    {
        void ExecuteQuery(string query, string[] parameters);

        List<Arxiu> GetArxiusByCategory(Category category, int offset,int limit);
        List<Category> GetCategories();
        List<Artist> GetArtists();



    }
}
