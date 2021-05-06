using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public  static  class Dictrony //对dictory的扩展
{/// <summary>
 /// 尝试根据key，得到返回的value，得到了value的话返回value，没有的话返回空
 /// this Dictionary<Tkey,Tvalue> dict 这个字典表示我们要获取值的字典
 /// </summary>
    public static Tvalue TryGet<Tkey,Tvalue>(this Dictionary<Tkey, Tvalue>dict,Tkey tkey)
    {
        Tvalue value;
        dict.TryGetValue(tkey, out value);
        return value;
    }
}
