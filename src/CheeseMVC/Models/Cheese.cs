namespace CheeseMVC.Models
{
    public class Cheese
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // TODO - Can I remove this now?
        //public CheeseType Type { get; set; }

        // TODO - added this from video...
        public int CategoryID { get; set; }
        public CheeseCategory Category { get; set; }
        
    }
}
