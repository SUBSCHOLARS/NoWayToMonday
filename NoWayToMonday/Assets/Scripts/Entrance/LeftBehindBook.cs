using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftBehindBook : MonoBehaviour
{
    public GameObject MainCamera;
    public GameObject Navigation;
    public GameObject CloseBook;
    bool isNearBoook = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isNearBoook && Input.GetKeyDown(KeyCode.Space))
        {
            MainCamera.transform.position = new Vector3(165f, -0.2f, 0f);
            Navigation.SetActive(true);
            CloseBook.SetActive(true);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isNearBoook = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isNearBoook = false;
        }
    }
}
