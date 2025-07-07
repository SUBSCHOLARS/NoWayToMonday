using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBook : MonoBehaviour
{
    public GameObject[] MonologueText;
    private int pageCount = 0;
    public GameObject MainCamera;
    public GameObject CloseBook;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            NextPage(pageCount);
            pageCount++;
        }
    }
    void NextPage(int page)
    {
        if (page == 0)
        {
            MonologueText[page].SetActive(true);
        }
        else if (page < MonologueText.Length)
        {
            MonologueText[page - 1].SetActive(false);
            MonologueText[page].SetActive(true);
        }
        else if (page == MonologueText.Length)
        {
            CloseBook.SetActive(false);
        }
        else
        {
            pageCount = 0;
            MainCamera.transform.position = new Vector3(94.9f, -0.19f, -10f);
        }
    }
}
