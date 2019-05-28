using System;
using Xunit;

namespace TennisKata
{
    public class TennisGameTests
    {
        private TennisGame tennisGame;

        public TennisGameTests()
        {
            SetUpNewTennisGame();
        }

        private void SetUpNewTennisGame()
        {
            tennisGame = new TennisGame
            {
                Player1 = new Player(),
                Player2 = new Player()
            };
        }

        [Fact]
        public void ShouldReportScoreAsLoveAllWhenNeitherPlayersHaveAnyPoints()
        {
            //assert
            var score = tennisGame.GetScore();
            Assert.Equal("love - all", score);
        }

        [Fact]
        public void ShouldReportScoreAsFifteenLoveWhenPlayerScoresFirstPoint()
        {
            //act
            tennisGame.Player1.WinsPoint();
            //assert
            var score = tennisGame.GetScore();
            Assert.Equal("fifteen - love", score);
        }

        [Fact]
        public void ShouldReportScoreAsFifteenAllWhenBothPlayersHaveScoredOnePoint()
        {
            //act
            tennisGame.Player1.WinsPoint();
            tennisGame.Player2.WinsPoint();
            //assert
            Assert.Equal("fifteen - all", tennisGame.GetScore());
        }

        [Fact]
        public void ShouldReportScoreAsThirtyFifteenWhenOnePlayerHasScoredTwoPointsAndOnePlayerHasScoredOnePoint()
        {
            //act
            PlayerWinsPoints(tennisGame.Player1, 2);
            tennisGame.Player2.WinsPoint();
            //assert
            Assert.Equal("thirty - fifteen", tennisGame.GetScore());
        }

        [Fact]
        public void ShouldReportScoreAsThirtyFortyWhenOnePlayerHasScoredTwoPointsAndOnePlayerHasScoredThreePoints()
        {
            //act
            PlayerWinsPoints(tennisGame.Player1, 2);
            PlayerWinsPoints(tennisGame.Player2, 3);
            //assert
            Assert.Equal("thirty - forty", tennisGame.GetScore());
        }

        [Fact]
        public void ShouldReportScoreAsDeuceIfBothPlayersHaveScoredThreePoints()
        {
            //act
            PlayerWinsPoints(tennisGame.Player1, 3);
            PlayerWinsPoints(tennisGame.Player2, 3);
            //assert
            Assert.Equal("Deuce", tennisGame.GetScore());
        }

        [Fact]
        public void ShouldReportPlayerAsHavingAdvantageIfTheyScorePointWhileDeuce()
        {
            //act
            PlayerWinsPoints(tennisGame.Player1, 3);
            PlayerWinsPoints(tennisGame.Player2, 4);
            //assert
            Assert.Equal("Advantage player2", tennisGame.GetScore());
        }

        [Fact]
        public void ShouldReturnToDeuceIfPlayerWithAdvantageLosesNextPoint()
        {
            //act
            PlayerWinsPoints(tennisGame.Player1, 3);
            PlayerWinsPoints(tennisGame.Player2, 4);
            tennisGame.Player1.WinsPoint();
            //assert
            Assert.Equal("Deuce", tennisGame.GetScore());
        }

        [Fact]
        public void ShouldReportWinnerIfPlayerHasAtLeastFourPointsAndTwoMoreThanOtherPlayer()
        {
            //act
            PlayerWinsPoints(tennisGame.Player1, 2);
            PlayerWinsPoints(tennisGame.Player2, 4);
            //assert
            Assert.Equal("Player2 wins", tennisGame.GetScore());
        }

        private void PlayerWinsPoints(Player player, int points)
        {
            for (int i = 0; i < points; i++)
            {
                player.WinsPoint();
            }
        }
    }
}
