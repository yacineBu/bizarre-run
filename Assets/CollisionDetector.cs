using UnityEngine;

public class CollisionDetector : MonoBehaviour
{
    public bool Alive = true;
    private void OnCollisionEnter(Collision collision)
    {
        // V�rifier si la collision implique un Mesh Renderer
        if (collision.collider.GetComponent<MeshRenderer>() != null)
        {
            // Faire quelque chose lorsque la collision avec un Mesh Renderer est d�tect�e
            Debug.Log("Collision avec un Mesh Renderer d�tect�e !");
            Alive = false;
        }
    }
}
