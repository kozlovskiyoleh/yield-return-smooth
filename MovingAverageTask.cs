using System.Collections.Generic;
using System.Linq;

namespace yield;

public static class MovingAverageTask
{
	public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth)
	{
		Queue<double> window = new();
        double sum = 0;
		foreach (DataPoint point in data)
		{
            window.Enqueue(point.OriginalY);
            sum += point.OriginalY;
            yield return point.WithAvgSmoothedY(sum/window.Count);
            if (window.Count == windowWidth)
            {
                sum = sum - window.Dequeue();
            }   
        }
    }
}