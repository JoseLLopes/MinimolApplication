using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimolGames.Utils
{
    public class EffectUtils
    {
        public static Quaternion CalculateRotationByDamageDirection(Vector3 hitPosition, Vector3 attackerPosition){
            Vector3 direction = attackerPosition - hitPosition;
            direction.Normalize();
            Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
            return rotation = new Quaternion(0,rotation.y,0,rotation.w);
            
        }

    }
}
