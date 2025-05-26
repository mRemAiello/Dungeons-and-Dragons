public class MagicWeapon : Weapon
{
    private int _bonusDamage;

    public MagicWeapon(string name, int price, ItemSlot slot, DiceValues diceValue, int bonusDamage) : base(name, price, slot, diceValue)
    {
        _bonusDamage = bonusDamage;
    }

    public override string Damage => $"{base.Damage} + {_bonusDamage}";
    public override int GetDamageRoll()
    {
        return base.GetDamageRoll() + _bonusDamage;
    }
}