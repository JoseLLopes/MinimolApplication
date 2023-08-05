using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MinimolGames
{
    public class SceneController : MonoBehaviour
    {
        public void ChangeScene(string sceneName){
            SceneManager.LoadScene(sceneName);
        }
    }
}
