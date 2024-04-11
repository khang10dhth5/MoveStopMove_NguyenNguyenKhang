using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : SingletonMono<UIManager>
{
    Dictionary<System.Type, UICanvas> canvasPrefabs= new Dictionary<Type, UICanvas>();
    Dictionary<System.Type, UICanvas> canvasActives = new Dictionary<Type, UICanvas>();
    [SerializeField] private Transform parent;


    private void Awake()
    {

        //load ui prefab tu resources
        UICanvas[] prefabs = Resources.LoadAll<UICanvas>("UI/");
        for(int i=0;i< prefabs.Length;i++)
        {
            canvasPrefabs.Add(prefabs[i].GetType(), prefabs[i]);
        }
    }

    private void Start()
    {
        OpenUI<CanvasMainMenu>();
    }
    //MỞ canvas
    public T OpenUI<T>() where T:UICanvas
    {
        T canvas = GetUI<T>();
        canvas.SetUp();
        canvas.Open();

        return canvas;
    }

    //đóng canvas sau time
    public void CloseUI<T> (float time) where T :UICanvas
    {
        if(IsUIOpened<T>())
        {
            canvasActives[typeof(T)].Close(time);
        }
    }

    //đóng canvas truc tiếp
    public void CloseUIDirectly<T>() where T :UICanvas
    {
        if(IsUIOpened<T>())
        {
            canvasActives[typeof(T)].CloseDirectly();
        }
    }
    //kiểm tra canvas được tạo chưa
    public bool IsUILoaded<T>() where T:UICanvas
    {
        return canvasActives.ContainsKey(typeof(T)) && canvasActives[typeof(T)] != null;
    }

    //kiểm tra canvas được active chưa
    public bool IsUIOpened<T>() where T:UICanvas
    {
        return IsUILoaded<T>() && canvasActives[typeof(T)].gameObject.activeSelf;
    }

    //lấy active canvas
    public T GetUI<T>()where T:UICanvas
    {
        if(!IsUILoaded<T>())
        {
            T prefab=GetUIPrefab<T>();
            T canvas = Instantiate(prefab, parent);
            canvasActives[typeof(T)] = canvas;
        }
        return canvasActives[typeof(T)] as T;
    }

    private T GetUIPrefab<T>() where T: UICanvas
    {
          return canvasPrefabs[typeof(T)] as T;
    }

    //đóng tất cả
    public void CloseAll()
    {
        foreach(var canvas in canvasActives)
        {
            if(canvas.Value!=null && canvas.Value.gameObject.activeSelf)
            {
                canvas.Value.Close(0);
            }
        }
    }
            
}
