namespace ApplicationService.ViewModels.Card
{
    public class Product
    {
        public string UserId { get; set; }
        public int ItemId { get; set; }
        public int JuiceId { get; set; }
        public int JuiceMangmentId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public byte[] Photo { get; set; }
    }
}
