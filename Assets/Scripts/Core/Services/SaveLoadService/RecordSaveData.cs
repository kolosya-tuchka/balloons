using System;

namespace Core.Services.SaveLoadService
{
    [Serializable]
    public class RecordSaveData
    {
        public string Name;
        public int Score;

        public RecordSaveData(string name, int score)
        {
            Name = name;
            Score = score;
        }
    }
}