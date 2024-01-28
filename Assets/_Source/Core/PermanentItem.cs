namespace _Source.Core.Items
{
    public class PermanentItem : Item
    {
        public PermanentItem(ItemsEnum type, int weight = 0, string name = "", string description = "")
        {
            _weight = weight;
            _name = name;
            _description = description;
            _type = type;
        }
    }
}