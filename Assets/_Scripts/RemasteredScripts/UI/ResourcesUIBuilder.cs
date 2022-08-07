using TMPro;
using UnityEngine;

namespace GameInit.Builders
{
    public class ResourcesUIBuilder
    {
        private TMP_Text _goldAmountText;
        private ResourcesUISettings _resourcesUISettings;

        public ResourcesUIBuilder()
        {
            _resourcesUISettings = Object.FindObjectOfType<ResourcesUISettings>();
            _goldAmountText = _resourcesUISettings.GoldAmountText;
        }

        public void UpdateUI(string amountString)
        {
            _goldAmountText.text = amountString;
        }
    }
}
