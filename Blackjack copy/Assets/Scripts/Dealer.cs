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
    public GameObject[] playerCardPositions;

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
            dealerHand = DealDealerCards(dealerHand);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            for (int i = 0; i < playerHands.Count; i++)
            {
                playerHands[i] = DealPlayerCards(playerHands[i], i);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            SpawnCard(0, deck[13]);
        }
    }

    public Hand DealDealerCards(Hand dealerHand)
    {
        if (dealerHand == null)
        {
            dealerHand = new Hand();
        }
        if (dealerHand.cards.Count <= 1)
        {
            AddCardToHand(dealerHand, 0);
            AddCardToHand(dealerHand, 0);
            Debug.Log(dealerHand);
            Debug.Log("Hand value is: " + dealerHand.CalculateValue());
        }
        else if (dealerHand.CalculateValue() < dealerStayValue)
        {
            AddCardToHand(dealerHand, 0);
            Debug.Log(dealerHand);
            Debug.Log("Hand value is: " + dealerHand.CalculateValue());
        }
        return dealerHand;
    }

    public Hand DealPlayerCards(Hand dealHand, int playerHandIndex)
    {
        if (dealHand == null)
        {
            dealHand = new Hand();
        }
        if (dealHand.cards.Count <= 1)
        {
            AddCardToHand(dealHand, playerHandIndex);// paska ei toimi
            AddCardToHand(dealHand, playerHandIndex);
            Debug.Log(dealHand);
            Debug.Log("Hand value is: " + dealHand.CalculateValue());
        }
        else if (dealHand.CalculateValue() < 21)
        {
            AddCardToHand(dealHand, 1);
            Debug.Log(dealHand);
            Debug.Log("Hand value is: " + dealHand.CalculateValue());
        }
        if (dealHand.CalculateValue() > 21)
        {
            Debug.Log("Over!");
        }

        return dealHand;
    }

    public Hand AddCardToHand(Hand hand, int handPosIndex)
    {
        Card cardToDeal = deck[deck.Count - 1];
        hand.AddCard(cardToDeal);
        deck.Remove(cardToDeal);
        SpawnCard(handPosIndex, cardToDeal);
        return hand;
    }

    public void SpawnCard(int handIndex, Card card)
    {
        GameObject playerHandPos = playerCardPositions[handIndex];
        GameObject cardObject = deckScript.cardObjects[card.index];
        Instantiate(cardObject, playerHandPos.transform.position, Quaternion.identity);
        MoveCardPosition(handIndex);
    }

    private void MoveCardPosition(int playerNum)
    {
        Vector3 pos = playerCardPositions[playerNum].transform.position;
        pos = new Vector3(pos.x + 0.1f, pos.y - 0.1f, pos.z);
        playerCardPositions[playerNum].transform.position = pos;
    }
}
