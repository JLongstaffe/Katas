
import "core-js"; // for Array.flatMap polyfill

import * as Conway from "./conway";

test("First state is initial state", () =>
{
    [[[1,1],
      [0,0]],

     [[1,1],
      [1,0]]]
    .forEach((initialState) =>
    {
        const state = To2DBoolean(initialState);

        const nextState = Conway.States(state).next().value;

        expect(nextState).toEqual(state);
    })
});

test("Next state is generated correctly", () =>
{
    [
        [[[0,0],
          [0,0]],
         [[0,0],
          [0,0]]],

        [[[1,1],
          [0,0]],
         [[0,0],
          [0,0]]],

        [[[1,1],
          [1,0]],
         [[1,1],
          [1,1]]],

        [[[1,1],
          [1,1]],
         [[1,1],
          [1,1]]]
    ]
    .forEach(([initialState, expectedState]) =>
    {
        const state1 = To2DBoolean(initialState);

        const state2 = To2DBoolean(expectedState);

        const generator = Conway.States(state1);

        generator.next();

        const nextState = generator.next().value;

        expect(nextState).toEqual(state2);
    })
});

test("Oscillating blinker example", () =>
{
    const horizontalState = To2DBoolean([[ 0, 0, 0 ],
                                         [ 1, 1, 1 ],
                                         [ 0, 0, 0 ]]);

    const verticalState = To2DBoolean([[ 0, 1, 0 ],
                                       [ 0, 1, 0 ],
                                       [ 0, 1, 0 ]]);

    const states = Conway.States(horizontalState);

    expect(states.next().value).toEqual(horizontalState);

    expect(states.next().value).toEqual(verticalState);

    expect(states.next().value).toEqual(horizontalState);
});

function To2DBoolean(input: number[][]): boolean[][]
{
    return input.map(x => x.map(y => y == 1));
}