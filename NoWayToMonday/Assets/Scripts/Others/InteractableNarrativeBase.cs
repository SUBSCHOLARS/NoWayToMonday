using DG.Tweening;
using Fungus;
using UnityEngine;

public abstract class InteractableNarrativeBase : MonoBehaviour
{
    [SerializeField] protected Flowchart narrativeFlowchart;
    [SerializeField] protected string blockNamePrefix;
    [SerializeField] protected GameObject interactableIcon;

    protected bool isPlayerInRange = false;
    protected bool hasInteracted = false;
    protected SpriteRenderer iconRenderer;

    protected virtual void Start()
    {
        if (interactableIcon != null)
            iconRenderer = interactableIcon.GetComponent<SpriteRenderer>();
    }

    protected virtual void Update()
    {
        if (isPlayerInRange && !hasInteracted && Input.GetKeyDown(KeyCode.Space))
        {
            hasInteracted = true;
            OnInteract();
        }
    }

    protected virtual void OnInteract()
    {
        string block = blockNamePrefix + DayCountManager.DayCount;
        if (narrativeFlowchart != null && narrativeFlowchart.HasBlock(block))
            narrativeFlowchart.ExecuteBlock(block);
    }

    public void ResetInteraction() => hasInteracted = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        isPlayerInRange = true;
        iconRenderer?.DOFade(0.5f, 2.5f);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        isPlayerInRange = false;
        iconRenderer?.DOFade(0f, 2.5f);
    }
}
