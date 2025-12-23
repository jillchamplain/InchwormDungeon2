using UnityEngine;

public interface IShooter 
{
	float fireRate {  get; set; }
	bool canShoot {  get; set; }
	void Fire();
}
