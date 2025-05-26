public class Weapon : Item, IEquipable
{
    private ItemSlot _slot;
    private DiceValues _diceValue;
    public Weapon(string name, int price, ItemSlot slot, DiceValues diceValue) : base(name, price)
    {
        _slot = slot;
        _diceValue = diceValue;
    }


    public ItemSlot Slot => ItemSlot.Weapon1;
    public virtual string Damage => _diceValue.ToString();
    public virtual int GetDamageRoll()
    {
        return Dice.Roll(_diceValue);
    }



}