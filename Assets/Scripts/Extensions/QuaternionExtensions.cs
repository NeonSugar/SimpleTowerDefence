using UnityEngine;

namespace SimpleTowerDefence.Extensions
{
	public static class QuaternionExtensions
	{
		public static Quaternion With(this Quaternion origin, float? x = null, float? y = null, float? z = null, float? w = null)
		{
			var result = new Quaternion();
			result.Set(x ?? origin.x, y ?? origin.y, z ?? origin.z, w ?? origin.w);
			return result;
		}
	}
}
