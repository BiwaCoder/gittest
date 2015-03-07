using UnityEngine;
using System.Collections;

public class HitCheck : MonoBehaviour {
	/// <summary>
	/// 出力先キャンバス
	/// </summary>
	public GameObject TargetCanvas;
			
	void OnCollisionEnter2D(Collision2D  col)
	{
		var temp = new GameObject();
		EffectText gen = temp.AddComponent<EffectText>();
		gen.name = "DamageEffectGenerator";
		//表示する数値
		gen.PopupString = ((int)(Random.value * 10000.0f)).ToString();
		//表示する場所
		gen.PopupPosition = this.transform.position;
		gen.PopupTextWidth = 15.0f;
		//表示対象のキャンバス
		gen.TargetCanvas = this.TargetCanvas;
		GameObject DamageText = (GameObject)Resources.Load ("SceneResouce/BattleScene/DamageText");
		DamageText.name = "aaa";
		//表示するためのテキスト
		gen.PopupTextObject = DamageText;
		//表示指示
		gen.Popup ();

	
	}
}


