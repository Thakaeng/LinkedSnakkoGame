using UnityEngine;

public class Pickup : MonoBehaviour
{
    public PickupsManager.PickupType pickupType;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("SnakeBody"))
        {
            Debug.Log("Invalid Spawn Location");
            var pm = GetComponentInParent<PickupsManager>();
            pm.PickupCollected(this.gameObject);
        }
    }
}
