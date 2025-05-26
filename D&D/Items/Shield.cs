public class Shield : Item, IEquipable
{
    private int _defense;
    private ItemSlot _slot;

    public Shield(string name, int price, int defense, ItemSlot slot) : base(name, price)
    {
        _defense = defense;
        _slot = slot;
    }

    public ItemSlot Slot => _slot;
    public int Defense => _defense;
}