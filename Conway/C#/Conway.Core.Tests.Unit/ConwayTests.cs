
using System;
using System.Collections;
using System.Linq;

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

        private static IEnumerable First_state_test_cases()
        {
            yield return new [] { new [] { 1, 1 },
                                  new [] { 0, 0 } };

            yield return new [] { new [] { 1, 1 },
                                  new [] { 1, 0 } };
        }

        [TestCaseSource(nameof(First_state_test_cases))]
        public void First_state_is_initial_state(int[][] initialState)
        {
            var state = ToBoolArray(initialState);

            Assert.That(Conway.States(state).First(),
                        Is.EqualTo(state));
        }

        private static IEnumerable Next_state_test_cases()
        {
            yield return new TestCaseData
                (new [] { new [] { 0, 0 },
                          new [] { 0, 0 } },
                 new [] { new [] { 0, 0 },
                          new [] { 0, 0 } });

            yield return new TestCaseData
                (new [] { new [] { 1, 1 },
                          new [] { 0, 0 } },
                 new [] { new [] { 0, 0 },
                          new [] { 0, 0 } });

            yield return new TestCaseData
                (new [] { new [] { 1, 1 },
                          new [] { 1, 0 } },
                 new [] { new [] { 1, 1 },
                          new [] { 1, 1 } });

            yield return new TestCaseData
                (new [] { new [] { 1, 1 },
                          new [] { 1, 1 } },
                 new [] { new [] { 1, 1 },
                          new [] { 1, 1 } });
        }

        [TestCaseSource(nameof(Next_state_test_cases))]
        public void Next_state_is_generated_correctly(int[][] initialState,
                                                      int[][] nextState)
        {
            var state1 = ToBoolArray(initialState);

            var state2 = ToBoolArray(nextState);

            Assert.That(Conway.States(state1).Skip(1).First(),
                        Is.EqualTo(state2));
        }

        [Test]
        public void Oscillating_blinker_example()
        {
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

        private static bool[][] ToBoolArray(int[][] intArray) =>
            intArray.Select(row => row.Select(x => x == 1).ToArray())
                    .ToArray();
    }
}