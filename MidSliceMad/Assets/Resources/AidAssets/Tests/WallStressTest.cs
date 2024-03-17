using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CollisionScript : MonoBehaviour
{
    [SerializeField] TMP_Text speedText;

    // Components
    BicycleController BicycleController;
    float inputSpeed;

    // Awake is called when the script is being loaded
    void Awake()
    {
        BicycleController = GetComponent<BicycleController>();
        inputSpeed = 1;
        speedText.text = "Max Speed: " + BicycleController.GetMaxSpeed().ToString();        
    }

    private void FixedUpdate()
    {
        Vector3 objectPosition = transform.position;

        if (objectPosition.y < 4)
        {
            BicycleController.SetInputVector(new Vector2(0, inputSpeed));
        }
        else
        {
            BicycleController.SetInputVector(Vector2.zero);
            speedText.text = "Max Speed Breakpoint: " + BicycleController.GetMaxSpeed().ToString();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        transform.position = new Vector3(0, -4, 0);
        BicycleController.SetMaxSpeed(BicycleController.GetMaxSpeed() * 2);
        inputSpeed *= 2;

        speedText.text = "Max Speed: " + BicycleController.GetMaxSpeed().ToString();
    }
}
