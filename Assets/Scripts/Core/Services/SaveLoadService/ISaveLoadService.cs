using System.Collections.Generic;

namespace Core.Services.SaveLoadService
{
    public interface ISaveLoadService
    {
        IReadOnlyList<RecordSaveData> GetRecords();
        void Load();
        void Save(RecordSaveData newRecord);
    }
}