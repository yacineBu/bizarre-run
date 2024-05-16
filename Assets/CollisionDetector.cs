using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public bool Alive = true;
    private void OnCollisionEnter(Collision collision)
    {
        // Vérifier si la collision implique un Mesh Renderer
        if (collision.collider.GetComponent<MeshRenderer>() != null)
        {
            // Faire quelque chose lorsque la collision avec un Mesh Renderer est détectée
            Debug.Log("Collision avec un Mesh Renderer détectée !");
            Alive = false;
        }
    }
}
