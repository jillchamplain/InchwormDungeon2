using Unity.Profiling;
using UnityEngine;
using UnityEngine.UI;
using DG;
using DG.Tweening;

public class WorldRunnerUI : UIGroup
{

    [SerializeField] Slider reloadSlider;
    [SerializeField] AnimationCurve reloadCurve;
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
        if (thePlayer.shooter.curState == ShootState.RELOADING)
        {

            base.UpdateUI(active);


            float maxValue = thePlayer.shooter.maxReloadTime;
            reloadSlider.maxValue = thePlayer.shooter.maxAmmo;
            reloadSlider.value = 0;
            reloadSlider.DOValue(reloadSlider.maxValue, maxValue).SetEase(reloadCurve);
        }
        else
        {
            base.UpdateUI(false);
        }
    }
}
