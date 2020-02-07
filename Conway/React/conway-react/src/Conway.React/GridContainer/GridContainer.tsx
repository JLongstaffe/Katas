
import React, { FunctionComponent, useState } from 'react';

import Grid from '../Grid/Grid';

import useToggleTimeout from '../useToggleTimeout';

import * as Conway from '../../Conway.Core/Conway';

const GridContainer: FunctionComponent<IGridProperties> = ({ updateFrequency }) =>
{
    const [grid, setGrid] = useState(initialGrid);

    const onNext = () => setGrid(Conway.NextState(grid));

    const [playing, setPlaying] = useToggleTimeout(onNext, updateFrequency);

    const togglePlay = () => setPlaying(!playing);

    return <>
             <Grid grid={grid} setGrid={setGrid} />

             <button onClick={onNext}>Next</button>
             <button onClick={togglePlay}>{playing ? 'Pause' : 'Play'}</button>
           </>;
}

const initialGrid: ReadonlyArray<ReadonlyArray<boolean>> =
    [ [ false, false, false, true, false, false, false ],
      [ false, false, false, true, false, false, false ],
      [ false, false, false, true, false, false, false ],
      [ false, false, false, true, false, false, false ],
      [ false, false, false, true, false, false, false ],
      [ false, false, false, true, false, false, false ],
      [ false, false, false, true, false, false, false ] ];

interface IGridProperties
{
    updateFrequency: number;
}

export default GridContainer;
