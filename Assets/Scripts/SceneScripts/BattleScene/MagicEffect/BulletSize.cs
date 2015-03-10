using UnityEngine;
using System.Collections;

public class BulletSize : MonoBehaviour {
	ParticleSystem particleSystem;
	private float totalTime;
	private int stateCounter;

	public Vector3 endPosition;

	void Start () {
		particleSystem = GetComponent<ParticleSystem>();
		particleSystem.startSize = 1;
		totalTime = 0;
		particleSystem.renderer.sortingLayerName = "Particle";
		particleSystem.renderer.sortingOrder = 2;
		stateCounter = 0;
	}

	// Update is called once per frame
	void Update () {
		totalTime += Time.deltaTime;
		if (totalTime < 0.5) {
			particleSystem.startSize = 5;
		}
		else if (0.5 <= totalTime && totalTime <= 3.5) {
			float speed = 15.0f;
			float step = Time.deltaTime * speed;
			transform.position = Vector3.MoveTowards(transform.position,endPosition, step);
			//transform.Translate (10*Time.deltaTime, 0, 0,Space.World);
		}
	}

	void OnCollisionEnter2D(Collision2D  col)
	{
		Invoke ("BulletDestroy", 0.5f);
	}

	private void BulletDestroy(){
		Destroy (this.gameObject);
	}
}
