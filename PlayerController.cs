using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 8f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //키보드입력 = 스위치플랫폼 어느상황에서도 사용
        float xInput = Input.GetAxis("Horizontal");//
        float zInput = Input.GetAxis("Vertical");

        float xSpeed = speed * xInput;
        float zSpeed = speed * zInput;

        transform.LookAt(transform.position + rb.velocity);

        rb.velocity = new Vector3(xSpeed, 0, zSpeed);
    }

    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gm = FindObjectOfType<GameManager>();
        gm.EndGame();
    }
}
