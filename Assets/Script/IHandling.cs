using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IHandling : MonoBehaviour
{
    private bool accel;
    public bool Accel { get; set; }
    private bool back;
    public bool Back { get; set; }
    private float handle;
    public float Handle
    {
        set
        {
            if ((value > 1) || (value < -1))
            {
                handle = Mathf.Sign(handle);
            }
            else
                handle = value;
        }
        get { return handle; }
    }
    //ハンドルがfroatになってるのはアナログパッドに対応するため

    public abstract void HandlingUpdate();
}
