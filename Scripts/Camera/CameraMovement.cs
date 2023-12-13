using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Camera cam;

    private Vector3 dragOrigin;

    float zoom;
    float zoomMultiplier = 15f;
    float minZoom = 10f;
    float maxZoom = 55f;
    float velocity = 0f;
    float smoothTime = 0.1f;

    [SerializeField]
    private SpriteRenderer mapRenderer;

    private float mapMinX, mapMaxX, mapMinY, mapMaxY;

    private void Awake()
    {
        mapMinX = mapRenderer.transform.position.x - mapRenderer.bounds.size.x / 2f;
        mapMaxX = mapRenderer.transform.position.x + mapRenderer.bounds.size.x / 2f;

        mapMinY = mapRenderer.transform.position.y - mapRenderer.bounds.size.y / 2f;
        mapMaxY = mapRenderer.transform.position.y + mapRenderer.bounds.size.y / 2f;
    }

    void Update()
    {
        PanCamera();
        ZoomInOut();
    }

    private void Start()
    {
        zoom = cam.orthographicSize;
    }

    private void PanCamera()
    {
        if(Input.GetMouseButtonDown(2) || Input.GetMouseButtonDown(1))  // 2�� ���콺 �� 1�� ���콺 ������ ��ư
        {
            dragOrigin = cam.ScreenToWorldPoint(Input.mousePosition);
        }

        if(Input.GetMouseButton(2) || Input.GetMouseButton(1))
        {
            Vector3 difference = dragOrigin - cam.ScreenToWorldPoint(Input.mousePosition);
             
            cam.transform.position = ClampCamera(cam.transform.position + difference);
        }
    }

    private void ZoomInOut()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        zoom -= scroll * zoomMultiplier;
        zoom = Mathf.Clamp(zoom, minZoom, maxZoom); // �־��� �� zoom�� �־��� ���� minZoom�� maxZoom���� �����ϴ� �Լ�
        cam.orthographicSize = Mathf.SmoothDamp(cam.orthographicSize, zoom, ref velocity, smoothTime);
        // Math.SmmothDamp�� ���� �ε巴�� ��ȭ��Ű�� ���� ���ȴ�. 

        cam.transform.position = ClampCamera(cam.transform.position);
    }

    private Vector3 ClampCamera(Vector3 targetPosition)
    {
        float camHeight = cam.orthographicSize;
        float camWidth = cam.orthographicSize * cam.aspect;

        float minX = mapMinX + camWidth;
        float maxX = mapMaxX - camWidth;
        float minY = mapMinY + camHeight;
        float maxY = mapMaxY - camHeight;

        float newX = Mathf.Clamp(targetPosition.x, minX, maxX);
        float newY = Mathf.Clamp(targetPosition.y, minY, maxY);

        return new Vector3(newX, newY, targetPosition.z);
    }
}
