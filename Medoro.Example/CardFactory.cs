using System;
using Medoro.Models;

namespace Medoro.Example
{
    public class CardFactory
    {
        public static Card ChallengeFlow()
        {
            return Card.CreateByNewCard(
                "Ivan Ivanov",
                "4012000000020006",
                (DateTime.Now.Month + 2) ,
                (DateTime.Now.Year + 1) % 100,
                123
            );
        }
    }
}