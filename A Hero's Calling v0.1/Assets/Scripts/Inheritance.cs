using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inheritance //: MonoBehaviour
{
    protected float health = 100;
    protected float speed = 10;
    protected string st = "parent";

    public virtual void DoSomething(string bob)
    {
        Debug.Log(st + " :parent: " + bob);
    }

    protected void change(string name)
    {
        st = name;
    }
}

public class AChild : Inheritance
{
    public override void DoSomething(string bob)
    {
        Debug.Log(st + " :aaa: " + bob);
    }
}

public class BChild : Inheritance
{
    public override void DoSomething(string bob)
    {
        Debug.Log(st + " :bbb: " + bob);
    }
}