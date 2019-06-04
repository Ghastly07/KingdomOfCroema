using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Immortal : MonoBehaviour
{
    public Transform startPosition;

    void Awake()
    {
        //transform.position = startPosition.position;
        DontDestroyOnLoad(gameObject);
    }
}
