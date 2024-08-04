using Avalonia.Controls.Metadata;
using System.Collections.Generic;
using System.Linq;

namespace yield;

public static class MovingAverageTask
{
	public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth)
	{
		double sum = 0;
		int passedElements = 0;
		DataPoint dataPoint = null;
		foreach(DataPoint point in data)
		{
			sum = sum + point.OriginalY;
			passedElements++;
			dataPoint = new DataPoint(point);
			dataPoint = dataPoint.WithAvgSmoothedY(point.OriginalY);
			if (passedElements == windowWidth)
			{
                dataPoint = dataPoint.WithAvgSmoothedY(sum / windowWidth);
				passedElements = windowWidth - 1;
				sum = dataPoint.OriginalY;
            }
			yield return dataPoint;
		}
	}
}