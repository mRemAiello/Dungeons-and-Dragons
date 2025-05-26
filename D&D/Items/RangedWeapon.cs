public class RangedWeapon : Item, IEquipable
{
    private int _damage;
    private ItemSlot _slot;
    private DiceValues _diceValue;

    public RangedWeapon(string name, int price, int damage, ItemSlot slot, DiceValues diceValue) : base(name, price)
    {
        _damage = damage;
        _slot = slot;
        _diceValue = diceValue;
    }

    public ItemSlot Slot => ItemSlot.Weapon2;
    public int Damage => _damage;
    public int GetDamageRoll()
    {
        return Dice.Roll(_diceValue);
    }
}