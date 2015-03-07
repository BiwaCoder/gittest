using UnityEngine;
using System.Collections;

public class GenerateMagic : MonoBehaviour {
	public GameObject generatePos;
	private Vector3 clickPos;
	
	public void UseMagic(Vector3 _clickPos){
		clickPos = _clickPos;
		StartCoroutine ("Magic");
	}
	
	// コルーチン
	private IEnumerator Magic() {
		// プレハブを取得
		GameObject attackOrigin = (GameObject)Resources.Load ("SceneResouce/BattleScene/Fire_03");
		attackOrigin.GetComponent<BulletSize> ().endPosition = clickPos;




		// プレハブからインスタンスを生成
		GameObject attackIns = Instantiate (attackOrigin,new Vector3(generatePos.transform.position.x+1, generatePos.transform.position.y+1, 0), Quaternion.identity)  as GameObject;
		yield return new WaitForSeconds (3.5f);
		Destroy (attackIns);
		
	}
}
