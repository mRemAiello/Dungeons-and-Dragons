public class Mage : AdventurerClass
{
    public readonly int DICE_TIMES = 3;

    public override int HealthRoll()
    {
        int healthRoll = Dice.RollD6();
        return healthRoll;
    }

    public override int MoneyRoll()
    {
        int moneyRoll = 0;
        for (int i = 0; i < DICE_TIMES; i++)
        {
            moneyRoll += Dice.RollD6();
        }
        return moneyRoll;
    }
}