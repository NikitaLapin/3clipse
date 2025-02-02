using UnityEngine;

namespace _3ClipseGame.Steam.GameMechanics.Interactables.Inheritors.EnemiesLoot.AdditiveScripts
{
    [RequireComponent(typeof(AnimateLoot))]
    public class InactiveLootDisabler : MonoBehaviour
    {
        [SerializeField] private float _disableTime = 0.5f;
        [SerializeField] private string _disabledLayerName = "Decals";

        private Rigidbody _rigidbody;
        private AnimateLoot _animateLoot;

        private float _staticTimer;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _animateLoot = GetComponent<AnimateLoot>();
            if (_animateLoot) 
                _animateLoot.enabled = false;
        }

        private void Update()
        {
            UpdateStaticTimer();
            TryDeactivateRigidbody();
        }

        private void UpdateStaticTimer()
        {
            if (IsStatic() == true) 
                _staticTimer += Time.deltaTime;
            else _staticTimer = 0f;
        }

        private bool IsStatic()
        {
            return _rigidbody.velocity.magnitude == 0f;
        }

        private void TryDeactivateRigidbody()
        {
            if (_staticTimer >= _disableTime) 
                DeactivateRigidbody();
        }

        private void DeactivateRigidbody()
        {
            gameObject.layer = LayerMask.NameToLayer(_disabledLayerName);
            _rigidbody.isKinematic = true;
            AddAnimateLoot();
            Destroy(this);
        }

        private void AddAnimateLoot()
        {
            if (gameObject.TryGetComponent<AnimateLoot>(out var lootComponent) == false) 
                lootComponent = gameObject.AddComponent<AnimateLoot>();

            lootComponent.enabled = true;
        }
    }
}
