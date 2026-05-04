using UnityEngine;

public class PitchPivot : MonoBehaviour
{
    [SerializeField]
    private Transform pitchPivot;
    [SerializeField]
    private Transform targetDrone;
    [SerializeField]
    private float minPitch = 0f;
    [SerializeField]
    private float maxPitch = 45f;
    [SerializeField]
    private float pitchSpeed = 90f;

    private float pitchAngle;

    private void GetPitchAngle()
    {
        Vector3 pitchDirection = targetDrone.position - pitchPivot.position;

        float height = pitchDirection.y;
        Vector2 baseVector = new Vector2(pitchDirection.x, pitchDirection.z);
        float baseDistance = baseVector.magnitude;
 

        if (baseDistance <= 0.0001f)
        {
            return;
        }

        pitchAngle = Mathf.Atan2(height, baseDistance) * Mathf.Rad2Deg;

        pitchAngle = Mathf.Clamp(pitchAngle, minPitch, maxPitch);
    }

    private void RotatePitch()
    {
        Quaternion toQuaternion = Quaternion.Euler(-pitchAngle, 0f, 0f);
        pitchPivot.localRotation = Quaternion.RotateTowards(pitchPivot.localRotation, toQuaternion, pitchSpeed * Time.deltaTime);

    }

    private void Update()
    {
        GetPitchAngle();
        RotatePitch();
    }
}
