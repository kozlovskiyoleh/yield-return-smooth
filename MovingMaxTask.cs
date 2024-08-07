using System;
using System.Collections.Generic;
using System.Linq;

namespace yield;

public static class MovingMaxTask
{
	public static IEnumerable<DataPoint> MovingMax(this IEnumerable<DataPoint> data, int windowWidth)
	{
		//Fix me!
		LinkedList<double> window = new();
		double max = 0;
		
		foreach(var point in data)
		{
            if (window.Count == 0)
			{
				yield return point.WithMaxY(point.OriginalY);
                window.AddLast(point.OriginalY);
				max = point.OriginalY;
				continue;
            }

            if (window.Count == windowWidth)
            {
                window.RemoveFirst();
                max = window.Last();
            }

            if (max >= point.OriginalY)
			{                
                yield return point.WithMaxY(max);
                window.AddLast(point.OriginalY);
            }
				
			if (max < point.OriginalY)
			{
                yield return point.WithMaxY(point.OriginalY);
				max = point.OriginalY;
                window.AddLast(point.OriginalY);
            }
        }

	}
}