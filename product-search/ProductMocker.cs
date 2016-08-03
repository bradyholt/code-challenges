using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductSearch.Models
{
    public class ProductMocker : IDataContext<Product>
    {
        private readonly List<Product> m_products = new List<Product>(){
                new Product() { ID = 1, Name = "5x5 Blinds (A3)", IsTopSeller=true, Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.", Price = 10.00M },
                new Product() { ID = 2, Name = "10x10  Blinds (D35)", IsTopSeller=true, Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.", Price = 15.00M },
                new Product() { ID = 3, Name = "15x15 Blinds (A9)", IsTopSeller=true, Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.", Price = 20.00M },
                new Product() { ID = 4, Name = "5x5 Shutters (G3)", IsTopSeller=true, Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.", Price = 25.00M },
                new Product() { ID = 5, Name = "10x10 Shutters (G9)", IsTopSeller=true, Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.", Price = 30.00M },
                new Product() { ID = 6, Name = "10x15 Draperies (H3)", IsTopSeller=true, Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.", Price = 35.00M },
                new Product() { ID = 7, Name = "9x9 Draperies (A39)", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.", Price = 40.00M },
                new Product() { ID = 8, Name = "10x10 Draperies (A2)", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.", Price = 45.00M },
                new Product() { ID = 9, Name = "15x15 Shades (B3)", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.", Price = 50.00M },
                new Product() { ID = 10, Name = "20x20 Shades (B9)", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.", Price = 60.00M },
                new Product() { ID = 11, Name = "10x10 Shades (Z4)", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.", Price = 70.00M },
                new Product() { ID = 12, Name = "10x3 Shades (G4)", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.", Price = 80.00M },
                new Product() { ID = 13, Name = "4x4 Shades (F3)", Description = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s.", Price = 90.00M },
            };

        public List<Product> LoadPopular()
        {
            return m_products.Where(p => p.IsTopSeller).ToList();
        }

        public List<Product> Search(string searchText)
        {
            if (searchText == "error")
            {
                throw new Exception("Mocked exception");
            }

            searchText = searchText.ToLower();
            return m_products.Where(p =>
                   p.Name.ToLower().Contains(searchText)
                || p.Description.ToLower().Contains(searchText)
                || p.PriceDescription.Contains(searchText)
                ).ToList();
        }
    }
}