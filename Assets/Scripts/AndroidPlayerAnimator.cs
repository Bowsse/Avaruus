using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidPlayerAnimator : MonoBehaviour
{
    public float angle;
    public float distance;
    // Use this for initialization
   // float ROTATE_AMOUNT = 2; // at full tilt, rotate at 2 degrees per update

    float GetTiltValue()
    {
        float TILT_MIN = 0.07f;
        float TILT_MAX = 0.5f;

        // Work out magnitude of tilt
        float tilt = Mathf.Abs(Input.acceleration.x);

        // If not really tilted don't change anything
        if (tilt < TILT_MIN)
        {
            return 0;
        }
        float tiltScale = (tilt - TILT_MIN) / (TILT_MAX - TILT_MIN);

        // Change scale to be negative if accel was negative
        if (Input.acceleration.x < 0)
        {
            return -tiltScale;
        }
        else
        {
            return tiltScale;
        }

    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float tiltValue = GetTiltValue();
        if (tiltValue > 0 || tiltValue < 0)
        {
            angle += tiltValue * Time.deltaTime * -150;
            angle = Mathf.Clamp(angle, -25, 25);
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);


            /* Vammasta etäisyyttä
             * distance = Input.GetAxis("Horizontal") * Time.deltaTime * 5;
            transform.Translate(0f, distance, 0f);

            Vector3 clampedPosition = transform.position;

            clampedPosition.y = Mathf.Clamp(transform.position.y, -0.3f, 0.3f);
            transform.position = clampedPosition;
            */

        }
        else if (angle > 1)
        {
            angle += Time.deltaTime * -100;
            angle = Mathf.Clamp(angle, -25, 25);
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else if (angle < -1)
        {
            angle += Time.deltaTime * 100;
            angle = Mathf.Clamp(angle, -25, 25);
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }


    }
}
