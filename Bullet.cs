using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed; //forward = z축 플러스
        Destroy(gameObject, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerController pc = other.GetComponent<PlayerController>();
            if(pc != null)//컨퍼넌트가 정상적으로 들어왓는지 
            {
                pc.Die();
            }
        }
    }
}
