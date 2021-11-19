using UnityEngine;

public class PickupsManager : MonoBehaviour
{

    [SerializeField] private Snake snake;
    [SerializeField] private GameObject fruit;

    public void PickupCollected(GameObject pickup)
    {
        var pickupType = pickup.GetComponent<Pickup>().pickupType;
        switch(pickupType)
        {
            case PickupType.fruit:
                Debug.Log("Fruit Picked Up");
                snake.Score = 1;
                snake.AddNewSnakePart();
                SpawnPickup();
                break;
        }
        Destroy(pickup);
    }

    public void SpawnPickup()
    {
        var randomPos = new Vector3(
            Random.Range(0, MyGrid.PlayFieldSize), 
            Random.Range(0, MyGrid.PlayFieldSize), 
            -1f);
        var newPickup = Instantiate(fruit, randomPos, Quaternion.identity);
        newPickup.transform.parent = transform;
    }

    public enum PickupType
    {
        fruit
    }
}
