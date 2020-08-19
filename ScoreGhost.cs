using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreGhost : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, 3f);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            GameManager gm = FindObjectOfType<GameManager>();
            gm.score += 10f;
            Destroy(gameObject);
        }
    }
}
