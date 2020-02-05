
import React, { FunctionComponent, useState } from 'react';

import Grid from '../Grid/Grid';

import States from '../../Conway.Core/Conway';

const GridContainer: FunctionComponent<{}> = () =>
{
    const [grid, setGrid] = useState(initialGrid);

    const conwayGenerator = States(grid);

    conwayGenerator.next();

    const onNext = () => setGrid(conwayGenerator.next().value);

    return <>
             <Grid grid={grid} setGrid={setGrid} />
             <button onClick={onNext}>Next</button>
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

export default GridContainer;
