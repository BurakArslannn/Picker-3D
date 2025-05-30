using RunTime.Data.ValueObjects;
using UnityEngine;

namespace RunTime.Data.UnityObjects
{
    [CreateAssetMenu(fileName = "CD_Inventory", menuName = "Picker3D/CD_Inventory", order = 0)]
    public class CD_Inventory : ScriptableObject
    {
        public InventoryData InventoryData;
    }
}