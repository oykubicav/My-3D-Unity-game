using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public delegate void DoorCollisionEventHandler(bool collided);
    public static event DoorCollisionEventHandler OnDoorCollision;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("door"))
        {
            OnDoorCollision?.Invoke(true);
        }
    }

   
}
