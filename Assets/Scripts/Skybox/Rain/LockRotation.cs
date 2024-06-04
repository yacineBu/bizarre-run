using UnityEngine;

public class LockRotation : MonoBehaviour
{
    private Quaternion initialRotation;

    void Start()
    {
        // Sauvegarder la rotation initiale au d�marrage
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        // R�initialiser la rotation � la rotation initiale � chaque frame dans LateUpdate
        transform.rotation = initialRotation;
    }
}
