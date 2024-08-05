using Avalonia.Controls.Metadata;
using System.Collections.Generic;
using System.Linq;

namespace yield;

public static class MovingAverageTask
{
	public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth)
	{
		LinkedList<double> window = new();
		DataPoint dataPoint = null;
		foreach (DataPoint point in data)
		{
            window.AddFirst(point.OriginalY);
            if (window.Count < windowWidth)
            {
                dataPoint = point.WithAvgSmoothedY(point.OriginalY);
				yield return dataPoint;
            }

			if(window.Count == windowWidth)
			{
				dataPoint = point.WithAvgSmoothedY(window.Average());
				yield return dataPoint;
				window.RemoveLast();
			}
        }
	}
}