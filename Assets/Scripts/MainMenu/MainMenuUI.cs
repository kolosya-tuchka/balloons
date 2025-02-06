using UnityEngine;
using UnityEngine.UI;

namespace MainMenu
{
    public class MainMenuUI : MonoBehaviour
    {
        [field:SerializeField] public Button PlayButton { get; private set; }
        [field:SerializeField] public Button RecordsButton { get; private set; }
    }
}