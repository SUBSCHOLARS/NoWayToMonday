using UnityEngine;

public class CameraController : MonoBehaviour
{
    private Vector3 targetPosition;
    public float smoothSpeed = 5f;
    void Start()
    {
        // 最初の目標位置を現在のカメラの位置に設定
        targetPosition = transform.position;
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }

    public void MoveTo(Vector3 newPosition)
    {
        targetPosition = newPosition;
    }
}
