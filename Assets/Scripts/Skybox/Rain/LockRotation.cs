using UnityEngine;

public class LockRotation : MonoBehaviour
{
    private Quaternion initialRotation;

    void Start()
    {
        // Sauvegarder la rotation initiale au démarrage
        initialRotation = transform.rotation;
    }

    void LateUpdate()
    {
        // Réinitialiser la rotation à la rotation initiale à chaque frame dans LateUpdate
        transform.rotation = initialRotation;
    }
}
