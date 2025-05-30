using System;
using System.Collections.Generic;
using RunTime.Enums;

namespace RunTime.Data.ValueObjects
{
    [Serializable]
    public struct LevelData
    {
        public List<PoolData> PoolList;
        public List<LevelObjectData> ObjectList;

        public LevelData(List<PoolData> datas, List<LevelObjectData> objects)
        {
            PoolList = datas;
            ObjectList = objects;
        }
    }

    [Serializable]
    public struct PoolData
    {
        public byte requiredObjectCount;
    }

    [Serializable]
    public struct LevelObjectData
    {
        public byte totalObjectCount;
    }
    
}