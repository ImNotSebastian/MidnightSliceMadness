using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BicycleInputHandler : MonoBehaviour
{
    // Components
    BicycleController BicycleController;

    // Awake is called when the script is being loaded
    void Awake()
    {
        BicycleController = GetComponent<BicycleController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 inputVector = Vector2.zero;

        inputVector.x = Input.GetAxis("Horizontal");
        inputVector.y = Input.GetAxis("Vertical");

        BicycleController.SetInputVector(inputVector);
    }
}
