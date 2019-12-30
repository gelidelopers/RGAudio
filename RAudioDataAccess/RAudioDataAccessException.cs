using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAudioDataAccess
{
    public class RAudioDataAccessException : Exception
    {
        public RAudioDataAccessException()
        {
        }
        public RAudioDataAccessException(string sql)
            : base(sql)
        {
        }
        public RAudioDataAccessException(string sql, Exception inner)
            : base(sql,inner)
        {
        }
    }
}
