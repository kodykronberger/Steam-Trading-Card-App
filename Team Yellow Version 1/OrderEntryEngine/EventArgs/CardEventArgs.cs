using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderEntryEngine
{
    /// <summary>
    /// The class which is used to represent the card as an event argument.
    /// </summary>
    public class CardEventArgs
    {
        /// <summary>
        /// Initializes a new instance.
        /// </summary>
        /// <param name="card">The card for which the event occurs.</param>
        public CardEventArgs(Card card)
        {
            this.Card = card;
        }

        /// <summary>
        /// Gets the card object of the event.
        /// </summary>
        public Card Card { get; private set; }
    }
}