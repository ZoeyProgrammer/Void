using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveability : MonoBehaviour
{
    public List<Transform> keyframes = new List<Transform>();
    public float speed = 10;

    public int currentKeyframe = 0;
    private Transform currentTarget;
    private float distance;
    private float degrees;

    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (transform.position == keyframes[currentKeyframe].position)
        {
            if (currentKeyframe < keyframes.Count - 1)
                currentKeyframe++;
            else
                currentKeyframe = 0;

            currentTarget = keyframes[currentKeyframe];
            distance = Vector3.Distance(transform.position, currentTarget.position);

            float myDegree = transform.rotation.eulerAngles.z;
            float targetDegree = currentTarget.rotation.eulerAngles.z;

            if (myDegree > 180)
                myDegree -= 180;
            else if (myDegree < -180)
                myDegree += 180;

            if (targetDegree > 180)
                targetDegree -= 180;
            else if (targetDegree < -180)
                targetDegree += 180;

            degrees = myDegree - targetDegree;
            Debug.Log(myDegree + "-" + targetDegree + " = " + degrees);
        }
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, Time.deltaTime * speed);

        float rotationSpeed = degrees / (distance / speed);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, currentTarget.rotation, Time.deltaTime * Mathf.Abs(rotationSpeed));
    }
}
