using UnityEngine;

public class PhantomTrigger : MonoBehaviour
{
    public BrotherDayController brotherDayController;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && DayCountManager.DayCount == 6)
            brotherDayController.ShowPhantom();
    }
}
