using System;
using Unity.Mathematics;

namespace RunTime.Data.ValueObjects
{
    [Serializable]
    public struct InputData
    {
        public float HorizontalInputSpeed;
        public float2 ClampValues;
        public float ClampSpeed;

        public InputData(float horizontalInputSpeed, float2 clampValues, float clampSpeed)
        {
            HorizontalInputSpeed = horizontalInputSpeed;
            ClampValues = clampValues;
            ClampSpeed = clampSpeed;
        }
    }
}