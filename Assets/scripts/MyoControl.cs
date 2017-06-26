using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

using LockingPolicy = Thalmic.Myo.LockingPolicy;
using Pose = Thalmic.Myo.Pose;
using UnlockType = Thalmic.Myo.UnlockType;
using VibrationType = Thalmic.Myo.VibrationType;

public class MyoControl : MonoBehaviour {

	public GameObject myo = null;

	private Pose _lastPose = Pose.Unknown;

	public Tank tank;

	public float startingRotation;

	public float yaw;

	public bool start;

	private float laneSwitchAngle = 20;

	void Start () {
		start = true;
	}

	void Update () {		
		
//		if(myo == null){
//			if (Input.GetKey (KeyCode.LeftArrow)) {
//				tank.moveLeft ();
//			} else if (Input.GetKey (KeyCode.RightArrow)) {
//				tank.moveRight ();
//			} else {
//				tank.moveCenter ();
//			}
//			if (Input.GetKey (KeyCode.Space) && tank.Timer > tank.ShootingInterval) {
//				tank.shoot ();
//			}		
//		}

		if(Time.frameCount == 3){
			start = true;
		}

		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();

		if (start) {
			startingRotation = thalmicMyo.transform.rotation.eulerAngles.y;
			start = false;
		}
			
				
		if (thalmicMyo.pose != _lastPose) {
			_lastPose = thalmicMyo.pose;
	
			if (thalmicMyo.pose == Pose.FingersSpread) {
				tank.shoot ();
				ExtendUnlockAndNotifyUserAction (thalmicMyo);
			}
			else if (thalmicMyo.pose == Pose.WaveIn) {

				tank.shoot ();
				ExtendUnlockAndNotifyUserAction (thalmicMyo);

			} else if (thalmicMyo.pose == Pose.WaveOut) {					
				tank.shoot ();
				ExtendUnlockAndNotifyUserAction (thalmicMyo);
			}
		}



		if (Input.GetKey (KeyCode.A) ) {
			start = true;
		}

		yaw = thalmicMyo.transform.rotation.eulerAngles.y;

		if (yaw > startingRotation + laneSwitchAngle) {
			tank.moveRight ();
		} else if (yaw < startingRotation - laneSwitchAngle) {
			tank.moveLeft ();
		} else {
			tank.moveCenter ();
		}

	}

	void ExtendUnlockAndNotifyUserAction (ThalmicMyo myo)
	{
		ThalmicHub hub = ThalmicHub.instance;

		if (hub.lockingPolicy == LockingPolicy.Standard) {
			myo.Unlock (UnlockType.Timed);
		}

		myo.NotifyUserAction ();
	}

}