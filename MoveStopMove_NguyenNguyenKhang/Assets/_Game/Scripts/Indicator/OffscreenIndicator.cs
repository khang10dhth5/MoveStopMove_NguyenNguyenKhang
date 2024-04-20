using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffscreenIndicator : MonoBehaviour
{
    [SerializeField] private Indicator inprefabs;
    [SerializeField] private Camera camera;

    public static List<IndicatorItem>  targetIndicators=new List<IndicatorItem>();
    public static Indicator indicatorPrefab;

    private static Transform TF;

    private void Start()
    {
        TF = transform;
        camera = Camera.main;
        indicatorPrefab = inprefabs;
       
    }
    private void OnEnable()
    {
        StartCoroutine(UpdateIndicators());
    }


    public static void DestroyIndicator()
    {
        for(int i=0;i<targetIndicators.Count;i++)
        {
            Destroy(targetIndicators[i].indicatorUI.gameObject);
        }
        targetIndicators.Clear();
    }
    public static void InstantiateIndicators()
    {
        targetIndicators = new List<IndicatorItem>();
        for (int i = 0; i < LevelManager.Instance.listCharacter.Count; i++)
        {
            targetIndicators.Add(new IndicatorItem()
            {
                target = LevelManager.Instance.listCharacter[i]
            });
        }
        foreach (IndicatorItem targetIndicator in targetIndicators)
        {
            if(targetIndicator.indicatorUI==null)
            {
                targetIndicator.indicatorUI = Instantiate(indicatorPrefab,TF);
            }
            RectTransform rectTransform = targetIndicator.indicatorUI.GetComponent<RectTransform>();
            if(rectTransform==null)
            {
                rectTransform = targetIndicator.indicatorUI.gameObject.AddComponent<RectTransform>();
            }
            targetIndicator.rectTransform = rectTransform;
        }
    }
    private void UpdatePostision(IndicatorItem indicatorItem)
    {
        Rect rect = indicatorItem.rectTransform.rect;
        Vector3 target = camera.WorldToScreenPoint(indicatorItem.target.TF.position);
        if ((target.x < 0 || target.x > Screen.width || target.y < 0 || target.y > Screen.height)&&indicatorItem.target.isDead==false)
        {

            //Show the current indicator
            indicatorItem.indicatorUI.SetState(true);


            Vector3 direction = target - new Vector3(Screen.width / 2, Screen.height / 2, 0);
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            //position
            Vector3 posIndicator = new Vector3();
            if(target.x>0)
            {
                posIndicator.x = (rect.width/2)-2;
            }
            else
            {
                posIndicator.x = (-rect.width/2)+2;
            }
            posIndicator.y = Mathf.Sin(angle) * rect.height / 2;
            posIndicator.z = indicatorItem.indicatorUI.TF.position.z;
            indicatorItem.indicatorUI.TF.position = posIndicator;

            
           //rotation
            Vector3 rotIndicator = indicatorItem.indicatorUI.TF.rotation.eulerAngles;
            rotIndicator.z = angle - 90; // Subtract 90 because the sprite is oriented upwards
            indicatorItem.indicatorUI.TF.rotation = Quaternion.Euler(rotIndicator);

        }
        else
        {

            //Hide the current indicator
            indicatorItem.indicatorUI.SetState(false);
        }

    }

    private IEnumerator UpdateIndicators()
    {
        while(true)
        {
            foreach(IndicatorItem indicatorItem in targetIndicators)
            {
                UpdatePostision(indicatorItem);
            }
            yield return new WaitForSeconds(0.3f);
        }
    }


}

[System.Serializable]
public class IndicatorItem
{
    public Character target;
    public Indicator indicatorUI;
    [HideInInspector] public RectTransform rectTransform;
}