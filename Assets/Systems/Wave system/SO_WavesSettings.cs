using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimolGames.WaveSystem
{
    [System.Serializable]
    public struct Wave{
        public float SpawnTime;
        public List<GameObject> creatures;
        public int creaturesAmount;
    }

    [CreateAssetMenu(fileName = "Waves Settings", menuName = "Wave System/Waves Settings", order = 1)]
    public class SO_WavesSettings : ScriptableObject
    {
        public List<Wave> waveList;
    }
}
