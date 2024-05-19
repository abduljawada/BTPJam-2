using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

public GameObject enemy;
public Vector2[] spawnValues;
public float spawnMinWait;
public float spawnMaxWait;



    void Start(){
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning(){
        while(true){
            yield return new WaitForSeconds(Random.RandomRange(spawnMinWait, spawnMaxWait));
            Vector2 spawnPos = spawnValues[Random.RandomRange(0,spawnValues.Length)];
            Instantiate(enemy, spawnPos, enemy.transform.rotation);
        }
    }
}
