public class Monster : Adventurer
{
    private List<Drop> _drops;
    public Monster(string name, Race race, AdventurerClass adventurerClass, List<Drop> drops) : base(name, race, adventurerClass)
    {
        _drops = drops;
    }

    protected override void Die(Adventurer attacker)
    {
        base.Die(attacker);
        foreach (var drop in _drops)
        {
            if (Dice.Roll(100) <= drop.Chance)
            {
                attacker.AddToInventory(drop.Item);
            }
        }
    }
}