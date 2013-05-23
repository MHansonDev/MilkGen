using System;

public class Setting
{

    public string name, reactionType, reactAttr;
    public float value, intensity;
    public bool reactBool;

    public Setting (string n, float val, float i)
    {
        name = n;
        value = val;
        intensity = i;
        reactBool = false;
        reactAttr = "Do Nothing";
        reactionType = "Do Nothing";
    }

    public string getName()
    {
        return name;
    }

    public float getValue()
    {
        return value;
    }

    public bool isReactive()
    {
        return reactBool;
    }

    public string getRType()
    {
        return reactionType;
    }

    public float getIntensity()
    {
        return intensity;
    }

    public void setReactive()
    {
        reactBool = true;
    }

    public void setNotReactive()
    {
        reactBool = false;
    }

    public string getRAttr()
    {
        return reactAttr;
    }

    public void changeVal(float v)
    {
        value = v;
    }

    public void changeRType(string rType)
    {
        reactionType = rType;
    }

    public void changeIntensity(float i)
    {
        intensity = i;
    }

    public void changeRAttr(string attribute)
    {
        reactAttr = attribute;
    }

}
