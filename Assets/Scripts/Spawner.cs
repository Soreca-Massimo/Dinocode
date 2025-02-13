using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Spawner : MonoBehaviour
{
    public GameObject bullets;
    public float baseCooldown = 4f;
    public float cooldown = 1f;

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
            //istanzia nuovo ostacolo
            Instantiate(bullets, transform.position, transform.rotation);
            timeStamp = Time.time;

            //genera un nuovo cooldown seguendo le procedure coi dati della fase corrente
            PickCooldown();
        }
    }

    void PickCooldown()
    {
        /*ancia un dado percentuale
         * in base al risyltato percentuale, prendi il moltiplicatore corrispondente
         * Moltiplica il valore base di cooldown a questo moltiplicatore per ottenere il nuovo cooldown
         */

        float dieRoll = Random.Range(0f, 1f);
        float probabilityTreshold = 0f;

        PhaseData phase = phases[index];

        for (int i = 0; i < phase.probabilities.Length; i++)
        {
            if (dieRoll <= phase.probabilities[i] + probabilityTreshold)
            {
                cooldown = baseCooldown * phase.multipliers[i];
                break;
            }
            else
            {
                probabilityTreshold += phase.probabilities[i];
            }
        }

        int intDieRoll = Random.Range(0, phase.bullets.Length);

        for (int i = 0; i < phase.bullets.Length; i++)
        {
            if (intDieRoll <= i)
            {
                bullets = phase.bullets[i];
                break;
            }
        }
    }
}
