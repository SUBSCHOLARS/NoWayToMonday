using System.Collections;
using TMPro;
using UnityEngine;

public class PCTypewriterEffect : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI targetText;
    [SerializeField] private float charInterval = 0.12f;
    [SerializeField] private AudioClip typeSound;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void StartTyping(string message)
    {
        StopAllCoroutines();
        StartCoroutine(TypeCoroutine(message));
    }

    private IEnumerator TypeCoroutine(string message)
    {
        if (targetText != null) targetText.text = "";
        foreach (char c in message)
        {
            if (targetText != null) targetText.text += c;
            if (typeSound != null && audioSource != null)
                audioSource.PlayOneShot(typeSound);
            yield return new WaitForSeconds(charInterval);
        }
    }
}
