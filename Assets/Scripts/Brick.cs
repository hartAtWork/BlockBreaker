using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	
	public Sprite[] hitSprites;
	public AudioClip crack;
	public static int breakableCount = 0;
	public GameObject smoke;
	private int timesHit;
	private LevelManager levelManager;
	private bool isBreakable; 
	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");
		//keep track of breakable bricks
		if(isBreakable){
			breakableCount++;
		}
		timesHit = 0;
		
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	void OnCollisionEnter2D(Collision2D collision)
	{
		//add destruction sound?
		AudioSource.PlayClipAtPoint(crack, transform.position,0.8f);
		//play sound after destroyed
		if(isBreakable){
			HandleHits();
		}
	}
	void HandleHits(){
		timesHit++;
		int maxHits = hitSprites.Length +1;
		if(timesHit >= maxHits){
			breakableCount--;
			levelManager.BrickDestroyed();
			PuffSmoke();
			Destroy(gameObject);
		}else {
			LoadSprites();
		}
	}
	void PuffSmoke(){
		GameObject smokePuff = Instantiate(smoke, transform.position, Quaternion.identity) as GameObject;
		//set color to brick
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color; 
	}
	void LoadSprites(){
		int spriteIndex = timesHit - 1;
		if(hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}else{
			Debug.LogError("Brick sprite missing");
		}
	}
}
