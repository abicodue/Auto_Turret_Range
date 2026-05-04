using UnityEngine;

public class TargetRailPivot : MonoBehaviour
{
    [SerializeField]
    private Transform targetRailPivot;
    [SerializeField]
    private Transform targetDrone;
    [SerializeField]
    private float targetYawSpeed = 60f;

    private void Init()
    {
        targetDrone.localPosition = new Vector3(8f, 8f, 8f);
    }

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        targetRailPivot.Rotate(0f, targetYawSpeed * Time.deltaTime, 0f, Space.Self);
    }
}
