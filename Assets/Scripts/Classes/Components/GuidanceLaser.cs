using UnityEngine;
using System;

public class GuidanceLaser : MonoBehaviour
{
    private RaycastHit target; //https://docs.unity3d.com/6000.5/Documentation/ScriptReference/Physics.Raycast.html
    public Vector3 vectorTarget {get;private set;}
    private LayerMask layerMask;
    private GameObject parentObject;
    [SerializeField] private float raycastLength = 200f;
    [SerializeField] private LineRenderer laserVisual;
    void Awake()
    {
        layerMask = LayerMask.GetMask("Floor"); //Environment layers here
        parentObject = this.gameObject; //parent weapon
    }

    void LateUpdate()
    {
        ShootLaser();
    }

    void FixedUpdate()
    {
        if(Physics.Raycast(parentObject.transform.position,parentObject.transform.forward,out target,raycastLength,layerMask)) //if hit
        {
            vectorTarget = target.point;
        }
        else //if not, just follow max laser length
        {
            vectorTarget = transform.position + (parentObject.transform.forward * raycastLength);
        }
    }

    public void ShootLaser()
    {
        laserVisual.SetPosition(0,parentObject.transform.position);
        laserVisual.SetPosition(1,vectorTarget);
    }

}
