using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;
using Random = System.Random;

public class Deck : MonoBehaviour
{
    public List<Card> cards = new List<Card>();

    private static Random random = new Random();

    public GameObject[] cardObjects;

    private void Start()
    {
        int cardRank = 2;
        Suit suitToAdd = 0;
        for (int i = 0; i <= 51; i++)
        {
            Card newCard = new Card(suitToAdd, cardRank, i);
            cards.Add(newCard);
            //Debug.Log(cards[i].ToString() + " : " + i);
            cardRank++;
            if (cardRank > 14)
            {
                suitToAdd++;
                cardRank = 2;
            }
        }
        //Debug.Log("card 5 is: " + cards[4].suit + cards[4].rank.ToString());
        //Debug.Log(cards[4]);
        ShuffleCards(cards);
        for(int i = 0; i < cards.Count; i++)
        {
            Debug.Log(cards[i] + " | " + i);
        }

    }

    public static List<Card> ShuffleCards(List<Card> cardsToShuffle)
    {
        for(int i = cardsToShuffle.Count - 1; i > 0 ; i--)
        {
            var k = random.Next(i + 1);
            var value = cardsToShuffle[k];
            cardsToShuffle[k] = cardsToShuffle[i];
            cardsToShuffle[i] = value;
        }
        return cardsToShuffle;
    }
}
