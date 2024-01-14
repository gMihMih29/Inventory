using _Source.Core.Items;
using JetBrains.Annotations;

namespace _Source.Core
{
    public abstract class Item
    {
        protected int _weight;
        protected string _name;
        protected string _description;
        protected ItemsEnum _type;
    }
}