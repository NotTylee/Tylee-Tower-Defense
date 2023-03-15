using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurrent;
    public TurretBlueprint rocketTurret;
    public TurretBlueprint laserTurret;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        Debug.Log("Standard Turret Purchased");
        buildManager.SelectTurretToBuild(standardTurrent);
        
    }
    public void SelectRocketTurret()
    {
        Debug.Log("Rocket Turret Purchased");
        buildManager.SelectTurretToBuild(rocketTurret);
    }
    public void SelectlaserTurret()
    {
        Debug.Log("Laser Turret Purchased");
        buildManager.SelectTurretToBuild(laserTurret);
    }
}
