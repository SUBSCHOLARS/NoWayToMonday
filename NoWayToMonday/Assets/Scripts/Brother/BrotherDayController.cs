using System.Collections;
using UnityEngine;

public class BrotherDayController : MonoBehaviour
{
    public GameObject BrotherNormal;
    public GameObject BrotherPhantom;
    public float phantomDuration = 0.3f;

    private bool phantomShown = false;

    public void ApplyDaySetup(int day)
    {
        phantomShown = false;
        if (BrotherPhantom != null) BrotherPhantom.SetActive(false);

        switch (day)
        {
            case 1:
            case 2:
            case 3:
            case 7:
                if (BrotherNormal != null) BrotherNormal.SetActive(true);
                break;
            case 4:
                if (BrotherNormal != null)
                {
                    BrotherNormal.SetActive(true);
                    Vector3 pos = BrotherNormal.transform.position;
                    pos.x += 15f;
                    BrotherNormal.transform.position = pos;
                }
                break;
            case 5:
            case 6:
                if (BrotherNormal != null) BrotherNormal.SetActive(false);
                break;
        }
    }

    public void ShowPhantom()
    {
        if (!phantomShown) StartCoroutine(PhantomCoroutine());
    }

    private IEnumerator PhantomCoroutine()
    {
        phantomShown = true;
        if (BrotherPhantom != null) BrotherPhantom.SetActive(true);
        yield return new WaitForSeconds(phantomDuration);
        if (BrotherPhantom != null) BrotherPhantom.SetActive(false);
    }
}
