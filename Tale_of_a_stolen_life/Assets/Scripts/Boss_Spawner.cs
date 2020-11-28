using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Spawner : MonoBehaviour
{
    public bool mojno;
    public Transform spawnPos;
    public Transform pointBound;
    public GameObject Enemy;
    private GameObject enemyAwake;
    public GameObject spawn;
    private GameObject HP;
    private void Awake()
    {
        spawnPos = GetComponent<Transform>();
        pointBound = gameObject.transform.GetChild(0).gameObject.transform;

    }
    private void Update()
    {
        if (mojno)
        {
            enemyAwake = Instantiate(Enemy, spawnPos.position, Quaternion.identity) as GameObject;
            enemyAwake.GetComponent<EnemyAI>().pointBound = pointBound;
            mojno = false;
            HP = GameObject.Find("BossHP");
            HP.GetComponent<RectTransform>().position = new Vector3(HP.GetComponent<RectTransform>().position.x, HP.GetComponent<RectTransform>().position.y, HP.GetComponent<RectTransform>().position.z + 2);
        }
    }
}

