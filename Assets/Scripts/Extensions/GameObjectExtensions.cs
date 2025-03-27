using UnityEngine;

namespace SimpleTowerDefence.Extensions
{
	public static class GameObjectExtensions
	{
		public static bool IsDestroyed(this GameObject origin)
		{
			return origin == null && !ReferenceEquals(origin, null);
		}
	}
}
