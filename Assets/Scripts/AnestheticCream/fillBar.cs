using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

//Used to fill the completion bar based on incremented values from other scripts

public class fillBar : MonoBehaviour {

    public static float timeDown = 0;
    public Image image = null;
    public Sprite[] sprites = null;
    public Image panda = null;
    public Image next = null;
    public Text text = null;
	private AudioSource source;

    void Start () {
		source = GetComponent<AudioSource>();
        image.GetComponent<Image>(); //Image used for the fill of the bar
        image.fillAmount = 0; //the fill amount value initiated as 0
    }
	
	void Update () {
        image.fillAmount = image.fillAmount + (timeDown / 20000); //Math to generate a suitable fillAmount based on time held down on mouse
        if (image.fillAmount == 1) //If the fillbar is full
        {
            panda.sprite = sprites[2]; //Normal panda face becomes happy panda face
            next.enabled = true; //enable next button so we can move to the next scene
            text.text = "Well done! Press next to move on.";
        } else
        if (image.fillAmount >= 0.5) //If the fillbar is half full
        {
			source.Play ();
            panda.sprite = sprites[1]; //Sad panda face becomes normal panda face
        }

        //testFill();
    }

    //Test
    void testFill()
    {
        if (timeDown > 0)
        {
            Assert.IsTrue(image.fillAmount>0);
        }

        if (image.fillAmount == 1)
        {
            Assert.IsTrue(panda.sprite == sprites[2]);
        } else

        if (image.fillAmount >= 0.5)
        {
            Assert.IsTrue(panda.sprite == sprites[1]);
        } else

        if (image.fillAmount < 0.5)
        {
            Assert.IsTrue(panda.sprite == sprites[0]);
        }
    }

}
