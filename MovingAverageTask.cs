using System.Collections.Generic;
using System.Linq;

namespace yield;

public static class MovingAverageTask
{
	public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth)
	{
		Queue<double> window = new(windowWidth);
		DataPoint dataPoint = null;
		foreach (DataPoint point in data)
		{
            window.Enqueue(point.OriginalY);
            if (window.Count == windowWidth)
            {
                dataPoint = point.WithAvgSmoothedY(window.Average());
                yield return dataPoint;
                window.Dequeue();
                continue;
            }
            dataPoint = point.WithAvgSmoothedY(point.OriginalY);
		    yield return dataPoint;
        }
	}
}