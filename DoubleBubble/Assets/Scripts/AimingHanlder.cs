using UnityEngine;

public class AimingHandler : MonoBehaviour
{
    [SerializeField] private GameObject arrowPrefab;
    [SerializeField] private Wind windPrefab;
    [SerializeField] private Transform anchor;

    private bool isPressing;
    private Vector3 localBeginLocation;
    private GameObject arrow;

    public Vector3 BeginLocation => localBeginLocation + anchor.transform.position;

    private void FixedUpdate()
    {
        Vector3 location = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        location.z = 0;
        bool mouseDown = Input.GetMouseButton(0);
        if (mouseDown && !isPressing)
        {
            Debug.Log("Pointer down");

            isPressing = true;
            localBeginLocation = location - anchor.transform.position;
            arrow = Instantiate(arrowPrefab, BeginLocation, Quaternion.identity);
        }
        else if (!mouseDown && isPressing)
        {
            Debug.Log("Pointer up");
            Destroy(arrow);
            isPressing = false;
            location.z = 0;
            var wind = Instantiate(windPrefab, (location + BeginLocation) / 2, Quaternion.LookRotation(Vector3.forward, (location - BeginLocation).normalized), anchor);
            wind.transform.localScale = new Vector3(1, Vector3.Distance(location, BeginLocation), 1);
        }

        if (!isPressing)
            return;

        arrow.transform.right = (location - BeginLocation).normalized;
        arrow.transform.position = (location + BeginLocation) / 2;
        arrow.transform.localScale = Vector3.one * Vector3.Distance(location, BeginLocation);
    }
}
