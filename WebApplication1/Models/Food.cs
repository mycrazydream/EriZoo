namespace EriZoo.Models
{
    public class Food
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public int VendorID { get; set; }
        public int AnimalID { get; set; }

        public virtual Vendor Vendors { get; set; }
        public virtual Animal Animals { get; set; }
    }
}