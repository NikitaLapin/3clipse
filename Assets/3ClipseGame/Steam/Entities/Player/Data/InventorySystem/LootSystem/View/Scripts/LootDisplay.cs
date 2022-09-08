using System;
using System.Collections.Generic;
using System.Linq;
using _3ClipseGame.Steam.Entities.Player.Data.InventorySystem.LootSystem.Model.Detector;
using _3ClipseGame.Steam.Entities.Player.Data.InventorySystem.LootSystem.Model.Picker;
using _3ClipseGame.Steam.Global.Scripts.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace _3ClipseGame.Steam.Entities.Player.Data.InventorySystem.LootSystem.View.Scripts
{
    public class LootDisplay : MonoBehaviour
    {
        public event Action<PickableLoot> LootDisplayListDecreased;
        public event Action<PickableLoot> LootDisplayListIncreased; 

        [SerializeField] private LootDetector _lootDetector;
        [SerializeField] private LootIcon _lootIconPrefab;
        [SerializeField] private VerticalLayoutGroup _iconsParent;
        
        private LinkedList<LootInfo> _displayedLoot = new();

        private void OnEnable()
        {
            _lootDetector.NewLootDetected += AddNewIcon;
            _lootDetector.LootRetired += RemoveIcon;
        }

        private void OnDisable()
        {
            _lootDetector.NewLootDetected -= AddNewIcon;
            _lootDetector.LootRetired -= RemoveIcon;
        }
        
        public LootIcon GetIconByObject(PickableLoot loot)
        {
            if (loot == null) throw new NullReferenceException();
            var node = GetNodeByLootObject(loot);
            return node.Value.LootIcon;
        }

        public PickableLoot GetNextLootObject(PickableLoot currentLoot)
        {
            if (currentLoot == null) throw new NullReferenceException();
            var nextElement = GetNextElement(currentLoot);
            return nextElement?.Value.LootObject;
        }

        public PickableLoot GetPreviousLootObject(PickableLoot currentLoot)
        {
            if (currentLoot == null) throw new NullReferenceException();
            var previousElement = GetPreviousElement(currentLoot);
            return previousElement?.Value.LootObject;
        }

        private void AddNewIcon(PickableLoot newLoot)
        {
            var newIcon = InstantiateNewIcon();
            newIcon.SwitchTrack(newLoot);
            _displayedLoot.AddLast(new LootInfo(newLoot, newIcon));
            LootDisplayListIncreased?.Invoke(newLoot);
        }
        
        private void RemoveIcon(PickableLoot retiredLoot)
        {
            var element = GetNodeByLootObject(retiredLoot);
            Destroy(element.Value.LootIcon.gameObject);
            _displayedLoot.Remove(element);
            LootDisplayListDecreased?.Invoke(retiredLoot);
        }

        private LinkedListNode<LootInfo> GetNextElement(PickableLoot currentLoot)
        {
            var currentLootInfo = _displayedLoot.First(element => element.LootObject == currentLoot);
            return _displayedLoot.GetNextListElement(currentLootInfo);
        }

        private LinkedListNode<LootInfo> GetPreviousElement(PickableLoot currentLoot)
        {
            var currentLootInfo = _displayedLoot.First(element => element.LootObject == currentLoot);
            return _displayedLoot.GetPreviousListElement(currentLootInfo);
        }

        private LootIcon InstantiateNewIcon()
        {
            var newObject = Instantiate(_lootIconPrefab, _iconsParent.transform);
            newObject.transform.SetAsLastSibling();
            return newObject;
        }

        private LinkedListNode<LootInfo> GetNodeByLootObject(PickableLoot loot)
        {
            var lootInfo = GetLootInfo(loot);
            return _displayedLoot.GetElementByValue(lootInfo);
        }

        private LootInfo GetLootInfo(PickableLoot loot)
        {
            return _displayedLoot.First(element => element.LootObject == loot);
        }
        
        private class LootInfo
        {
            public readonly PickableLoot LootObject;
            public readonly LootIcon LootIcon;

            public LootInfo(PickableLoot pickableLoot, LootIcon lootIcon)
            {
                LootObject = pickableLoot;
                LootIcon = lootIcon;
            }
        }
    }
}