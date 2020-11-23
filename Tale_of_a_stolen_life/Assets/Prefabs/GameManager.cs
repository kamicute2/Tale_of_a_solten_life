using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static Transform _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public static Transform player
    {
        get { return _player; }
    }
}
