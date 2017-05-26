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
        PlayerOneWin,
        PlayerTwoWin,
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
                gameResult = WinCheck();
            }

            return gameResult;
        }

        public void PlayRound()
        {
            Random rnd = new Random();

            var playerOneToken = (Token)rnd.Next(0, 2);
            var playerTwoToken = (Token)rnd.Next(0, 2);

            PlayRound(playerOneToken, playerTwoToken);
        }

        public void PlayRound(Token playerOneToken, Token playerTwoToken)
        {
            var result = TokenCheck(playerOneToken, playerTwoToken);

            switch (result)
            {
                    case Result.PlayerOneWin:
                        PlayerOneScore += 1;
                        break;
                    case Result.PlayerTwoWin:
                        PlayerTwoScore += 1;
                        break;
                    case Result.Draw:
                        break;
            }
        }

        public Result WinCheck()
        {
            //best of 3, draws don't count, so first to 2 wins
            if (PlayerOneScore == 2)
            {
                return Result.PlayerOneWin;
            }
            if (PlayerTwoScore == 2)
            {
                return Result.PlayerTwoWin;
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
                                return Result.PlayerTwoWin;
                            case Token.Scissors:
                                return Result.PlayerOneWin;
                    }
                    break;
               case Token.Paper:
                    switch (playerTwoToken)
                    {
                        case Token.Rock:
                            return Result.PlayerOneWin;
                        case Token.Paper:
                            return Result.Draw;
                        case Token.Scissors:
                            return Result.PlayerTwoWin;
                    }
                    break;
                case Token.Scissors:
                    switch (playerTwoToken)
                    {
                        case Token.Rock:
                            return Result.PlayerTwoWin;
                        case Token.Paper:
                            return Result.PlayerOneWin;
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

            Assert.AreEqual(game.TokenCheck(Token.Rock, Token.Scissors), Result.PlayerOneWin);
        }

        [Test]
        public void PaperWinsAgainstRock()
        {
            var game = new Game();

            Assert.AreEqual(game.TokenCheck(Token.Rock, Token.Paper), Result.PlayerTwoWin);
        }

        [Test]
        public void ScissorsWinsAgainstPaper()
        {
            var game = new Game();

            Assert.AreEqual(game.TokenCheck(Token.Paper, Token.Scissors), Result.PlayerTwoWin);
        }

        [Test]
        public void DrawRoundDoesntChangeScore()
        {
            var game = new Game();

            var playerOneScoreBefore = game.PlayerOneScore;
            var playerTwoScoreBefore = game.PlayerTwoScore;

            game.PlayRound(Token.Paper, Token.Paper);

            var playerOneScoreAfter = game.PlayerOneScore;
            var playerTwoScoreAfter = game.PlayerTwoScore;

            Assert.AreEqual(playerOneScoreBefore, playerOneScoreAfter);
            Assert.AreEqual(playerTwoScoreBefore, playerTwoScoreAfter);
        }

        [Test]
        public void PlayerOneWinIncreasesScore()
        {
            var game = new Game();

            var playerOneScoreBefore = game.PlayerOneScore;

            game.PlayRound(Token.Scissors, Token.Paper);

            var playerOneScoreAfter = game.PlayerOneScore;

            Assert.AreEqual(playerOneScoreBefore + 1, playerOneScoreAfter);
        }

        [Test]
        public void PlayerTwoWinIncreasesScore()
        {
            var game = new Game();

            var playerTwoScoreBefore = game.PlayerTwoScore;

            game.PlayRound(Token.Scissors, Token.Rock);

            var playerTwoScoreAfter = game.PlayerTwoScore;

            Assert.AreEqual(playerTwoScoreBefore + 1, playerTwoScoreAfter);
        }
    }
}

