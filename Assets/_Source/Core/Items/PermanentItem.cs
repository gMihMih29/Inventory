namespace _Source.Core.Items
{
    public class PermanentItem : Item
    {
        public PermanentItem(int weight, string name, string description)
        {
            _weight = weight;
            _name = name;
            _description = description;
        }
    }
}