using UnityEngine;
using TMPro;
public class RunnerUI : UIGroup
{
    //ammo
    [SerializeField] TextMeshProUGUI ammo;
    [SerializeField] TextMeshProUGUI reload;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void UpdateUI(bool active, Player thePlayer)
    {
        Shooting shooter = thePlayer.shooter;
        //Ammo
        ammo.text = "A: " + shooter.curAmmo.ToString() + "/" + shooter.maxAmmo;

        //Reloading
        if (shooter.curState == ShootState.RELOADING)
            reload.text = "Reloading...";
        else
            reload.text = "";
    }
}
