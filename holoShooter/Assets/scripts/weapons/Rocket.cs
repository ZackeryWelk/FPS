using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject rocket;
    public ParticleSystem explosion;
    public float projectileSpeed;

    public int damage;
    // Start is called before the first frame update
    void Start()
    {
        rocket.GetComponent<Rigidbody>().AddForce(this.gameObject.transform.forward * projectileSpeed);
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnCollisionEnter(Collision collision)
    {
        this.gameObject.GetComponent<SphereCollider>().enabled = true;
        Instantiate(explosion,rocket.transform.position,rocket.transform.rotation);
        Destroy(this.gameObject);
    }
}
