using UnityEngine;

public class Commando: WeaponBase
{
    [SerializeField] private GuidanceLaser laser;
    [SerializeField] private GameObject missilePrefab;
    [SerializeField] private Transform launchpoint;
    
    public override void PrimaryFire()
    {
        //call fire command on missiles in order
    }

    public override void SecondaryFire()
    {
        
    }
    
}
