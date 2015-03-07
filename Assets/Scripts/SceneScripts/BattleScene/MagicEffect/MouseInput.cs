using UnityEngine;
using System.Collections;

public class MouseInput : MonoBehaviour {
	private GenerateMagic magicEffect;
	// Use this for initialization
	void Start () {
		magicEffect = this.GetComponent<GenerateMagic> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			Vector3 mousepos3d = MouseUtil.GetClick3DPosition(transform.position,Input.mousePosition.x,Input.mousePosition.y);
			GameObject icon = (GameObject)Resources.Load ("SceneResouce/BattleScene/ken");
			Instantiate (icon,mousepos3d, Quaternion.identity);
			magicEffect.UseMagic(mousepos3d);
		}
	
	}
}
