using UnityEngine;

namespace SimpleTowerDefence.Extensions
{
	public static class Vector2Extension
	{
		public static Vector2 With(this Vector2 origin, float? x = null, float? y = null)
		{
			return new (x ?? origin.x,
						y ?? origin.y);
		}
	}
}
