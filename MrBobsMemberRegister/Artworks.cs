using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrBobsMemberRegister
{
    internal class Artworks
    {
        private string connString = @"Server=(localdb)\MSSQLLocalDB;Database=MrBobArtDB;Integrated Security=true;";

        public int ID { get; set; }
        public string Name { get; set; }
        public int OwnerID { get; set; }
        public string Category { get; set; }
        public string Size { get; set; }
        public int SizeInt { get; set; }
        public int ExpectedPrice { get; set; }
        public int SoldPrice { get; set; }

        public Artworks(string name, int ownerID, string category, string size, int sizeint, int expectedPrice, int soldPrice)
        {
            Name = name;
            OwnerID = ownerID;
            Category = category;
            Size = size;
            SizeInt = sizeint;
            ExpectedPrice = expectedPrice;
            SoldPrice = soldPrice;
        }

        public Artworks() { }
    }
}
