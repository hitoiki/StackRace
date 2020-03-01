using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacerDrive : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;

    public IHandling Handling;
    public RacerState racerState;

    Vector3 targetToLerp;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        if (Handling == null)
        {
            Handling = this.GetComponent<IHandling>();
        }
        if (racerState == null)
        {
            racerState = this.GetComponent<RacerState>();
        }

    }
    void FixedUpdate()
    {
        Handling.HandlingUpdate();
        //ハンドルで車体の向き、移動速度の向きを制御
        Debug.Log(Handling.Handle);
        if (Handling.Handle != 0) rb.rotation *= Quaternion.AngleAxis(Handling.Handle * Time.deltaTime * 90, Vector3.up);

        //車体の水平方向の向き
        targetToLerp.Set(this.transform.forward.x, 0, this.transform.forward.z);

        //アクセル、ブレーキの処理
        if (Handling.Accel)
        {
            rb.AddForce(targetToLerp * racerState.acceleration);
        }
        if (Handling.Back)
        {
            rb.AddForce(targetToLerp * racerState.acceleration * -1f);
        }

        //機体の向きに速度を曲げる
        //Leapを使うので重力方向を併せておくのと、Backの時は曲がる方向を逆にする
        if (Handling.Handle != 0)
        {
            //進行方向と向いてる方向の内積取ってその符号をかける
            targetToLerp *= Mathf.Sign(Vector3.Dot(targetToLerp, rb.velocity));
            rb.velocity = Vector3.Lerp(rb.velocity, targetToLerp * rb.velocity.magnitude + Vector3.up * rb.velocity.y, racerState.starling * Time.deltaTime);
            //これ以降もtargetToLeapを使うなら戻す処理を書く
            //targetToLerp *= Mathf.Sign(Vector3.Dot(targetToLerp,rb.velocity));
        }
        //スピードキャップの処理
        if (rb.velocity.magnitude > racerState.maxspeed)
        {
            rb.velocity = rb.velocity.normalized * racerState.maxspeed;
        }

    }
    void Update()
    {
        Handling.HandlingUpdate();
    }

}
