using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand
{
    public List<Card> cards;
    
    public Hand()
    {
        this.cards = new List<Card> ();
    }

    public void AddCard(Card card)
    {
        cards.Add(card);
    }

    public int CalculateValue()
    {
        int value = 0;
        for (int i = 0; i < cards.Count; i++) 
        { 
            value += cards[i].GetTrueValue();
        }
        return value;
    }

    public override string ToString()
    {
        string retVal = "";
        for(int i = 0; i < cards.Count; i++)
        {
            retVal += cards[i].ToString() + " ";
        }
        return retVal;
    }
}
