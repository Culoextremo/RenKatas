namespace UnoRen;

public static class TestApi
{
    public static Card SomeCard => new Card(Color.Yellow, 4);
    public static Card OtherCard => new Card(Color.Yellow, 1);
    public static Card MatchingCard => SameColorCard;
    public static Card SameColorCard => new Card(Color.Yellow, 7);
    public static Card SameNumberAndDifferentColorCard => new Card(Color.Green, 4);
    public static Card UnmatchingCard => new Card(Color.Green, 8);
}