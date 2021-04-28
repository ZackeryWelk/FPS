using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : MonoBehaviour
{
    public GameObject rocketLauncher;
    public GameObject rocket;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0/*need to add a fire rate*/))
        {
            Instantiate(rocket, rocketLauncher.transform.position, rocketLauncher.transform.rotation);
        }
    }


}
