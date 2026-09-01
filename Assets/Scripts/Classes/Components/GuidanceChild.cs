using UnityEngine;

public class GuidanceChild: MonoBehaviour //handles steeringw
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private AmmoData relevantData;
    [SerializeField] private GuidanceLaser guidanceLaser;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(guidanceLaser.isActiveAndEnabled)
        {
            Vector3 targetDirection = guidanceLaser.vectorTarget - transform.position;

            float angleError = Vector3.SignedAngle(transform.forward, targetDirection, Vector3.up);
            float torqueInput = Mathf.Clamp(angleError / 45f, -1f, 1f); 
            rb.AddTorque(Vector3.up * torqueInput * relevantData.TurnRate, ForceMode.Acceleration);
        }
    }
    }
