using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace BOYAREGames.Resources
{
    public class ResourcesManager : MonoBehaviour
    {
        [SerializeField] private TMP_Text[] _uiResourcesAmountText;

        private Dictionary<ResourceType, int> _resource = new Dictionary<ResourceType, int>();
        private Dictionary<ResourceType, TMP_Text> _UIResource = new Dictionary<ResourceType, TMP_Text>();

        private void Awake()
        {
            foreach (var type in Enum.GetNames(typeof(ResourceType)))
            {
                _resource.Add((ResourceType)Enum.Parse(typeof(ResourceType), type), 0);
            }

            for (int i = 0; i < Enum.GetNames(typeof(ResourceType)).Length; i++)
            {
                _UIResource.Add((ResourceType)Enum.Parse(typeof(ResourceType), Enum.GetNames(typeof(ResourceType))[i]), _uiResourcesAmountText[i]);
            }

            Add(ResourceType.Gold, 100);
            Add(ResourceType.Stone, 10);
            Add(ResourceType.Iron, 11);
        }

        public void Add(ResourceType type, int value)
        {
            _resource[type] = Get(type) + value;

            _UIResource[type].text = _resource[type].ToString();
        }

        public int Get(ResourceType type)
        {
            return _resource.GetValueOrDefault(type);
        }

        private void OnValidate()
        {
            Array.Resize<TMP_Text>(ref _uiResourcesAmountText, Enum.GetNames(typeof(ResourceType)).Length);
        }
    }
}
