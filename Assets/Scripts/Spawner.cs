using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject bullet;
    public float cooldown;

    public PhaseData[] phases;

    private int index;

    float timeStamp;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /* deve prendere la fase all'indice corrente
         * controllare che non sia superata la treshold. (se si passa alla fase successiva: index +1)
         * calcola il cooldown prendendo un numero random tra min e max della fase corrente
         * quando finisce il cooldown, istanzia l'oggetto e ricalcola il nuovo cooldown
         */

        PhaseData phase = phases[index];

        if (Time.time >= phase.TimeTreshold && index < phases.Length - 1)
        {
            //index = index + 1
            index++;
            phase = phases[index];
        }

        if (Time.time - timeStamp >= cooldown)
        {
            Instantiate(bullet, transform.position, transform.rotation);
            timeStamp = Time.time;
            cooldown = Random.Range(phase.minRange, phase.maxRange);
        }
    }
}
