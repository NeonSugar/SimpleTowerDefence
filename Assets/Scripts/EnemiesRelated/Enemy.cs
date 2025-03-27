using SimpleTowerDefence.Shared;
using SimpleTowerDefence.WalletRelated;
using UnityEngine;

namespace SimpleTowerDefence.EnemiesRelated
{
	[RequireComponent(typeof(Damageable))]
	public class Enemy : MonoBehaviour
	{
		[SerializeField] private Damageable _damageable;
		[SerializeField] private SimpleMovement _movement;
		[SerializeField] private ParticleSystem _dieEffectPrefab;
		[SerializeField] private int _cost;

		private void Awake()
		{
			_damageable = GetComponent<Damageable>();
		}

		private void Start()
		{
			Subscribe();
		}

		private void OnDestroy()
		{
			Unsubscribe();
		}

		private void Subscribe()
		{
			_damageable.ZeroHealthReached += WhenZeroHealthReached;
		}
		private void Unsubscribe()
		{
			_damageable.ZeroHealthReached -= WhenZeroHealthReached;
		}

		public void ApplyDamage(float damage)
		{
			_damageable.ApplyDamage(damage);
		}

		private void WhenZeroHealthReached()
		{
			Instantiate(_dieEffectPrefab, transform.position, new ());
			Wallet.Instance.Deposit(_cost);
			Destroy(gameObject);
		}
	}
}
