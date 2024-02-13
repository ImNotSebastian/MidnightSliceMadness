using UnityEngine;

public class CreatePizza : MonoBehaviour
{
    public GameObject pizzaPrefab;
    public KeyCode createPizzaKey = KeyCode.Space;

    void Update()
    {
        if (Input.GetKeyDown(createPizzaKey))
        {
            CreatePizza();
        }
    }

    void CreatePizza()
    {
        // Instantiate the pizza prefab at the current position with no rotation
        Instantiate(pizzaPrefab, transform.position, Quaternion.identity);
    }
}
