using UnityEngine;

public class Commando: WeaponBase
{
    [SerializeField] private GuidanceLaser laser;

    [SerializeField] public GameObject[] magazine;
    
    public override void PrimaryFire()
    {
        //call fire command on missiles in order
    }

    public override void SecondaryFire()
    {
        
    }
    
}
