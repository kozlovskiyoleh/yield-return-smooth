using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace yield;

public static class MovingMaxTask
{
	public static IEnumerable<DataPoint> MovingMax(this IEnumerable<DataPoint> data, int windowWidth)
	{
		LinkedList<double> window = new();
		double max = 0;
		
		foreach(var point in data)
		{
            if (window.Count == windowWidth)
            {
                window.RemoveFirst();
                max = windowWidth > 1 ? window.Max() : 0;
                
            }

            window.AddLast(point.OriginalY);

            if (max >= point.OriginalY)
			{
				yield return point.WithMaxY(max);
			}

			if(max < point.OriginalY) 
			{
				yield return point.WithMaxY(point.OriginalY);
				max = point.OriginalY;
			}
        }
	}
}