
import React from 'react';

import './App.css';

import Grid from './Grid/Grid';

const exampleGrid =
    [ [ false, false, false, true, false, false, false ],
      [ false, false, false, true, false, false, false ],
      [ false, false, false, true, false, false, false ],
      [ false, false, false, true, false, false, false ],
      [ false, false, false, true, false, false, false ],
      [ false, false, false, true, false, false, false ],
      [ false, false, false, true, false, false, false ] ]

const App = () => <Grid grid={exampleGrid} />

export default App;
