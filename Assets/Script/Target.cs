using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Target : MonoBehaviour
{
    public int pointvalue;
    public ParticleSystem explosion;
    private GameManger game;
    private Rigidbody targetRb;
    private int minSpeed = 12;
    private int maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawn = -2;
    // Start is called before the first frame update
    void Start()
    {
        game = GameObject.Find("GameManager").GetComponent<GameManger>();
        targetRb = GetComponent<Rigidbody>();
        targetRb.AddForce(Vector3.up * Random.Range(minSpeed, maxSpeed), ForceMode.Impulse);
        targetRb.AddTorque(Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), Random.Range(-maxTorque, maxTorque), ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-xRange, xRange), ySpawn, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Destroy(this.gameObject);
        Instantiate(explosion, transform.position, explosion.transform.rotation);
        game.UpdargeScore(pointvalue);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
        if (!gameObject.CompareTag("Bad")) {
            game.GameOver();
        }
    }
}
