using System.Collections.Generic;
using UnityEngine;

namespace CodeBase
{
	public class WayPoints
	{
		private readonly Queue<Transform> _points;

		public WayPoints(IEnumerable<Transform> wayPoints)
		{
			_points = new Queue<Transform>(wayPoints);
			NextPoint = _points.Dequeue();
		}

		public Transform NextPoint { get; private set; }

		public void MoveNext()
		{
			_points.Enqueue(NextPoint);

			NextPoint = _points.Dequeue();
		}
	}
}