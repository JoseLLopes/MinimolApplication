using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimolGames.DamageSystem
{
    public interface IDamageable
    {
        public void TakeDamage(int amount);
    }
}
