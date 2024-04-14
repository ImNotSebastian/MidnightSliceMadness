using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSurfaceHandler : MonoBehaviour
{
    [SerializeField] private LayerMask surfaceLayer;

    // Hit check
    Collider2D[] surfaceCollidersHit = new Collider2D[10];
    Vector3 lastSampledSurfacePosition = Vector3.one * 1000;

    // SurfaceType
    Surface.SurfaceTypes drivingOnSurface = Surface.SurfaceTypes.Grass;

    // Other components
    private Collider2D carCollider;

    private void Awake()
    {
        carCollider = GetComponent<Collider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position - lastSampledSurfacePosition).sqrMagnitude < 0.75f)
        {
            return;
        }

        ContactFilter2D contactFilter2D = new ContactFilter2D();
        contactFilter2D.layerMask = surfaceLayer;
        contactFilter2D.useLayerMask = true;
        contactFilter2D.useTriggers = true;

        int numberOfHits = Physics2D.OverlapCollider(carCollider, contactFilter2D, surfaceCollidersHit);

        float lastSurfaceZValue = -1000;

        for (int i = 0; i < numberOfHits; i++)
        {
            Surface surface = surfaceCollidersHit[i].GetComponent<Surface>();

            if (surface.transform.position.x > lastSurfaceZValue)
            {
                drivingOnSurface = surface.surfaceTypes;
                lastSurfaceZValue = surface.transform.position.x;
            }
        }

        if (numberOfHits == 0)
        {
            drivingOnSurface = Surface.SurfaceTypes.Grass;
        }

        lastSampledSurfacePosition = transform.position;

        Debug.Log($"Driving on {drivingOnSurface}");
    }   

    public Surface.SurfaceTypes GetCurrentSurface()
    {
        return drivingOnSurface;
    }
}
