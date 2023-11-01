namespace EAuctionApp.ConstantClasses
{
    public sealed class CategoryDetails
    {
        public static  Dictionary<string, string> Categorys = new Dictionary<string, string>();

        private const string Painting = "Painting";
        private const string Sculptor = "Sculptor";
        private const string Ornament = "Ornament";

        public CategoryDetails()
        {
                
        }
        public  void AddCategory()
        {

            Categorys.Add("Painting", Painting);
            Categorys.Add("Sculptor", Sculptor);
            Categorys.Add("Ornament", Ornament);

        }

        public bool CheckCategory(string category)
        {

            return Categorys.ContainsValue(category);
        }

        
    }
}
