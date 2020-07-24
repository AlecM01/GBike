using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gunShoot : MonoBehaviour
{

    public float projectileSpeed = 10f;

    private bool fired;

    public KeyCode fire = KeyCode.Mouse0;

    public Rigidbody player;
    public Rigidbody projectile;
    public GameObject go;

    Vector3 playerAim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(fire))
        {
            Rigidbody clone;
            clone = Instantiate(projectile, transform.position, transform.rotation);
            clone.velocity = transform.TransformDirection(Vector3.back * projectileSpeed);
            fired = true;
        }
        else
        {
            fired = false;
        }
    }
}
