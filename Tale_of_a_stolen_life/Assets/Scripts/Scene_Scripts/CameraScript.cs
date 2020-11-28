using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public float dumping = 0.3f; // смещение
    private Transform player;
    private Transform cam;
    private GameObject[] enemies;
    public GameObject[] spawners;
    public int a, b, c;
    void Start()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        a = 480; b = 500; c = 520;

    }
    void Update()
    {
        spawners = GameObject.FindGameObjectsWithTag("Spawner");
        //mainCamera.position.y - player_info.position.y
        cam = gameObject.GetComponent<Transform>();
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        if (enemies.Length == 0)
            if (cam.position.x - player.position.x < 1.3f)
            {
            transform.position = new Vector3(cam.position.x +  0.04f , cam.position.y, cam.position.z);
            }
        if (player.position.x > a)
        {
            a = 8000000;
            for (int i = 0; i < 4; i++)
            {
                spawners[i].GetComponent<Spawner>().mojno = true;
                spawners[i].GetComponent<Spawner>().maxCount = 1;
            }
        }
        if (player.position.x > b)
        {
            b = 1000000;
            for (int i = 0; i <= 3; i++)
            {
                spawners[i].GetComponent<Spawner>().mojno = true;
                    spawners[i].GetComponent<Spawner>().maxCount = 2;
            }
        }
        if (player.position.x > c)
        {
            c = 50000;
            GameObject.Find("Boss_Spawn").GetComponent<Boss_Spawner>().mojno = true;
            
        }
    }
    private void FixedUpdate()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0)
            if (cam.position.x - player.position.x < 1.3f)
            {
                transform.position = new Vector3(cam.position.x + 0.03f, cam.position.y, cam.position.z);
            }
    }
}
