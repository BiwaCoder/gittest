using UnityEngine;
using System.Collections;

public class NumberTextScript : MonoBehaviour {

	public bool IsFinish = false;
	
	public void OnAnimationFinish()
	{
		this.IsFinish = true;
	}
}
