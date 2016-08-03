using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductSearch.Models
{
    public interface IDataContext<T> 
        where T:class
    {
        List<T> Search(string searchText);
        List<T> LoadPopular();
    }
}