using UnityEngine;

namespace SimpleTowerDefence.Extensions
{
	public static class TransformExtensions
	{
		public static void DestroyAllChildren(this Transform origin)
		{
			foreach(Transform child in origin)
			{
				Object.Destroy(child.gameObject);
			}
		}
	}
}
