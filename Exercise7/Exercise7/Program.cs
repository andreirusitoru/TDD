using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Exercise7
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public enum Token
    {
        Rock,
        Paper,
        Scissors
    }

    public enum Result
    {
        PlayerOneVictory,
        PlayerTwoVictory,
        Draw
    }

    class Game
    {
        public int PlayerOneScore { get; set; }
        public int PlayerTwoScore { get; set; }

        public Result PlayGame()
        {
            PlayerOneScore = 0;
            PlayerTwoScore = 0;
            Result gameResult = Result.Draw;

            while (gameResult == Result.Draw)
            {
                PlayRound();
                gameResult = VictoryCheck();
            }

            return gameResult;
        }

        public void PlayRound()
        {
            Random rnd = new Random();

            var playerOneToken = (Token) rnd.Next(0, 2);
            var playerTwoToken = (Token) rnd.Next(0, 2);

            var result = TokenCheck(playerOneToken, playerTwoToken);

            switch (result)
            {
                    case Result.PlayerOneVictory:
                        PlayerOneScore += 1;
                        break;
                    case Result.PlayerTwoVictory:
                        PlayerTwoScore += 1;
                        break;
                    case Result.Draw:
                        break;
            }
        }

        public Result VictoryCheck()
        {
            //best of 3, draws don't count, so first to 2 wins
            if (PlayerOneScore == 2)
            {
                return Result.PlayerOneVictory;
            }
            if (PlayerTwoScore == 2)
            {
                return Result.PlayerTwoVictory;
            }

            return Result.Draw;
        }

        public Result TokenCheck(Token playerOneToken, Token playerTwoToken)
        {
            switch (playerOneToken)
            {
                case Token.Rock:
                    switch (playerTwoToken)
                    {
                            case Token.Rock:
                                return Result.Draw;
                            case Token.Paper:
                                return Result.PlayerTwoVictory;
                            case Token.Scissors:
                                return Result.PlayerOneVictory;
                    }
                    break;
               case Token.Paper:
                    switch (playerTwoToken)
                    {
                        case Token.Rock:
                            return Result.PlayerOneVictory;
                        case Token.Paper:
                            return Result.Draw;
                        case Token.Scissors:
                            return Result.PlayerTwoVictory;
                    }
                    break;
                case Token.Scissors:
                    switch (playerTwoToken)
                    {
                        case Token.Rock:
                            return Result.PlayerTwoVictory;
                        case Token.Paper:
                            return Result.PlayerOneVictory;
                        case Token.Scissors:
                            return Result.Draw;
                    }
                    break;
            }
            return Result.Draw;
        }
    }

    [TestFixture]
    class Tests
    {
        [Test]
        public void RockWinsAgainstScissors()
        {
            var game = new Game();

            Token rock = Token.Rock;
            Token scissors = Token.Scissors;

            Assert.AreEqual(game.TokenCheck(rock, scissors), Result.PlayerOneVictory);
        }

        [Test]
        public void PaperWinsAgainstRock()
        {
            var game = new Game();

            Token rock = Token.Rock;
            Token paper = Token.Paper;

            Assert.AreEqual(game.TokenCheck(rock, paper), Result.PlayerTwoVictory);
        }

        [Test]
        public void ScissorsWinsAgainstPaper()
        {
            var game = new Game();

            Token paper = Token.Paper;
            Token scissors = Token.Scissors;

            Assert.AreEqual(game.TokenCheck(paper, scissors), Result.PlayerTwoVictory);
        }
    }
}
