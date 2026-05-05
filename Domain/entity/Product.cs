namespace ecomerce.domain.entity
{
    public class Proudct
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Describition { get; set; }
        public string? Image { get; set; }

        public decimal price { get; set; }
        public int qualty { get; set; }
        public Catogry? catogry { get; set; }

        public Guid CatogryId { get; set; }

    }
}