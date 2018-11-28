using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

//Apply cream is used to detect user interaction with cream objects in order to increment a value to fill up the completion bar

public class applyCream : MonoBehaviour {

    bool mouseDown = false;
    private AudioSource source;

    private void Start()
    {
        source = GetComponent<AudioSource>();
        source.time = 3f;
    }

    void OnMouseOver() //If mouse is over cream object
    {
        if (mouseDown) //If mouse is down then we increase timeDown counter (this is used to generate a value for the fill bar)
        {
            fillBar.timeDown++;
            //testTimeDownIncrease();

            if (this.name == "LeftArmCol") //At the same time we also check which exact cream object is clicked on (an generate a value for cream transparency)
            {
                creamTransparency.leftArmVal++;
                //testLeftArmVal();

            } else
            if (this.name == "LeftlegCol")
            {
                creamTransparency.leftLegVal++;
            } else
            if (this.name == "RightArmCol")
            {
                creamTransparency.rightArmVal++;
            } else
            if (this.name == "RightlegCol")
            {
                creamTransparency.rightLegVal++;
            }
            //testApplying();
        }
    }

    private void OnMouseExit() //On the mouse exiting the valid region to click in we reset the timeDown value
    {
        if ((fillBar.timeDown != 0) & (mouseDown))
        {
            fillBar.timeDown = 0;
            //testTimeDownReset();
        }
    }

    void OnMouseDown() //A boolean is set to check when the mouse is being held down
    {
        mouseDown = true;
        //testMouseDown();
        source.Play();
    }

    void OnMouseUp() //On mouse up we also reset the timeDown value to zero
    {
        if (fillBar.timeDown != 0)
        {
            fillBar.timeDown = 0;
            //testTimeDownReset();
        }
        mouseDown = false;
        source.Stop();
    }

    //Testing
    void testTimeDownIncrease()
    {
        Assert.IsTrue(fillBar.timeDown>0);
    }

    void testTimeDownReset()
    {
        Assert.IsTrue(fillBar.timeDown == 0);
    }

    void testMouseDown()
    {
        Assert.IsTrue(mouseDown);
    }

    void testLeftArmVal()
    {
        Assert.IsTrue(creamTransparency.leftArmVal>0);
    }

    void testApplying() //When mouse is over gameobject
    {
        if (mouseDown)
        {
            Assert.IsTrue(fillBar.timeDown > 0);
            Assert.IsTrue((creamTransparency.leftArmVal>0)|| (creamTransparency.leftLegVal > 0)|| (creamTransparency.rightArmVal > 0)|| (creamTransparency.rightLegVal > 0));
        }
    }

}
