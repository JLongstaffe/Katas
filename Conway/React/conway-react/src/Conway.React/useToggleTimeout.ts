
import { useState, useEffect } from 'react';

function useToggleTimeout(action: () => void, timeoutMs: number)
{
    const state = useState(false);

    const [isOn] = state;

    useEffect(() =>
    {
        const timeout = isOn ? setTimeout(action, timeoutMs) : null;

        return () =>
        {
            if (timeout === null) return;

            clearTimeout(timeout);
        };
    });

    return state;
}

export default useToggleTimeout;