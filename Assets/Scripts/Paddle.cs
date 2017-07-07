﻿using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	
	public bool autoPlay = false;
	private Ball ball;
	// Use this for initialization
	void Start () {
		ball = GameObject.FindObjectOfType<Ball>();
	}
	
	// Update is called once per frame
	void Update () {
		if(!autoPlay){
			MoveWithMouse();
		}else{
			AutoPlay();
		}
	}
	void AutoPlay(){
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp(ballPos.x, 2.0f, 14.0f);
		this.transform.position = paddlePos;
	}
	void MoveWithMouse(){
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		float mousePosInBlocks = Input.mousePosition.x /Screen.width * 16; //16 for world unit
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, 2.0f, 14.0f);
		this.transform.position = paddlePos;
	}
}
