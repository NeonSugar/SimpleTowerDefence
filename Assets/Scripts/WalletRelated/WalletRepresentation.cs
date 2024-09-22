using TMPro;
using UnityEngine;

namespace SimpleTowerDefence.WalletRelated
{
	public class WalletRepresentation : MonoBehaviour
	{
		[SerializeField] private Wallet _wallet;
		[SerializeField] private TMP_Text _textValue;
		[SerializeField] private ParticleSystem _depositEffectPrefab;
		[SerializeField] private Transform _depositEffectParent;

		private void Start()
		{
			WhenValueChanged(_wallet.Value);
			Subscribe();
		}

		private void OnDestroy()
		{
			Unsubscribe();
		}

		private void Subscribe()
		{
			_wallet.ValueChanged += WhenValueChanged;
			_wallet.Deposited += WhenDeposited;
		}
		private void Unsubscribe()
		{
			_wallet.ValueChanged -= WhenValueChanged;
		}

		private void WhenValueChanged(int value)
		{
			_textValue.text = $"{value}";
		}
		private void WhenDeposited(int _)
		{
			Instantiate(_depositEffectPrefab, _depositEffectParent.position, new ());
		}
	}
}
