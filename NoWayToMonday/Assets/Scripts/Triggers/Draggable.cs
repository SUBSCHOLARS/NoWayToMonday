using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class Draggable : MonoBehaviour
{
    private Vector3 offset;
    private Vector3 originalPosition;
    private Camera mainCamera;
    void Awake()
    {
        mainCamera = Camera.main;
    }
    void OnMouseDown()
    {
        originalPosition = transform.position;
        offset = transform.position - GetMouseWorldPos();
    }
    void OnMouseDrag()
    {
        transform.position = GetMouseWorldPos() + offset;
    }
    void OnMouseUp()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(GetMouseWorldPos(), Vector2.zero);
        if (hit2D.collider != null)
        {
            DropZone dropZone = hit2D.collider.GetComponent<DropZone>();
            if (dropZone != null)
            {
                dropZone.OnObjectDropped(this.gameObject);
                return;
            }
            //ドロップに成功しなかった場合
            transform.position = originalPosition;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = mainCamera.WorldToScreenPoint(transform.position).z;
        return mainCamera.ScreenToWorldPoint(mousePoint);
    }
}
