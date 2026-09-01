using UnityEngine;

public class Missile: AmmoBase
{
    [SerializeField] public GuidanceLaser laser;

    protected override void Awake()
    {
        base.Awake();
        rb.maxAngularVelocity = 5000f;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if(laser.isActiveAndEnabled)
        {
            GuidedMovement(); 
        }
    }

    private void GuidedMovement()
    {
        
        Vector3 targetDirection = laser.vectorTarget - transform.position;
        float angleError = Vector3.SignedAngle(transform.forward, targetDirection, Vector3.up);
        Vector3 turnAxis = Vector3.Cross(transform.forward, targetDirection);
        rb.AddTorque(turnAxis * ammoData.TurnRate, ForceMode.Acceleration);
        
    }

}
