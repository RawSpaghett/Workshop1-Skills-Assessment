using UnityEngine;

public class Missile: AmmoBase
{
    private void OnEnable()
    {
        
    }
    
    private void OnDisable()
    {

    }

    public void GuidedMovement(Vector3 newTarget)
    {
        ammoData.target = newTarget;
    }

}
