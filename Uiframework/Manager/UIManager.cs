using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class UIManager:MonoBehaviour
{

    private static UIManager _instance;
    public static GameObject Object;
    [SerializeField]
    public static GameObject GameObject;
    public static UIManager Instance{
        get
        {
            if (_instance == null) 
            {
                
                _instance = new UIManager(); 
            }
            return _instance;
            

        }
        
    }
    private Transform canvastransrfrom;
    private Transform  CanvasTransfrom
    {
        get
        {
            if (canvastransrfrom==null)
            {
                canvastransrfrom = GameObject.Find("Canvas").transform;
            }
            return canvastransrfrom;
        }
    }


    private Dictionary<UiPaneltype, string> planePathDict;//存储所有的面板路线
    private Dictionary<UiPaneltype, BasePanel> panelDate;//保存所有实例化面板身上的basepanel

    private Stack<BasePanel> panelStack;

    /// <summary>
    /// 把某个界面入栈，把某个界面显示出来
    /// </summary>
    public void pushPanel(UiPaneltype uiPaneltype)
    { if (panelStack == null)
        {
            panelStack = new Stack<BasePanel>();
        }

        //判断一下栈里是否有页面？
        if (panelStack.Count > 0)
        {
            BasePanel Toppanel = panelStack.Peek();
            Toppanel.OnPause();
        }
        BasePanel Panel = GetPanel(uiPaneltype);//得到面板
        panelStack.Push(Panel);//把面板加载到栈
        Panel.OnEnter();//调用OnEnter方法
       
    }

    /// <summary>
    /// 把某个界面出栈，把某个界面移除
    /// </summary>
    public void popPanel()
    {//是否为空的栈
        if (panelStack == null)
        {
            panelStack = new Stack<BasePanel>();
        }
        if (panelStack.Count<0)
        {
            return;
        }
        BasePanel toppanel = panelStack.Peek();//取出栈里的panel
        toppanel.OnExit();

        if (panelStack.Count <= 0) return;
        BasePanel topPanel2 = panelStack.Peek();
        topPanel2.OnResume();

    }


    private UIManager()
    {
        ParsecJson();
    }


    /// <summary>
    /// 根据面板得到实例化的面板
    /// </summary>
    public BasePanel GetPanel(UiPaneltype panelType)
    {if(panelDate==null)//paneldate是否为空
        {
            panelDate = new Dictionary<UiPaneltype, BasePanel>();
        }
        //BasePanel basePanel;
        //panelDate.TryGetValue(panelType, out  basePanel);

        BasePanel panel = panelDate.TryGet(panelType);

        if (panel == null)
        {//如果找不到找不到，就找planePathdt
            //string path;
            //planePathDict.TryGetValue(panelType, out path);
            string path =planePathDict.TryGet(panelType);
            GameObject instantpanel = (GameObject)GameObject.Instantiate(Resources.Load(path));
            instantpanel.transform.SetParent(CanvasTransfrom, false) ;
            panelDate.Add(panelType, instantpanel.GetComponent<BasePanel>());
            return instantpanel.GetComponent<BasePanel>();

        }
        else
        {
            return  panel;
        }

    }

    [Serializable]
    class UIPanelTypeJson
    {
        public List<UIPaneInfol> Infols;
    }
    private void ParsecJson()
    {

        planePathDict = new Dictionary<UiPaneltype, string>();//定义字典
        TextAsset ts=   Resources.Load<TextAsset>("UIPanelType");
       UIPanelTypeJson JsonTypeObject= JsonUtility.FromJson<UIPanelTypeJson>(ts.text);

        foreach (UIPaneInfol info in JsonTypeObject.Infols)
        {
            //Debug.Log(info.panelType);
            planePathDict.Add(info.panelType, info.path);//增加元素
            
        }
    }

    public void Text()
    {

       
        string path;

        planePathDict.TryGetValue(UiPaneltype.knasackPanel, out path);
        Debug.Log(path);
    }
}
