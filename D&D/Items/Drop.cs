public class Drop
{
    private Item _item;
    private int _chance;

    public Drop(Item item, int chance)
    {
        _item = item;
        _chance = chance;
    }

    public Item Item => _item;
    public int Chance => _chance;
}