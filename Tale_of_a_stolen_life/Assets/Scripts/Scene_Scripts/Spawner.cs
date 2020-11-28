using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public bool mojno;
    public float timeRepeat = 3f;
    public int count = 5, maxCount = 5;
    public Transform spawnPos;
    public Transform pointBound;
    public GameObject Enemy;
    private GameObject enemyAwake;
    public GameObject spawn;
    private void Awake()
    {
        spawnPos = GetComponent<Transform>();
        pointBound = gameObject.transform.GetChild(0).gameObject.transform;
        
    }
    private void Update()
    {
        if (mojno)
        {
            count = 0;
            StartCoroutine(OnSpawn());
            mojno = false;
        }
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
