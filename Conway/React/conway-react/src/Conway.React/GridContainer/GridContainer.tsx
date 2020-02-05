
import React, { FunctionComponent, useState } from 'react';

import Grid from '../Grid/Grid';

const GridContainer: FunctionComponent<{}> = () =>
{
    const [grid, setGrid] = useState(initialGrid);

    return <Grid grid={grid} setGrid={setGrid} />;
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
