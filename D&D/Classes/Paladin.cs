public class Paladin : AdventurerClass
{
    public readonly int DICE_TIMES = 5;
    public override int HealthRoll()
    {
        int healthRoll = Dice.RollD10();
        return healthRoll;
    }
    public override int MoneyRoll()
    {
        int moneyRoll = 0;
        for (int i = 0; i < DICE_TIMES; i++)
        {
            moneyRoll += Dice.RollD10();
        }
        return moneyRoll;
    }
   
}