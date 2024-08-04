using System.Collections.Generic;
using System.Linq;

namespace yield;

public static class MovingAverageTask
{
	public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth)
	{
		//MyList<double> currentValues = new MyList<double>();
		double sum = 0;
		int count = 0;
		foreach (DataPoint point in data.Take(windowWidth))
		{
            count++;
            sum = sum + point.OriginalY;
            if (count == windowWidth)
			{
                yield return point.WithAvgSmoothedY(sum / count);
				yield break;
            }
			yield return point.WithAvgSmoothedY(point.OriginalY);
        }
	}
}