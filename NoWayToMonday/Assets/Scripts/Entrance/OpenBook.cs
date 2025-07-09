using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class OpenBook : MonoBehaviour
{
    public GameObject[] MonologueText;
    private int pageCount = 0;
    public GameObject MainCamera;
    public GameObject CloseBook;
    public GameObject Player;
    public GameObject Navigation;
    AudioSource audioSource;
    public Flowchart ExtendedTrueEvent;
    public GameObject Sink;
    Animator animator;
    int isFirstRead = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        MonologueText[pageCount].SetActive(true);
        pageCount++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.PlayOneShot(audioSource.clip);
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
            if (page == 7)
            {
                SinkScript.isSand = true;
                animator = Sink.GetComponent<Animator>();
                animator.SetBool("IsSand", true);
            }
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
            Navigation.SetActive(false);
            MainCamera.transform.position = new Vector3(94.9f, -0.66f, -10f);
            if (isFirstRead == 0)
            {
                ExtendedTrueEvent.ExecuteBlock("AfterReadingBook");
                isFirstRead++;
            }
            CloseBook.SetActive(false);
            this.transform.gameObject.SetActive(false);
        }
    }
}
