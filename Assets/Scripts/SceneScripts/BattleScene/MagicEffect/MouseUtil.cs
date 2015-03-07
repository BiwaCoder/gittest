using UnityEngine;
using System.Collections;

public class MouseUtil : MonoBehaviour {

	public static Vector3 GetClick3DPosition(Vector3 ObjectPosition,float x,float y){

		//タッチした2D座標
		Vector3 screenSpace = Camera.main.WorldToScreenPoint(ObjectPosition);
		//z座標をカメラからの距離として設定
		Vector3 downPos = new Vector3(x,y, screenSpace.z);
		//カメラ座標の取得
		Vector3 mousepos2d = Camera.main.ScreenToWorldPoint(downPos);
		return mousepos2d;
	}
}
