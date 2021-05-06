using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnasackMessage : BasePanel
{

    public override void OnEnter()
    {
        this.gameObject.SetActive(true);//启动
    }

    public override void OnExit()
    {
        this.gameObject.SetActive(false);//关闭
    }
}
