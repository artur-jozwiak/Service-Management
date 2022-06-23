namespace Warsztat
{
    public class Part1
    {
        public string PartName { get; set; }
        public int PartPrice { get; set; }
        public int Quantity { get; set; }

        public Part1(string partName, int partPrice, int quantity)
        {
            PartName = partName;
            PartPrice = partPrice;
            Quantity = quantity;
        }
    }
}

