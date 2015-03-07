using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class EffectText : MonoBehaviour {

	/// <summary>
	/// 出力先キャンバス
	/// </summary>
	public GameObject TargetCanvas;
	
	/// <summary>
	/// 表示する文字
	/// </summary>
	public string PopupString;
	
	/// <summary>
	/// ポップアップするテキストオブジェクト
	/// NumberTextScript付き
	/// </summary>
	public GameObject PopupTextObject;
	
	/// <summary>
	/// ポップアップする位置
	/// </summary>
	public Vector3 PopupPosition;
	
	/// <summary>
	/// 1文字の幅
	/// </summary>
	public float PopupTextWidth;
	
	/// <summary>
	/// ポップアップの実行
	/// </summary>
	public void Popup()
	{
		StartCoroutine (Execute());
	}
	
	/// <summary>
	/// ポップアップ実行
	/// </summary>
	private IEnumerator Execute()
	{
		var pos = this.PopupPosition;
		var texts = new List<NumberTextScript> ();

		//キャンバスにセットするためのルート
		GameObject root = new GameObject ();
		CanvasGroup canvasGroup = root.AddComponent<CanvasGroup> ();
		root.transform.SetParent (this.TargetCanvas.transform,false);

		
		foreach (var s in this.PopupString) {
			//１文字ずつ親を設定する
			GameObject obj = new GameObject ();
			obj.transform.position = pos;
			obj.transform.SetParent (root.transform,false);
			// 1文字ずつ生成
			GameObject valueText = (GameObject)Instantiate (this.PopupTextObject, pos, Quaternion.identity);

			Text textComp = valueText.GetComponent<Text> ();
			textComp.text = s.ToString ();
			valueText.transform.SetParent (obj.transform,false);
			texts.Add( valueText.GetComponent<NumberTextScript>() );
			
			// 0.03秒待つ(適当)
			yield return new WaitForSeconds (0.1f);
			
			// 次の位置
			pos.x += this.PopupTextWidth;
		}
		
		// 全部表示が終わるまでの待ち
		while (!texts.TrueForAll( t => t.IsFinish )) {
			yield return new WaitForSeconds (0.1f);
		}
		
		// フェードアウト
		for (int n=9; n>=0; n--) {
			canvasGroup.alpha = n / 10.0f;
			yield return new WaitForSeconds (0.05f);
		}
		
		// 破棄
		Destroy (root);
		Destroy (gameObject);
	}
}
