using Unity.VisualScripting;
using UnityEngine;

public class Commando: WeaponBase
{
    [SerializeField] private GuidanceLaser laser; //the guidance laser
    [SerializeField] private GameObject missilePrefab; //the missile prefab
    [SerializeField] private GameObject[] missiles;
    [SerializeField] private GameObject[] launchpoints; //where missiles are called to
    private int launchOrder = 0;
    

    public void Awake()
    {
        missiles = new GameObject[4];
        for(int i = 0; i <= 3; i++)
        {
            missiles[i] = Instantiate(missilePrefab,launchpoints[i].transform.position,Quaternion.identity,this.GameObject().transform);
            missiles[i].SetActive(true);
            missiles[i].GetComponent<Missile>().laser = laser; //link to laser
            Debug.Log($"creating missile #{i}");
        }
    }

    public void Reset()
    {
        for(int i = 0; i <= 3; i++)
        {
            missiles[i].SetActive(false);
            missiles[i].transform.position = launchpoints[i].transform.position;
            missiles[i].SetActive(true);
        }
    }

    public override void PrimaryFire()
    {
        if(launchOrder >= 4)
        {
            Missile fire = missiles[launchOrder].GetComponent<Missile>();
            if (fire != null)
            {
                fire.Fire();
            }
        };
    
    }

    public override void SecondaryFire()
    {
        
    }

    public override void Reload()
    {
        Reset();
    }
    
}
