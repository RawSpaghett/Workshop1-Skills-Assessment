using Unity.VisualScripting;
using UnityEngine;

public class Missile: AmmoBase
{
    [SerializeField] public GuidanceLaser laser;

    protected override void Awake()
    {
        base.Awake();
        rb.maxAngularVelocity = 50f;
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if(laser.isActiveAndEnabled)
        {
            GuidedMovement(); 
        }
        if (rb.linearVelocity.sqrMagnitude > 0.1f)
        {
            rb.linearVelocity = transform.forward * rb.linearVelocity.magnitude;
        }
    }

    void OnDisable()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        isFired = false;
    }

    private void GuidedMovement()
    {
        
        Vector3 targetDirection = (laser.vectorTarget - transform.position).normalized;
        Vector3 turnAxis = Vector3.Cross(transform.forward, targetDirection);
        rb.AddTorque((turnAxis * ammoData.TurnRate) - (rb.angularVelocity * 5f), ForceMode.Acceleration);
    }

    protected override void OnCollisionEnter(Collision collision)
    {
        this.gameObject.SetActive(false); //disable
    }

}
