using UnityEngine;

public class AimingHandler : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Wind windPrefab;
    [SerializeField] private Transform anchor;

    private bool isPressing;
    private Vector3 beginLocation;
    private GameObject arrow;

    private void FixedUpdate()
    {
        Vector3 location = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        location.z = 0;
        bool mouseDown = Input.GetMouseButton(0);
        if (mouseDown && !isPressing)
        {
            Debug.Log("Pointer down");

            isPressing = true;
            beginLocation = location;
            arrow = Instantiate(arrowPrefab, beginLocation, Quaternion.identity);
        }
        else if (!mouseDown && isPressing)
        {
            Debug.Log("Pointer up");
            Destroy(arrow);
            isPressing = false;
            location.z = 0;
            var wind = Instantiate(windPrefab, (location + beginLocation) / 2, Quaternion.LookRotation(Vector3.forward, (location - beginLocation).normalized), anchor);
            var distance = Vector3.Distance(location, beginLocation);
            wind.transform.localScale = new Vector3(distance / 2, distance, 1);
        }

        if (!isPressing)
            return;

        arrow.transform.right = (location - beginLocation).normalized;
        arrow.transform.position = (location + beginLocation) / 2;
        arrow.transform.localScale = Vector3.one * Vector3.Distance(location, beginLocation);
    }
}
