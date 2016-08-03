using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductSearch.Models
{
    public class Repository<T> 
        where T : class
    {
        private IDataContext<T> m_dataContext;

        public Repository(IDataContext<T> data)
        {
            m_dataContext = data;
        }

        public List<T> Search(string searchText)
        {
            return m_dataContext.Search(searchText);
        }

        public List<T> LoadPopular()
        {
            return m_dataContext.LoadPopular();
        }
    }
}