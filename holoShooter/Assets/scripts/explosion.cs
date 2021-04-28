using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.GetComponent<ParticleSystem>().Play();
    }

    // Update is called once per frame
    void Update()
    {
        if(!this.GetComponent<ParticleSystem>().IsAlive())
        {
            Destroy(this.gameObject);
        }

    }
}
