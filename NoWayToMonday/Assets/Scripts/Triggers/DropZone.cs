using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class DropZone : MonoBehaviour
{
    [Header("ドロップされた時の効果音")]
    public AudioClip dropSound;
    public static bool isThrownOnce = false;
    public GameObject BeforeThrown;
    public GameObject AfterThrown;
    public void OnObjectDropped(GameObject droppedObject)
    {
        Debug.Log(droppedObject.name + " がドロップされました");
        if (dropSound != null)
        {
            AudioSource.PlayClipAtPoint(dropSound, Camera.main.transform.position);
        }
        if (!isThrownOnce)
        {
            BeforeThrown.SetActive(false);
            AfterThrown.SetActive(true);
        }
        isThrownOnce = true;
        Destroy(droppedObject);
    }
}