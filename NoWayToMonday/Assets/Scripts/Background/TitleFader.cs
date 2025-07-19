using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TitleFader : MonoBehaviour
{
    public Image fadeImage;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            fadeImage.gameObject.SetActive(true);
            // Exit the game when Escape is pressed
            fadeImage.DOFade(1f,2f).OnComplete(() =>
            {
                SceneManager.LoadScene("GameStage");
            });
        }
    }
}
