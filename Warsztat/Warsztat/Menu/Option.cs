namespace Warsztat
{
    public class Option
    {
        public string Name { get; }
        public Action Selected { get; }

        public Option(string name)
        {
            Name = name;
        }
    }
}
