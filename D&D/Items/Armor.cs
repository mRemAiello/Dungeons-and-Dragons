public class Armor : Item, IEquipable
{
    private int _defense;
    private ItemSlot _slot;
    private ArmorType _armorType;

    public Armor(string name, int price, int defense, ItemSlot slot, ArmorType armorType) : base(name, price)
    {
        _defense = defense;
        _slot = slot;
        _armorType = armorType;
    }

    public ItemSlot Slot => _slot;
    public int Defense => _defense;
}