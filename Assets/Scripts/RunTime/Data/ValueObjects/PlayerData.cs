using System;
using Unity.Mathematics;

namespace RunTime.Data.ValueObjects
{
    [Serializable]
    public struct PlayerData
    {
        public PlayerMovementData MovementData;
        public PlayerMeshData MeshData;
        public PlayerForceData ForceData;

        [Serializable]
        public struct PlayerMovementData
        {
            public float ForwardSpeed;
            public float SidewaySpeed;
        }

        [Serializable]
        public struct PlayerMeshData
        {
            public float ScaleCounter;
        }

        [Serializable]
        public struct PlayerForceData
        {
            public float3 ForceParameters;
        }
    }
}