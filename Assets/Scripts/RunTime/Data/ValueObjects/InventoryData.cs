using System;

namespace RunTime.Data.ValueObjects
{
    [Serializable]
    public struct InventoryData
    {
        public int cointCount;

        public InventoryData(int cointValue)
        {
            cointCount = cointValue;
        }
    }
}