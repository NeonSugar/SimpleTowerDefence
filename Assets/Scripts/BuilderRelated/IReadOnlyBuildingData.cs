using UnityEngine;

namespace SimpleTowerDefence.BuilderRelated
{
	public interface IReadOnlyBuildingData
	{
		public int MaxLevel { get; }
		public int Level { get; }

		public Sprite Icon { get; }
		public string Name { get; }
		public int    Cost { get; }

		public BuildingType Type { get; }
	}
}
