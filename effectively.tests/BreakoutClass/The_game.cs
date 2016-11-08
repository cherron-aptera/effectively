﻿using effectively.BreakoutClass;
using NUnit.Framework;
using System;
using System.IO;
using UglyTrivia;

namespace effectively.tests.BreakoutClass {
    [TestFixture]
    public class The_game {
        private static Game aGame;
        private static Mover mover;

        [Test]
        public void Works() {

            FileStream fs = new FileStream("thegameworks.txt", FileMode.Create);
            TextWriter tmp = Console.Out;
            StreamWriter sw = new StreamWriter(fs);
            Console.SetOut(sw);
            bool notAWinner;

            Game aGame = new Game();

            aGame.addPlayer("Chet");
            aGame.addPlayer("Pat");
            aGame.addPlayer("Sue");

            Random rand = new Random(1);

            do {

                aGame.roll(rand.Next(5) + 1);

                if (rand.Next(9) == 7) {
                    notAWinner = aGame.wrongAnswer();
                } else {
                    notAWinner = aGame.wasCorrectlyAnswered();
                }



            } while (notAWinner);

            Console.SetOut(tmp);
            sw.Close();

            Assert.AreEqual(ApprovedTest, File.ReadAllText(fs.Name));
        }


        [TestFixture]
        public class GivenThePlayerHasJustGottenOutOfThePenaltyBox {
            [Test]
            public void ThenThePlayersPlaceIsOnlyAdvancedByOneLessThanTheCurrentRoll() {
                ArrangeGame();
                mover.MakeNormalMove(5, 0, true);
                Assert.AreEqual(4, aGame.places[0]);
            }
        }

        [TestFixture]
        public class GivenThePlayerNotInThePenaltyBox {
            [Test]
            public void ThenThePlayerMovesTheCurrentRoll() {
                ArrangeGame();
                mover.MakeNormalMove(5, 0, false);
                Assert.AreEqual(5, aGame.places[0]);
            }
        }

        private static void ArrangeGame() {
            aGame = new Game();
            mover = new Mover(aGame);
            aGame.addPlayer("mindy");
            aGame.places[0] = 0;
        }

        private string ApprovedTest = @"Chet was added
They are player number 1
Pat was added
They are player number 2
Sue was added
They are player number 3
Chet is the current player
They have rolled a 2
Chet's new location is 2
The category is Sports
Sports Question 0
Answer was corrent!!!!
Chet now has 1 Gold Coins.
Pat is the current player
They have rolled a 3
Pat's new location is 3
The category is Rock
Rock Question 0
Answer was corrent!!!!
Pat now has 1 Gold Coins.
Sue is the current player
They have rolled a 4
Sue's new location is 4
The category is Pop
Pop Question 0
Answer was corrent!!!!
Sue now has 1 Gold Coins.
Chet is the current player
They have rolled a 2
Chet's new location is 4
The category is Pop
Pop Question 1
Answer was corrent!!!!
Chet now has 2 Gold Coins.
Pat is the current player
They have rolled a 1
Pat's new location is 4
The category is Pop
Pop Question 2
Answer was corrent!!!!
Pat now has 2 Gold Coins.
Sue is the current player
They have rolled a 1
Sue's new location is 5
The category is Science
Science Question 0
Answer was corrent!!!!
Sue now has 2 Gold Coins.
Chet is the current player
They have rolled a 2
Chet's new location is 6
The category is Sports
Sports Question 1
Answer was corrent!!!!
Chet now has 3 Gold Coins.
Pat is the current player
They have rolled a 4
Pat's new location is 8
The category is Pop
Pop Question 3
Answer was corrent!!!!
Pat now has 3 Gold Coins.
Sue is the current player
They have rolled a 2
Sue's new location is 7
The category is Rock
Rock Question 1
Answer was corrent!!!!
Sue now has 3 Gold Coins.
Chet is the current player
They have rolled a 4
Chet's new location is 10
The category is Sports
Sports Question 2
Answer was corrent!!!!
Chet now has 4 Gold Coins.
Pat is the current player
They have rolled a 5
Pat's new location is 1
The category is Science
Science Question 1
Answer was corrent!!!!
Pat now has 4 Gold Coins.
Sue is the current player
They have rolled a 1
Sue's new location is 8
The category is Pop
Pop Question 4
Answer was corrent!!!!
Sue now has 4 Gold Coins.
Chet is the current player
They have rolled a 4
Chet's new location is 2
The category is Sports
Sports Question 3
Answer was corrent!!!!
Chet now has 5 Gold Coins.
Pat is the current player
They have rolled a 4
Pat's new location is 5
The category is Science
Science Question 2
Answer was corrent!!!!
Pat now has 5 Gold Coins.
Sue is the current player
They have rolled a 5
Sue's new location is 1
The category is Science
Science Question 3
Question was incorrectly answered
Sue was sent to the penalty box
Chet is the current player
They have rolled a 3
Chet's new location is 5
The category is Science
Science Question 4
Answer was corrent!!!!
Chet now has 6 Gold Coins.
";
    }
}