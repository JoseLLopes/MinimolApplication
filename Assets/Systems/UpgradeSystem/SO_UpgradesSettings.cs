using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimolGames.UpgradeSystem
{
    [CreateAssetMenu (fileName = "UpgradeSettings", menuName = "Upgrade System/Upgrades Settings", order = 0)]
    public class SO_UpgradesSettings : ScriptableObject
    {
        public List<float> fireRateProgress;
        public List<GameObject> bulletProgress;
        public List<float> playerSpeedMultiplyerProgress;
        public List<float> dashCoolDownProgress;
    }
}
