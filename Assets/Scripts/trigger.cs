using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class trigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //prendi il game object che tocca e distruggilo

        GameObject collidedobject = collision.gameObject;
        Destroy(collidedobject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
