using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBook : MonoBehaviour
{
    public GameObject[] MonologueText;
    private int pageCount = 0;
    public GameObject MainCamera;
    public GameObject CloseBook;
    public GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        MonologueText[pageCount].SetActive(true);
        pageCount++;
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
        if (page < MonologueText.Length)
        {
            MonologueText[page - 1].SetActive(false);
            MonologueText[page].SetActive(true);
        }
        else if (page == MonologueText.Length)
        {
            MonologueText[page - 1].SetActive(false);
            CloseBook.SetActive(true);
        }
        else
        {
            pageCount = 0;
            Player.SetActive(true);
            MainCamera.transform.position = new Vector3(94.9f, -0.19f, -10f);
            CloseBook.SetActive(false);
            this.transform.gameObject.SetActive(false);
        }
    }
}
