using UnityEngine;
using UnityEngine.UI;

public class WildHealthBar : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0.0f, 1.0f, 0.0f);
    [SerializeField] Vector3 screenPosition;
    [SerializeField] Vector3 worldPosition;
    [SerializeField] float maxDistanceCanSee = 20.0f;

    [SerializeField] Camera cam;
    [SerializeField] HitLayerOfCamera hitLayerOfCamera;
    [SerializeField] Image backgroundImage;
    [SerializeField] Image fillImage;
    [SerializeField] Slider slider;

    public void Init(float _maxHealth)
    {
        cam = Camera.main;
        slider = GetComponent<Slider>();
        slider.maxValue = _maxHealth;

        Canvas mainCanvas = UIManager.instance.gameObject.GetComponent<Canvas>();
        transform.SetParent(mainCanvas.transform, worldPositionStays: false);
    }

    public void HealthBarUpDate(float currentHealth)
    {
        UpdatePosition();
        UpdateValue(currentHealth);
        HideIfOutCameraView();
    }
    void UpdatePosition()
    {
        worldPosition = target.position + offset;
        screenPosition = cam.WorldToScreenPoint(worldPosition);
        transform.position = screenPosition;
    }
    void UpdateValue(float _value)
    {
        slider.value = _value;
    }
    void HideIfOutCameraView()
    {
        CheckObstacle(worldPosition);
        if ((screenPosition.z >= 0 && screenPosition.z < maxDistanceCanSee))
        {
            if (hitLayerOfCamera == HitLayerOfCamera.Player)
            {
                gameObject.SetActive(true);
                SetAlpha(0.4f);
            }
            else if (hitLayerOfCamera == HitLayerOfCamera.Wild)
            {
                gameObject.SetActive(true);
                SetAlpha(1.0f);
            }
            transform.position = screenPosition;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
    void CheckObstacle(Vector3 targetWorldPosition)
    {
        Vector3 direction = targetWorldPosition - (cam.transform.position);
        float distance = direction.magnitude;

        Ray ray = new Ray(cam.transform.position, direction);
        if (Physics.Raycast(ray, out RaycastHit hit, distance))
        {
            if (hit.transform.gameObject.layer == 10)
            {
                hitLayerOfCamera = HitLayerOfCamera.Player;
            }
            else if (hit.transform != target)
            {
                hitLayerOfCamera = HitLayerOfCamera.Obstacal;
            }
            else
            {
                hitLayerOfCamera = HitLayerOfCamera.Wild;
            }
        }
    }
    void SetAlpha(float alpha)
    {
        SetImageAlpha(backgroundImage, alpha);
        SetImageAlpha(fillImage, alpha);
    }
    void SetImageAlpha(Image image, float alpha)
    {
        Color color = image.color;
        color.a = alpha;
        image.color = color;
    }
}
