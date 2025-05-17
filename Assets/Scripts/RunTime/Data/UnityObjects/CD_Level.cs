using System.Collections.Generic;
using RunTime.Data.ValueObjects;
using UnityEngine;

namespace RunTime.Data.UnityObjects
{
    [CreateAssetMenu(fileName = "CD_Level", menuName = "Picker3D/CD_Level", order = 1)]
    public class CD_Level : ScriptableObject
    {
        public List<LevelData> Levels;
    }
}