using System;
using SimpleTowerDefence.BuilderRelated.UpgradeRelated;
using SimpleTowerDefence.Shared;
using UnityEngine;

namespace SimpleTowerDefence.BuilderRelated
{
	[RequireComponent(typeof(Damageable))]
	public class Building : MonoBehaviour
	{
		[field: SerializeField] private BuildingData _data;

		public IReadOnlyBuildingData Data => _data;

		public Damageable Damageable { get; private set; }

		private void Awake()
		{
			Damageable = GetComponent<Damageable>();
		}

		private void Start()
		{
			Damageable.ZeroHealthReached += WhenZeroHealthReached;
		}

		private void OnDestroy()
		{
			Damageable.ZeroHealthReached -= WhenZeroHealthReached;
		}

		private void OnMouseDown()
		{
			UpgradeRepresentation.Instance.Show(Data);
		}

		public void Upgrade()
		{
			if(_data.Level == _data.MaxLevel) throw new ($"{gameObject.name} can't be upgraded. {_data.Level} lvl. is max level");

			throw new NotImplementedException();
		}

		private void WhenZeroHealthReached()
		{
			Destroy(gameObject);
			throw new NotImplementedException();
		}
	}
}
