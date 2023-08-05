using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MinimolGames.WaveSystem;

namespace MinimolGames.UI
{
    public class UiUpgradesActions : MonoBehaviour
    {
        [SerializeField] WaveController waveController;
        [SerializeField] GameObject upgradePanel;

        void Start(){
            waveController.onWaveChange.AddListener(ShowUpgradePanel);
        }

        void ShowUpgradePanel(){
            upgradePanel.SetActive(true);
        }

        void HideUpgradePanel(){
            upgradePanel.SetActive(false);
        }
    }
}
