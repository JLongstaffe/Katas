
import "core-js"; // for Array.flatMap polyfill

import * as Conway from "./Conway";

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

        const nextState = Conway.NextState(state1);

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

    let state = horizontalState as ReadonlyArray<ReadonlyArray<boolean>>;

    expect(state = Conway.NextState(state)).toEqual(verticalState);

    expect(state = Conway.NextState(state)).toEqual(horizontalState);

    expect(state = Conway.NextState(state)).toEqual(verticalState);
});

function To2DBoolean(input: number[][]): boolean[][]
{
    return input.map(x => x.map(y => y === 1));
}