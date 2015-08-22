﻿namespace Santase.Logic.Players
{
    using System.Collections.Generic;

    using Santase.Logic.Cards;

    public abstract class BasePlayer : IPlayer
    {
        protected BasePlayer()
        {
            this.Cards = new List<Card>();
        }

        protected IList<Card> Cards { get; }

        public virtual void AddCard(Card card)
        {
            this.Cards.Add(card);
        }

        public abstract PlayerAction GetTurn(
            PlayerTurnContext context,
            IPlayerActionValidater actionValidater);

        public virtual void EndTurn(PlayerTurnContext context)
        {
        }

        protected Announce PossibleAnnounce(Card cardToBePlayed, Card trumpCard)
        {
            CardType cardTypeToSearch;
            if (cardToBePlayed.Type == CardType.Queen)
            {
                cardTypeToSearch = CardType.King;
            }
            else if (cardToBePlayed.Type == CardType.King)
            {
                cardTypeToSearch = CardType.Queen;
            }
            else
            {
                return Announce.None;
            }

            var cardToSearch = new Card(
                cardToBePlayed.Suit,
                cardTypeToSearch);

            if (!this.Cards.Contains(cardToSearch))
            {
                return Announce.None;
            }

            if (cardToBePlayed.Suit == trumpCard.Suit)
            {
                return Announce.Fourty;
            }
            else
            {
                return Announce.Twenty;
            }
        }
    }
}