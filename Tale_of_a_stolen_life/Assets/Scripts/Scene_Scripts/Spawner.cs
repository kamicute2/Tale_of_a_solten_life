using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timeRepeat = 3f;
    public int count = 0, maxCount = 5;
    public Transform spawnPos;
    public Transform pointBound;
    public GameObject Enemy;
    private GameObject enemyAwake;
    private void Awake()
    {
        spawnPos = GetComponent<Transform>();
        pointBound = gameObject.transform.GetChild(0).gameObject.transform;
        StartCoroutine(OnSpawn());
    }

    void Repeat()
    {
        if (count < maxCount)
            StartCoroutine(OnSpawn());
    }
    IEnumerator OnSpawn()
    {
        count++;
        yield return new WaitForSeconds(timeRepeat);
        enemyAwake = Instantiate(Enemy, spawnPos.position, Quaternion.identity) as GameObject;
        enemyAwake.GetComponent<EnemyAI>().pointBound = pointBound;
        Repeat();
    }
}
