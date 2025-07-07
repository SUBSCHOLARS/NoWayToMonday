using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosedBook : MonoBehaviour
{
    public GameObject CloseBook;
    public GameObject OpenBook;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.transform.gameObject.SetActive(false);
            OpenBook.SetActive(true);
        }
    }
}
