using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyboard : IHandling
{
    //入力の受付を行う
    /*インターフェースでなく、同じコンポーネントのRacerDriveを見つけて
    そこに値を突っ込む形式*/
    public float handleDegree;

    public override void HandlingUpdate()
    {
        Accel = Input.GetKey(KeyCode.UpArrow);

        Back = Input.GetKey(KeyCode.DownArrow);

        if (Input.GetKey(KeyCode.RightArrow)) Handle = handleDegree;

        if (Input.GetKey(KeyCode.LeftArrow)) Handle = -1f * handleDegree;

        if (!Input.GetKey(KeyCode.RightArrow) && !Input.GetKey(KeyCode.LeftArrow)) Handle = 0;
    }

}
