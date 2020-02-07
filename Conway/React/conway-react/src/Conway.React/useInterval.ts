
import { useState, useEffect, useRef } from 'react';

function useInterval(callback: () => void, delay: number)
{
    const onState = useState(false);

    const [isOn] = onState;

    const savedCallback = useRef<() => void>(() => {});

    useEffect(() => { savedCallback.current = callback; });

    useEffect(() =>
    {
        function tick(): void
        {
            savedCallback.current();
        }

        let id = isOn ? setInterval(tick, delay) : null;

        return () => clearNullableInterval(id);
    },
    [delay, isOn]);

    return onState;
  }

  function clearNullableInterval(interval: NodeJS.Timeout | null)
  {
      if (interval === null) return;

      clearInterval(interval);
  }

  export default useInterval;