
using System;
using System.Linq;
using System.Text.RegularExpressions;

using NUnit.Framework;

namespace Conway.Core.Tests.Unit
{
    public class ConwayTests
    {
        [Test]
        public void Cannot_call_with_null_arguments()
        {
            Assert.That(() => Conway.States(null).ToArray(),
                        Throws.TypeOf<ArgumentNullException>());
        }

        [TestCase(@"11
                    00")]

        [TestCase(@"11
                    10")]
        public void First_state_is_initial_state(string initialState)
        {
            var cells = To2DBool(initialState);

            Assert.That(Conway.States(cells).First(), Is.EqualTo(cells));
        }

        [TestCase(@"00
                    00",
                  @"00
                    00")]

        [TestCase(@"11
                    00",
                  @"00
                    00")]

        [TestCase(@"11
                    10",
                  @"11
                    11")]

        [TestCase(@"11
                    11",
                  @"11
                    11")]
        public void Next_state_is_generated_correctly(string initialState,
                                                      string nextState)
        {
            Assert.That(Conway.States(To2DBool(initialState)).Skip(1).First(),
                        Is.EqualTo(To2DBool(nextState)));
        }

        [Test]
        public void Oscillating_blinker_example()
        {
            static bool[][] ToBoolArray(int[][] intArray) =>
                intArray.Select(row => row.Select(x => x == 1).ToArray())
                        .ToArray();

            var horizontalState = ToBoolArray(new []
                { new [] { 0, 0, 0 },
                  new [] { 1, 1, 1 },
                  new [] { 0, 0, 0 } });

            var verticalState = ToBoolArray(new []
                { new [] { 0, 1, 0 },
                  new [] { 0, 1, 0 },
                  new [] { 0, 1, 0 } });

            var states = Conway.States(horizontalState);

            Assert.That(states.Take(3),
                        Is.EqualTo(new [] { horizontalState,
                                            verticalState,
                                            horizontalState }));
        }

        private bool[][] To2DBool(string input)
        {
            var cells = Regex.Replace(input, @"\s+", "").ToCharArray();

            static bool ToBool(char c) => c == '1';

            return new [] { cells.Take(2).Select(ToBool).ToArray(),
                            cells.Skip(2).Take(2).Select(ToBool).ToArray() };
        }
    }
}