using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour {
    public float angle;
    public float distance;
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Horizontal") < 0)
            {
            angle += Input.GetAxis("Horizontal") * Time.deltaTime * -150;
            angle = Mathf.Clamp(angle, -35, 35);
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);


            /* Vammasta etäisyyttä
             * distance = Input.GetAxis("Horizontal") * Time.deltaTime * 5;
            transform.Translate(0f, distance, 0f);

            Vector3 clampedPosition = transform.position;

            clampedPosition.y = Mathf.Clamp(transform.position.y, -0.3f, 0.3f);
            transform.position = clampedPosition;
            */

        }
        else if(angle > 1)
        {
            angle += Time.deltaTime * -100;
            angle = Mathf.Clamp(angle, -35, 35);
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        else if (angle < -1)
        {
            angle += Time.deltaTime * 100;
            angle = Mathf.Clamp(angle, -35, 35);
            transform.localRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }


    }
}
