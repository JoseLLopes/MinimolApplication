using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimolGames.DamageSystem
{

    [System.Serializable]
    public class DamageData{

        public int amount;
        public Vector3 damagePoint = default;
        public Vector3 attackerPosition = default;

        public DamageData(int amount = 1, Vector3 damagePoint = default, Vector3 attackerPosition = default){
            this.amount = amount;
            this.damagePoint = damagePoint;
            this.attackerPosition = attackerPosition;
        }
    }

    public interface IDamageable
    {
        public void TakeDamage(DamageData damageData);
    }
}
