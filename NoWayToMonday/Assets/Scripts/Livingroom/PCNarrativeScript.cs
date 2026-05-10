using UnityEngine;

public class PCNarrativeScript : InteractableNarrativeBase
{
    [SerializeField] private PCTypewriterEffect typewriter;
    [SerializeField] private string day7Message = "台所に行け";

    protected override void OnInteract()
    {
        if (DayCountManager.DayCount == 7)
        {
            if (typewriter != null)
                typewriter.StartTyping(day7Message);
        }
        else
        {
            base.OnInteract();
        }
    }
}
