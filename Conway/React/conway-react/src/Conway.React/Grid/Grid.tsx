
import React, { FunctionComponent } from 'react';

import './Grid.css';

interface IGridProperties
{
    grid: Readonly2D<boolean>;
}

interface ICellProperties
{
    alive: boolean;
}

const Grid: FunctionComponent<IGridProperties> = ({ grid }) =>
{
    const rows = grid.map((_, y) =>
        <tr>
            { grid.map((_, x) => <Cell alive={ grid[y][x] } />) }
        </tr>)

    return <table>{ rows }</table>;
}

const Cell: FunctionComponent<ICellProperties> = ({ alive } ) =>
{
    const cellStyle = { backgroundColor: (alive ? "grey" : "white") };

    return <td style={cellStyle}>&nbsp;</td>
}

type Readonly2D<T> = ReadonlyArray<ReadonlyArray<T>>;

export default Grid;