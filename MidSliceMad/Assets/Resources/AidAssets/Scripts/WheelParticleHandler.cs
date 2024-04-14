using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class WheelParticleHandler : MonoBehaviour
{
    // Local variables
    private float particleEmissionRate = 1;

    // Components
    VehicleController vehicleController;

    ParticleSystem particleSystemSmoke;
    ParticleSystem.EmissionModule particleSystemEmissionModule;

    // Awake is called when the script instance is being loaded
    void Start()
    {
        // Get the vehicle controller
        vehicleController = GetComponentInParent<VehicleController>();

        // Get the particle system
        particleSystemSmoke = GetComponent<ParticleSystem>();

        // Get the emission component
        particleSystemEmissionModule = particleSystemSmoke.emission;

        // Set it to zero emission
        particleSystemEmissionModule.rateOverTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // Reduce the particles over time
        particleEmissionRate = Mathf.Lerp(particleEmissionRate, 0, Time.deltaTime * 5);
        particleSystemEmissionModule.rateOverTime = particleEmissionRate;

        if (vehicleController.IsTireScreeching(out float lateralVeloctity, out bool isBraking))
        {
            //If the car tires are screeching then we'll emitt smoke.  If player is braking then emitt a lot of smoke
            if (isBraking)
            {
                particleEmissionRate = 30;
            }
            // If the player is drifting we'll emitt smoke based on how much they are drifting
            else
            {
                particleEmissionRate = Mathf.Abs(lateralVeloctity) * 100;
            }
        }
    }
}
