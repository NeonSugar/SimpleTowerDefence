using System;
using UnityEngine;

namespace SimpleTowerDefence.WalletRelated
{
	public class Wallet : MonoBehaviour
	{
		[SerializeField] private int _value;
		public int Value
		{
			get => _value;
			private set
			{
				_value = value;
				ValueChanged?.Invoke(_value);
			}
		}

		public Action<int> ValueChanged;
		public Action<int> Deposited;
		public Action<int> Withdrawn;

		public static Wallet Instance;

		private void Awake()
		{
			if(Instance is not null) throw new ($"{Instance.name} already exists!");

			Instance = this;
		}

		public void Deposit(int depositAmount)
		{
			Value += depositAmount;
			Deposited?.Invoke(depositAmount);
		}

		public bool TryWithdraw(int amount)
		{
			if(Value < amount) return false;

			Withdraw(amount);
			return true;
		}

		private void Withdraw(int withdrawAmount)
		{
			Value -= withdrawAmount;
			Withdrawn?.Invoke(withdrawAmount);
		}
	}
}
