using UnityEngine;
using System.Collections;
using UnityEditor;
using UnityEditor.PackageManager;
public enum ShootState
{
    NULL = -1,
    SHOOTING,
    RELOADING,
    WAITING,
    PAUSED,
    NUM_STATES,

}

public class Shooting : MonoBehaviour
{
    [SerializeField] GameObject[] bulletTemplates;
    GameObject getBulletTemplate(BulletType type)
    {
        foreach (GameObject template in bulletTemplates)
        {
            if (template.GetComponent<Bullet>().data.type == type)
                return template;
        }
        return null;
    }
    [SerializeField] public int curAmmo;
    [SerializeField] public int maxAmmo;
    [SerializeField] BulletData curBulletData;
    [SerializeField] public ShootState curState = ShootState.WAITING;
    public void setShootState(ShootState shootState) 
    {
        curState = shootState; 
        switch(curState)
        {
            case ShootState.WAITING:
                canShoot = true;
                break;
            case ShootState.SHOOTING: 
                canShoot = false; 
                break;
            case ShootState.RELOADING:
                canShoot = false;
                break;
        }
    }
    [SerializeField] bool canShoot;
    [SerializeField] public float reloadTime;
    [SerializeField] public float maxReloadTime;

    public delegate void PlayerReload(Player thePlayer);
    public static event PlayerReload playerReload;

    public delegate void PlayerStopReload(Player thePlayer);
    public static event PlayerStopReload playerStopReload;

    public delegate void PlayerShoot(Player thePlayer);
    public static event PlayerShoot playerShoot;




    public delegate void EnemyReload();
    public static event EnemyReload enemyReload;

    public delegate void EnemyStopReload();
    public static event EnemyStopReload enemyStopReload;

    public delegate void EnemyShoot();
    public static event EnemyShoot enemyShoot;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        curAmmo = curBulletData.maxAmmoAmount;
        maxAmmo = curBulletData.maxAmmoAmount;

        maxReloadTime = curBulletData.reloadSpeed;

        if (GetComponentInParent<Player>())
            playerShoot?.Invoke(GetComponentInParent<Player>());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Fire();
        }

        //Check if Reloading
        if (curState == ShootState.RELOADING)
        {
            reloadTime += Time.deltaTime;
        }
        else
            reloadTime = 0;
    }

    void CreateBullet(Vector3 spawn, BulletData data)
    {
        GameObject theBullet = GameObject.Instantiate(getBulletTemplate(data.type), spawn, Quaternion.identity);
    }

    void Fire()
    {
        if (!canShoot  || curState == ShootState.SHOOTING) //If already shooting stop
            return;
        curState = ShootState.SHOOTING;

        for (int i = 0; i < curBulletData.bulletSpawns.Length; i++)
        {
            Vector3 spawnPos = curBulletData.bulletSpawns[i] + transform.position;
            CreateBullet(spawnPos, curBulletData);
        }
        curAmmo -= curBulletData.ammoCost;
        if (curAmmo <= 0)
        {
            curAmmo = 0;
            Reload();
        }
        else
        {
			canShoot = false;
			StartCoroutine(FireWait());
        }

        if (GetComponentInParent<Player>())
            playerShoot?.Invoke(GetComponentInParent<Player>());
        else
            enemyShoot?.Invoke();
    }

    IEnumerator FireWait()
    {
        
        yield return new WaitForSeconds(curBulletData.fireRate);
        canShoot = true;
        curState = ShootState.WAITING;
    }

    void Reload()
    {
        canShoot = false;
        curState = ShootState.RELOADING;

        if (GetComponentInParent<Player>())
            playerReload?.Invoke(GetComponentInParent<Player>());
        else
            enemyReload?.Invoke();

            StartCoroutine(ReloadWait());
    }

    IEnumerator ReloadWait()
    {
        yield return new WaitForSeconds(curBulletData.reloadSpeed);
        curAmmo = curBulletData.maxAmmoAmount;
        canShoot = true;
        curState = ShootState.WAITING;

        if(GetComponentInParent<Player>())
            playerStopReload?.Invoke(GetComponentInParent<Player>());
        else
            enemyStopReload?.Invoke();
            
    }

    void SwitchGun(BulletData data)
    {

    }


}
