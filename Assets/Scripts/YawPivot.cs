using UnityEngine;

public class YawPivot : MonoBehaviour
{
    [SerializeField]
    private Transform yawPivot;
    [SerializeField]
    private Transform targetDrone;

    private float yawAngle;
    [SerializeField]
    private float yawSpeed = 90f;



    private void GetYawAngle()
    {
        Vector3 yawDirection = targetDrone.position - yawPivot.position;
        yawDirection.y = 0f;

        if(yawDirection.sqrMagnitude <= 0.0001f)
        {
            return;
        }
        yawDirection.Normalize();

        yawAngle = Mathf.Atan2(yawDirection.x, yawDirection.z) * Mathf.Rad2Deg;
    }

    

    private void Update()
    {
        GetYawAngle();
        Quaternion toQuaternion = Quaternion.Euler(0f, yawAngle, 0f);
        yawPivot.rotation = Quaternion.RotateTowards(yawPivot.rotation, toQuaternion, yawSpeed*Time.deltaTime);
    }

}
