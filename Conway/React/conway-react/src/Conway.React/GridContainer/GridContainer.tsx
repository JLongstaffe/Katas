
import React, { FunctionComponent, useState } from 'react';

import Grid from '../Grid/Grid';

import useInterval from '../useInterval';

import * as Conway from '../../Conway.Core/Conway';

const GridContainer: FunctionComponent<IGridProperties> = ({ initialGrid, height, width, updateFrequency }) =>
{
    const [grid, setGrid] = useState(initialGrid);

    const onNext = () => setGrid(Conway.NextState(grid));

    const [playing, setPlaying] = useInterval(onNext, updateFrequency);

    const togglePlay = () => setPlaying(!playing);

    return <>
             <Grid grid={grid} setGrid={setGrid} />

             <button onClick={onNext}>Next</button>
             <button onClick={togglePlay}>{playing ? 'Pause' : 'Play'}</button>
           </>;
}

interface IGridProperties
{
    initialGrid: Readonly2D<boolean>;

    height: number;

    width: number;

    updateFrequency: number;
}

type Readonly2D<T> = ReadonlyArray<ReadonlyArray<T>>;

export default GridContainer;
