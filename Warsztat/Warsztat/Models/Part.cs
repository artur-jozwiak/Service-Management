namespace Warsztat
{
    public class Part
    {
        public string PartName { get; set; }
        public int PartPrice { get; set; }
        public int Quantity { get; set; }

        public Part(string partName, int partPrice, int quantity)
        {
            PartName = partName;
            PartPrice = partPrice;
            Quantity = quantity;
        }
    }
}

