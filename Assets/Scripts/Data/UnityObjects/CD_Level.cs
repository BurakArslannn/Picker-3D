using System.Collections.Generic;
using Data.ValueObjects;
using UnityEngine;

namespace Data.UnityObjects
{
    [CreateAssetMenu(fileName = "CD_Level", menuName = "Picker3D/CD_Level", order = 0)]
    public class CD_Level : ScriptableObject
    {
        public List<LevelData> Levels;
    }
}