using System.Collections.Generic;

namespace yield;

public static class ExpSmoothingTask
{
    public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha)
	{
        DataPoint smoothingItem = null;
		foreach (DataPoint point in data)
		{
			if(smoothingItem == null)
			{
				smoothingItem =  new DataPoint(point.WithExpSmoothedY(point.OriginalY));
				yield return smoothingItem;
			}
			else
			{
				var smoothingY = (alpha * point.OriginalY) + ((1 - alpha)* smoothingItem.ExpSmoothedY);
                smoothingItem = new DataPoint(point.WithExpSmoothedY(smoothingY));
				yield return smoothingItem;
			}
		}
	}
}
