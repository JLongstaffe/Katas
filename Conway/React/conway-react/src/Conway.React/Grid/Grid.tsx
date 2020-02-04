
import React, { FunctionComponent, useState } from 'react';

import './Grid.css';

interface IGridProperties
{
    initialGrid: Readonly2D<boolean>;
}

interface ICellProperties
{
    isAlive: boolean;

    setAlive: (alive: boolean) => void;
}

const Grid: FunctionComponent<IGridProperties> = ({ initialGrid }) =>
{
    const [grid, setGrid] = useState(initialGrid);

    const setCell = (cell: Cell) => setGrid(withCell(grid, cell));

    const rows = grid.map((row, y) =>
        <tr>
            { row.map((_, x) =>
                <Cell isAlive={ grid[y][x] }
                      setAlive={ (isAlive) => setCell({ x, y, isAlive }) } />) }
        </tr>)

    return <table>{ rows }</table>;
}

const Cell: FunctionComponent<ICellProperties> = ({ isAlive, setAlive } ) =>
{
    const cellStyle = { backgroundColor: (isAlive ? "grey" : "white") };

    const toggleAlive = () => setAlive(!isAlive);

    return <td style={cellStyle} onClick={toggleAlive}>&nbsp;</td>
}

function withCell(grid: Readonly2D<boolean>, cell: Cell): Readonly2D<boolean>
{
    return grid.map((row, y) =>
        row.map((_, x) => x === cell.x && y === cell.y
                        ? cell.isAlive
                        : grid[y][x]));
}

type Readonly2D<T> = ReadonlyArray<ReadonlyArray<T>>;

type Cell = { x: number, y: number, isAlive: boolean };

export default Grid;