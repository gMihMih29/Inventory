namespace _Source.Core.Items
{
    /// <summary>
    /// Abstract item.
    /// </summary>
    public abstract class Item
    {
        protected int _weight;
        protected string _name;
        protected string _description;
        protected ItemsEnum _type;

        public ItemsEnum GetItemType()
        {
            return _type;
        }
    }
}