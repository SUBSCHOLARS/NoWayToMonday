using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkingTestScript : MonoBehaviour
{
    [SerializeField] private float speed = 4.5f;
    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 scale = transform.localScale;
            scale.x = 1; // Flip the sprite to face right
            transform.localScale = scale;
            transform.position += new Vector3(speed, 0, 0) * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector3 scale = transform.localScale;
            scale.x = -1; // Flip the sprite to face left
            transform.localScale = scale;
            transform.position += new Vector3(-speed, 0, 0) * Time.deltaTime;
        }
    }
}
