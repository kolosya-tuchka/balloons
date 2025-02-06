using System.Collections.Generic;
using Core.Services.AudioService;
using Core.Services.SaveLoadService;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Windows.RecordsWindow
{
    public class RecordsWindow : BaseWindow
    {
        [SerializeField] private List<RecordView> RecordViews;
        [SerializeField] private ButtonWithClickSound CloseButton;

        private IAudioService _audioService;
        
        public void Init(IReadOnlyList<RecordSaveData> records, IAudioService audioService)
        {
            _audioService = audioService;
            
            for (int i = 0; i < records.Count; ++i)
            {
                var record = records[i];
                RecordViews[i].gameObject.SetActive(true);
                RecordViews[i].Init(record.Name, record.Score);
            }

            for (int i = records.Count; i < RecordViews.Count; ++i)
            {
                RecordViews[i].gameObject.SetActive(false);
            }
        }
        
        public override void Show()
        {
            CloseButton.Init(_audioService, Hide);
            
            base.Show();
        }

        public override void Hide()
        {
            CloseButton.DeInit();

            base.Hide();
        }
    }
}