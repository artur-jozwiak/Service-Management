namespace Warsztat
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<Option> startMenuOptions = new List<Option>
           {
                new Option("Orders"),
                new Option("Employees"),
                new Option("Parts"),
                new Option("Exit") //() => Environment.Exit(0))
            };

            List<Option> orderMenuOptions = new List<Option>
            {
                new Option("Add an order"),
                new Option("Delete an order"),
                new Option("Edit an order"),
                new Option("Show filtered orders by status"),
                new Option("Show all orders"),
                new Option("Main menu"),
            };

            List<Option> employeeMenuOptions = new List<Option>
            {
                new Option("Add an employee"),
                new Option("Delete an employee"),
                new Option("Edit an employee"),
                new Option("Show all employees"),
                new Option("Main menu"),
            };

            List<Option> partsMenuOptions = new List<Option>
            {
                new Option("Add part"),
                new Option("Show parts"),
                new Option("Edit quantity of a part"),
                new Option("Quantity raport"),
                new Option("Main menu"),
            };

            OrderService orderService = new OrderService();
            EmployeeService employeeService = new EmployeeService();
            PartService partService = new PartService();

            bool program = true;
            int index = 0;
            int menuOption = 0;
            var currentMenuOptions = startMenuOptions;
            ConsoleKeyInfo keyinfo;

            do
            {
                Menu.Menu.WriteMenu(currentMenuOptions, currentMenuOptions[index]);
                keyinfo = Console.ReadKey();

                if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (index + 1 < currentMenuOptions.Count)
                    {
                        index++;
                        Menu.Menu.WriteMenu(currentMenuOptions, currentMenuOptions[index]);
                    }
                }

                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (index - 1 >= 0)
                    {
                        index--;
                        Menu.Menu.WriteMenu(currentMenuOptions, currentMenuOptions[index]);
                    }
                }

                if (keyinfo.Key == ConsoleKey.Enter)
                {
                    if (menuOption == 0)
                    {
                        switch (index)
                        {
                            case 0:
                                currentMenuOptions = orderMenuOptions;
                                menuOption = 1;
                                index = 0;
                                continue;

                            case 1:
                                currentMenuOptions = employeeMenuOptions;
                                menuOption = 2;
                                index = 0;
                                continue;

                            case 2:
                                currentMenuOptions = partsMenuOptions;
                                menuOption = 3;
                                index = 0;
                                continue;

                            case 3:
                                Environment.Exit(0);
                                break;
                        }
                    }

                    if (menuOption == 1)
                    {
                        switch (index)
                        {
                            case 0:
                                Console.Clear();
                                orderService.CreateNewOrder();
                                break;

                            case 1:
                                Console.Clear();
                                orderService.RemoveSelectedOrder();
                                break;

                            case 2:
                                Console.Clear();
                                orderService.EditDeclaredOrder();
                                break;

                            case 3:
                                Console.Clear();
                                orderService.SortingOrdersByStatus();
                                break;

                            case 4:
                                Console.Clear();
                                orderService.PrintAllOrders();
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadLine();
                                break;

                            case 5:
                                currentMenuOptions = startMenuOptions;
                                menuOption = 0;
                                index = 0;
                                continue;

                        }
                    }
                    if (menuOption == 2)
                    {
                        switch (index)
                        {
                            case 0:
                                Console.Clear();
                                employeeService.AddMechanic();
                                break;
                            case 1:
                                Console.Clear();
                                employeeService.RemoveSelectedMechanic();
                                break;
                            case 2:
                                Console.Clear();
                                employeeService.EditDeclaredMechanic();
                                break;

                            case 3:
                                Console.Clear();
                                employeeService.PrintAllMechanics();
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadLine();
                                break;

                            case 4:
                                currentMenuOptions = startMenuOptions;
                                menuOption = 0;
                                index = 0;
                                continue;
                        }
                    }

                    if (menuOption == 3)
                    {
                        switch (index)
                        {
                            case 0:
                                Console.Clear();
                                partService.AddPart();
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadLine();
                                break;

                            case 1:
                                Console.Clear();
                                partService.PrintAllPart();
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadLine();
                                break;

                            case 2:
                                Console.Clear();
                                partService.EditQuantityOfPart();
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadLine();
                                break;

                            case 3:
                                Console.Clear();
                                partService.QuantityRaport();
                                Console.WriteLine("Press Enter to continue");
                                Console.ReadLine();
                                break;

                            case 4:
                                currentMenuOptions = startMenuOptions;
                                menuOption = 0;
                                index = 0;
                                continue;
                        }
                    }
                    index = 0;
                }
            }
            while (program);
        }
    }
}
