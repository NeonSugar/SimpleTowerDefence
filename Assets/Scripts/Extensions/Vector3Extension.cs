using UnityEngine;

namespace SimpleTowerDefence.Extensions
{
	public static class Vector3Extension
	{
		public static Vector3 With(this Vector3 origin, float? x = null, float? y = null, float? z = null)
		{
			return new (x ?? origin.x,
						y ?? origin.y,
						z ?? origin.z);
		}
	}
}
