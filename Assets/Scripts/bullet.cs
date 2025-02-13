using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float Speed = 4f;

    public GameManager gameManagerRef;

    private void Start()
    {
        gameManagerRef = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        Speed = gameManagerRef.GetLevelSpeed();
        transform.position += Speed * Vector3.left * Time.deltaTime;
    }
}
