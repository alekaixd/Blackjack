using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Dealer : MonoBehaviour
{
    public int players = 1;
    private int dealerStayValue = 17; // the dealer can't deal themselves anymore if their hands value is 17
    public List<Card> deck;
    public Deck deckScript;
    public List<Hand> playerHands;
    public Hand dealerHand;

    // Start is called before the first frame update
    void Start()
    {
        deck = deckScript.cards;
        playerHands = new List<Hand> ();
        for (int i = 0; i < players; i++)
        {
            playerHands.Add(new Hand());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            dealerHand = DealCards(dealerHand, true);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            for (int i = 0; i < playerHands.Count; i++)
            {
                playerHands[i] = DealCards(playerHands[i], false);
            }
        }
    }


    public Hand DealCards(Hand dealHand, bool isDealerHand)
    {
        if (dealHand == null)
        {
            dealHand = new Hand();
        }
        if (dealHand.cards.Count <= 1)
        {
            Card cardToDeal = deck[deck.Count - 1];
            dealHand.AddCard(cardToDeal);
            deck.Remove(cardToDeal); 
            cardToDeal = deck[deck.Count - 1];
            dealHand.AddCard(cardToDeal);
            deck.Remove(cardToDeal);
            Debug.Log(dealHand);
            Debug.Log("Hand value is: " + dealHand.CalculateValue());
        }
        else if (isDealerHand)
        {
            if (dealHand.CalculateValue() < dealerStayValue)
            {
                Card cardToDeal = deck[deck.Count - 1];
                dealHand.AddCard(cardToDeal);
                deck.Remove(cardToDeal);
                Debug.Log(dealHand);
                Debug.Log("Hand value is: " + dealHand.CalculateValue());
            }
        }
        else if (!isDealerHand && dealHand.CalculateValue() < 21)
        {
            Card cardToDeal = deck[deck.Count - 1];
            dealHand.AddCard(cardToDeal);
            deck.Remove(cardToDeal);
            Debug.Log(dealHand);
            Debug.Log("Hand value is: " + dealHand.CalculateValue());
        }
        if (dealHand.CalculateValue() > 21)
        {
            Debug.Log("Over!");
        }

        return dealHand;
    }
}
