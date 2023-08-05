using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MinimolGames.Ai
{
    public abstract class AiState : MonoBehaviour
    {
        public abstract AiState RunCurrentState();
    }
}
