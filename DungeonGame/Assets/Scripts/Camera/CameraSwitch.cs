using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * @Author Tobias Haubold
 * @Since 22.09.2021
 * Script für die Steuerung der Kameraperspektive und dazu gehöringen Tasten
 */
public class CameraSwitch : MonoBehaviour
{
    public Transform target;

    public float speed = 0.2f;
    public Quaternion rotation1 = Quaternion.Euler(0, 0, 0);
    public Quaternion rotation2 = Quaternion.Euler(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    /**
     * @Author Tobias
     * Steuerung der Kamera, 90 switch in die jeweilige Richtung
     */
    void Update()
    {
        //Erhaltung des Winkels zwischen 0 und 360°
        float rotation;
        if (target.eulerAngles.y <= 360f)
        {
            rotation = (float) target.eulerAngles.y;
        }
        else
        {
            rotation = (float) target.eulerAngles.y - 360;
        }

        rotation1 = Quaternion.Euler(0, rotation, 0);

        //Kamerawinkeländerung bei E und Q um 90°
        if (Input.GetKeyDown(KeyCode.E))
        {
            rotation2 = Quaternion.Euler(0, rotation - 90, 0);
            StartCoroutine(RotateOverTime(rotation1, rotation2, speed));
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            rotation2 = Quaternion.Euler(0, rotation + 90, 0);
            StartCoroutine(RotateOverTime(rotation1, rotation2, speed));
        }

        //Enumerator um Lerp zu benutzen, interpolarisiert zwischen zwei Drehungen/Winkeln
        IEnumerator RotateOverTime(Quaternion originalRotation, Quaternion finalRotation, float duration)
        {
            if (duration > 0f)
            {
                float startTime = Time.time;
                float endTime = startTime + duration;
                target.transform.rotation = originalRotation;
                yield return null;
                while (Time.time < endTime)
                {
                    float progress = (Time.time - startTime) / duration;
                    // progress will equal 0 at startTime, 1 at endTime.
                    target.transform.rotation = Quaternion.Slerp(originalRotation, finalRotation, progress);
                    yield return null;
                }
            }
            target.transform.rotation = finalRotation;
        }
    }
}
