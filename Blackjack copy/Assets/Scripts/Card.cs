public enum Suit { hearts, diamonds, clubs, spades };

public class Card
{

    public Suit suit;
    public int rank;
    public int index;

    public Card(Suit suit, int rank, int index)
    {
        this.suit = suit;
        this.rank = rank;
        this.index = index;
    }

    public int GetTrueValue()
    {
        if(rank == 14)
        {
            return 11;
        }
        else if(rank > 10)
        {
            return 10;
        }
        else
        {
            return rank;
        }
    }

    public override string ToString()
    {
        return suit.ToString() + " " + rank.ToString();
    }
}