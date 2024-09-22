using SimpleTowerDefence.WalletRelated;
using UnityEngine;

namespace SimpleTowerDefence.BuilderRelated
{
    public class Blueprint : MonoBehaviour
    {
        [field: SerializeField]
        public Building BuildingPrefab { get; private set; }

        [SerializeField] private SpriteRenderer _spriteRenderer;

        private IReadOnlyBuildingData _data;

        private void Awake()
        {
            _data = BuildingPrefab.Data;
        }

        public void ChangeColor(Color color)
        {
            _spriteRenderer.color = color;
        }

        public bool TryBuild()
        {
            if (Wallet.Instance.TryWithdraw(_data.Cost) is false) return false;

            Instantiate(BuildingPrefab, transform.position, new ());
            Destroy();
            return true;
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
