using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TskpMessage : BasePanel
{
    private CanvasGroup canvasGroup;

    private void Start()
    {
        //if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
    }

    /// <summary>
    /// 处理页面的关闭
    /// </summary>
 public override void OnEnter()
    {
        Debug.Log("1菜单不与鼠标交互");
        this.gameObject.SetActive(true);
    }
    public override void OnExit()
    {
        this.gameObject.SetActive(false);
        //if (canvasGroup == null) canvasGroup = GetComponent<CanvasGroup>();
        //    canvasGroup.alpha = 0;
        //    canvasGroup.blocksRaycasts = false;
        Debug.Log("菜单不与鼠标交互");
    }

   
    public void OnColsePanel()
    {
        UIManager.Instance.popPanel();//调用uimanage里的poppanel     
    }

}
