using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;

namespace MinimolGames.WaveSystem
{
    public class WaveController : MonoBehaviour
    {
        [SerializeField] SO_WavesSettings wavesSettings;
        [SerializeField] List<Spawner> spawnersList;
        int currentWave = 0;
        List<GameObject> creaturesAlive = new List<GameObject>();
        public static WaveController Instance { get; private set; }

        public UnityEvent onDefeatCreature;
        public UnityEvent<int,int> onWaveChange;


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        void Start(){
            StartCoroutine(SpawnWaveCreatures());
        }

        void NextWave(){
            currentWave++;
            if(currentWave < wavesSettings.waveList.Count){
                StartCoroutine(SpawnWaveCreatures());
                onWaveChange?.Invoke(currentWave+1, wavesSettings.waveList[currentWave].creaturesAmount);
            }
            
        }

        IEnumerator SpawnWaveCreatures(){

            int creaturesAmount = wavesSettings.waveList[currentWave].creaturesAmount-1;
            float waitTime = wavesSettings.waveList[currentWave].SpawnTime;

            for(int i = 0; i <= creaturesAmount ; i++){

                yield return new WaitForSeconds(waitTime);

                GameObject creatureToSpawn = GetRandomCreature();
                creaturesAlive.Add(GetRandomSpawner().SpawnCreature(creatureToSpawn));
            }
        }

        Spawner GetRandomSpawner(){
            Spawner spawner = spawnersList[Random.Range(0,spawnersList.Count)];
            return spawner;
        }

        GameObject GetRandomCreature(){
            IList<GameObject> creatureListRef = wavesSettings.waveList[currentWave].creatures;
            int randomCreatureIndex = Random.Range(0,creatureListRef.Count);
            return creatureListRef[randomCreatureIndex];
        }

        public void DefeatCreature(GameObject creature){
            onDefeatCreature?.Invoke();
            creaturesAlive.Remove(creature);
            if(!creaturesAlive.Any()){
                NextWave();
            }
        }

    }
}
