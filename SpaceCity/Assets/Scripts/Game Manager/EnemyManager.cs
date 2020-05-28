using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

    public static EnemyManager instance;

    [SerializeField]
    private GameObject target_Prefab, turret_Prefab;

    public Transform[] turret_SpawnPoints, target_SpawnPoints;

    [SerializeField]
    private int turret_Enemy_Count, target_Enemy_Count;

    private int initial_turret_Count, initial_target_Count;

    public float wait_Before_Spawn_Enemies_Time = 10f;

    // Use this for initialization
    void Awake () {
        MakeInstance();
	}

    void Start() {
        initial_turret_Count = turret_Enemy_Count;
        initial_target_Count = target_Enemy_Count;

        SpawnEnemies();

        StartCoroutine("CheckToSpawnEnemies");
    }

    void MakeInstance() {
        if(instance == null) {
            instance = this;
        }
    }

    void SpawnEnemies() {
        SpawnTurrets();
        SpawnTargets();
    }

    void SpawnTurrets() {

        int index = 0;

        for (int i = 0; i < turret_Enemy_Count; i++) {

            if (index >= turret_SpawnPoints.Length) {
                index = 0;
            }

            Instantiate(turret_Prefab, turret_SpawnPoints[index].position, Quaternion.identity);

            index++;

        }

        turret_Enemy_Count = 0;

    }

    void SpawnTargets() {

        int index = 0;

        for (int i = 0; i < target_Enemy_Count; i++) {

            if (index >= target_SpawnPoints.Length)
            {
                index = 0;
            }

            Instantiate(target_Prefab, target_SpawnPoints[index].position, Quaternion.identity);

            index++;

        }

        target_Enemy_Count = 0;

    }

    IEnumerator CheckToSpawnEnemies() {
        yield return new WaitForSeconds(wait_Before_Spawn_Enemies_Time);

        SpawnTurrets();

        SpawnTargets();

        StartCoroutine("CheckToSpawnEnemies");

    }

    public void EnemyDied(bool turret) {

        if(turret) {

            turret_Enemy_Count++;

            if(turret_Enemy_Count > initial_turret_Count) {
                turret_Enemy_Count = initial_turret_Count;
            }

        } else {

           target_Enemy_Count++;

            if (target_Enemy_Count > initial_target_Count) {
                target_Enemy_Count = initial_target_Count;
            }

        }

    }

    public void StopSpawning() {
        StopCoroutine("CheckToSpawnEnemies");
    }

} // class


































