using UI;
using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenuUI : MonoBehaviour
    {
        [field:SerializeField] public ButtonWithClickSound PlayButton { get; private set; }
        [field:SerializeField] public ButtonWithClickSound RecordsButton { get; private set; }
    }
}