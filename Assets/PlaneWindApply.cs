using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace MFlight.Demo
{
    public class PlaneWindApply : MonoBehaviour
    {
        [SerializeField] private Transform mouseAim;
        [SerializeField] private MouseFlightController controller;

        Vector3 direction;
        Vector3 rotation;
        float force = 10;
        float timeLeftBeforeWind;
        float timeLeftForWind;
        bool isWindCalculated;
        float ratio;

        // Start is called before the first frame update
        void Start()
        {
            ResetTimers();
        }

        // Update is called once per frame
        void Update()
        {
            timeLeftBeforeWind -= Time.deltaTime;
            if (timeLeftBeforeWind < 0)
            {
                if (!isWindCalculated)
                {
                    Debug.Log("Durée de la rafale : " + timeLeftForWind + "s");
                    CalculateDirection();
                    CalculateRotation();
                    isWindCalculated = !isWindCalculated;
                }

                if (timeLeftForWind >= 0)
                {
                    /*Vector3 mouseAimRotation = */CalculateMouseAimRotation();
                    DoRotation();
                    DoTranslation();
                    timeLeftForWind -= Time.deltaTime;
                }
                else
                {
                    ResetTimers();
                }
            }
        }

        void DoRotation()
        {
            Vector3 newRotation;
            newRotation.x = rotation.x;
            newRotation.y = 0.0f;
            newRotation.z = rotation.z;

            if (!(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)))
            {
                if(Input.GetKey(KeyCode.A))         newRotation.z /= timeLeftForWind / Time.deltaTime;
                else if(Input.GetKey(KeyCode.D))    newRotation.z /= timeLeftForWind / Time.deltaTime * (-1); 
            }
            if (!(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S)))
            {
                if (Input.GetKey(KeyCode.S))        newRotation.x /= timeLeftForWind / Time.deltaTime * (-1);
                else if (Input.GetKey(KeyCode.W))   newRotation.x /= timeLeftForWind / Time.deltaTime;
            }

            GetComponent<Transform>().Rotate(newRotation.x, newRotation.y, newRotation.z, Space.Self);
        }

        void DoTranslation()
        {
            GetComponent<Rigidbody>().AddForce(direction, (ForceMode)(force * Time.deltaTime));
        }

        void CalculateDirection()
        {
            direction.x = Random.Range(-5.0f, 5.0f);
            direction.y = Random.Range(-5.0f, 5.0f);
            direction.z = Random.Range(-5.0f, 5.0f);
            Debug.Log("Direction du vent (" + direction.x + "," + direction.y + "," + direction.z + ")");
        }

        void CalculateRatio()
        {
            ratio = timeLeftForWind / Time.deltaTime;
        }

        void CalculateRotation()
        {
            CalculateRatio();
            rotation.x = (-direction.x) * 0.66f / ratio * 27.110784524f / 2;
            rotation.y = 0.0f;
            rotation.z = (-direction.z) * 0.66f / ratio * 27.110784524f / 2;
            Debug.Log("Rotation de l'avion vent (" + rotation.x * ratio + "," + rotation.y * ratio + "," + rotation.z * ratio + ")");
        }

        //Vector3 CalculateMouseAimRotation()
        void CalculateMouseAimRotation()
        {
            // Mouse input.
            /*Vector3 mouseAimRotation;
            mouseAimRotation.x = mouseAim.rotation.x / ratio;
            mouseAimRotation.y = 0.0f;
            mouseAimRotation.z = mouseAim.rotation.z / ratio;*/
            /*rotation.x = mouseAim.rotation.x / ratio;
            rotation.y = 0.0f;
            rotation.z = mouseAim.rotation.z / ratio;*/
            //return mouseAimRotation;
        }

        void ResetTimers()
        {
            timeLeftForWind = Random.Range(1.0f, 5.0f);
            timeLeftBeforeWind = Random.Range(10.0f, 30.0f);
            isWindCalculated = false;
            Debug.Log("Nouvelle rafale dans " + timeLeftBeforeWind + "s");
        }
    }
}