using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
//using UnityEngine.Mathf;

/*
 This script is responsible for the movement of the panda across the lanes displayed in the scene.
*/
public class PandaLevel : MonoBehaviour
{
	public double dest;
	public float speed;
	public bool checkKeys;
	private int count;

	private bool upPressed, downPressed;
	//Rigidbody2D rb;
	void Start(){
		count = 0;
	}
	// Update is called once per frame
	void Update()
	{
		double posX = transform.position.y;
		if ((posX < dest)&&((dest - posX) > 0.1)) {
			double updatedPos = posX + (speed/12);
			transform.position = new Vector2(transform.position.x, (float) updatedPos);
			//TestYPosition(posX, 1);
		} 
		else if ((posX > dest)&&((posX-dest) > 0.1)) {
			double updatedPos = posX - (speed/12);
			transform.position = new Vector2(transform.position.x, (float) updatedPos);
			//TestYPosition(posX, 2);
		} 
		if ((Input.GetKey ("w")||Input.GetKey("up") )&& !upPressed) {
				upPressed = true;

				if (dest == -0.7) {
					dest = 1.6;
					//TestDestPositive (dest);
				}
				else if (dest == -2.8) {
					dest = -0.7;
					//TestDestNegative (dest);
				}
			}
		if ((Input.GetKey ("s")||Input.GetKey("down") ) && !downPressed) {
				downPressed = true;

				if (dest == 1.6) {
					dest = -0.7;
					//TestDestNegative (dest);
				}
				else if (dest == -0.7) {
					dest = -2.8;
					//TestDestNegative (dest);
				}

			}

		if (Input.GetKeyUp ("w")||Input.GetKeyUp("up")) {
			upPressed = false;
		}
		if (Input.GetKeyUp ("s")||Input.GetKeyUp("down")) {
			downPressed = false;
		}

		else {
			if (count == 3) {
				checkKeys = true;
				count = 0;
			} else {
				count++;
			}
		}
		
	}

	public void WalkUp() {
		if (dest == -0.7) {
			dest = 1.6;
			//TestDestPositive (dest);
		}
		else if (dest == -2.8) {
			dest = -0.7;
			//TestDestNegative (dest);
		}

	}

	public void WalkDown() {
		if (dest == 1.6) {
			dest = -0.7;
			//TestDestNegative (dest);
		}
		else if (dest == -0.7) {
			dest = -2.8;
			//TestDestNegative (dest);
		}

	}

	//Tests
	void TestYPosition(double posXIn, int i) { //multiplying with 1000000 to round number up to 6 decimals
		float posX;
		if (i == 1) {
			posX = (float) posXIn + (speed / 12);
			Assert.AreEqual(Mathf.Round(transform.position.y * 1000000), Mathf.Round(posX * 1000000));
		}
		else {
			posX = (float) posXIn - (speed / 12);
			Assert.AreEqual(Mathf.Round(transform.position.y * 1000000), Mathf.Round(posX * 1000000));
		}
	}
	void TestDestNegative(double destIn) {
		Assert.IsTrue (destIn < 0, "Dest should be negative, but it is not.");
	}
	void TestDestPositive(double destIn) {
		Assert.IsTrue (destIn > 0, "Dest should be positive, but it is not.");
	}
}
