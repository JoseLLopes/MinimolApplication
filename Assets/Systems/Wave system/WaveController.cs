using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.Events;
using MinimolGames.Audio;

namespace MinimolGames.WaveSystem
{
    public class WaveController : MonoBehaviour
    {
        [SerializeField] SO_WavesSettings wavesSettings;
        [SerializeField] List<Spawner> spawnersList;
        int currentWave = 0;
        List<GameObject> creaturesAlive = new List<GameObject>();
        public static WaveController Instance { get; private set; }

        [HideInInspector] public UnityEvent onDefeatCreature;
        [HideInInspector] public UnityEvent<int,int> onWaveChange;
        [HideInInspector] public UnityEvent onFinishAllWaves;

        [Header ("Sound")]
        [SerializeField] AudioClip finishWaveSound;
        [SerializeField] AudioClip finishGameSound;


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
            SoundManager.Instance.Play(finishWaveSound);
            currentWave++;

            //Check if has more waves
            if(currentWave < wavesSettings.waveList.Count){
                StartCoroutine(SpawnWaveCreatures());
                onWaveChange?.Invoke(currentWave+1, wavesSettings.waveList[currentWave].creaturesAmount);
            }else{
                onFinishAllWaves?.Invoke();
                SoundManager.Instance.Play(finishGameSound);
            }
            
        }

        //Spawn all wave's creatures
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
            if(!creaturesAlive.Any()) //if no more creatures alive
            {
                NextWave();
            }
        }

    }
}
