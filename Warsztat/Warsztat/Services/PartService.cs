namespace Warsztat
{
    public class PartService
    {
        private PartRepository partsRepository = new PartRepository();

        public void PrintAllPart()// WYŚWIETLANIE LISTY CZESCI
        {
            var parts = partsRepository.ReadPartFromFile();
            foreach (Part part in parts)
            {
                int indexOfPart = parts.IndexOf(part);
                Console.WriteLine($"{indexOfPart + 1}. Name: {part.PartName} \n Price: {part.PartPrice} \n Quantity: {part.Quantity}");
                DecorateLine();
            }
        }

        public void AddPart()
        {
            Console.WriteLine("Part Name:");
            string partName = Console.ReadLine();
            Console.WriteLine("Part Price");
            int partPrice = int.Parse(Console.ReadLine());
            Console.WriteLine("Quantity");
            int quantity = int.Parse(Console.ReadLine());

            var part = new Part(partName, partPrice, quantity);
            var partList = partsRepository.ReadPartFromFile();
            partList.Add(part);
            partsRepository.SavePartToFile(partList);
            PrintAllPart();
        }

        public void EditQuantityOfPart()
        {
            PrintAllPart();
            DecorateLine();
            Console.WriteLine($"Declare number of order to change");
            DecorateLine();
            var parts = partsRepository.ReadPartFromFile();
            int indexToEdit = int.Parse(Console.ReadLine()) - 1;
            DecorateLine();
            Console.WriteLine("Enter new quantity:");
            int quantity = int.Parse(Console.ReadLine());

            parts[indexToEdit] = new Part(parts[indexToEdit].PartName, parts[indexToEdit].PartPrice, quantity);
            partsRepository.SavePartToFile(parts);
        }

        public void QuantityRaport()
        {
            var parts = partsRepository.ReadPartFromFile();
            var partsToRaport = parts.Where(q => q.Quantity < 5).ToList();
            Console.WriteLine("Parts quantity raport \n" +
                "You have to order:");
            int orderValue = 0;
            foreach (var part in partsToRaport)
            {
                int indexOfOrder = parts.IndexOf(part);
                Console.WriteLine($"{indexOfOrder + 1}. Name: {part.PartName} Quantity: {5 - part.Quantity}");
                orderValue += part.Quantity * part.PartPrice;
                DecorateLine();
            }
            Console.WriteLine($"Order value: {orderValue}");
        }

        public void DecorateLine()
        {
            Console.WriteLine("-----------------------------------------------------------------");
        }
    }
}
