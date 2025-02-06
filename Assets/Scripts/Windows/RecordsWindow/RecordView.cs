using TMPro;
using UnityEngine;

namespace Windows.RecordsWindow
{
    public class RecordView : MonoBehaviour
    {
        [SerializeField] private TMP_Text NameText;
        [SerializeField] private TMP_Text ScoreText;

        public void Init(string name, int score)
        {
            NameText.text = name;
            ScoreText.text = score.ToString();
        }
    }
}