using UnityEngine;

namespace BOYAREGames.UI
{
    public class ButtonDropMoney : MonoBehaviour
    {
        public void OnClick()
        {
            Events.Events.Player.onDropCoinAction?.Invoke();
        }
    }
}
