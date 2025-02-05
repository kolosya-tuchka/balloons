using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Core.Services.SaveLoadService
{
    public class PlayerPrefsSaveLoadService : ISaveLoadService
    {
        private const string SaveKey = "save";
        //TODO: Move to config
        private const int MaxRecordsCount = 10;
        
        private SaveData _saveData = new();

        public IReadOnlyList<RecordSaveData> GetRecords() =>
            _saveData.Records;

        public void Load()
        {
            var json = PlayerPrefs.GetString(SaveKey);
            _saveData = JsonUtility.FromJson<SaveData>(json) ?? _saveData;
            Debug.Log(json);
        }

        public void Save(RecordSaveData newRecord)
        {
            _saveData.Records = _saveData.Records.ToList().Append(newRecord)
                .OrderByDescending(record => record.Score)
                .Take(MaxRecordsCount) 
                .ToArray();

            var json = JsonUtility.ToJson(_saveData);
            Debug.Log(json);
            PlayerPrefs.SetString(SaveKey, json);
        }
    }
}