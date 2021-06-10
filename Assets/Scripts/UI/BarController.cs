using System;
using DG.Tweening;
using UnityEngine;

public class BarController : MonoBehaviour
{
    [SerializeField] private RectTransform [] zones;  // 0 - red, 1 - orange, 2 - yellow, 3 - green
    private int currentStateBar = 0;
    
    public static BarController Instance;

    private void Awake()
    {
        Instance = this;
    }

    public void Buff()
    {
        MoveBar(zones[currentStateBar], true);

        currentStateBar = currentStateBar + 1 > 3 ? 3 : ++currentStateBar;
    }

    public void DeBuff()
    {

        MoveBar(zones[currentStateBar], false);
        
        currentStateBar = currentStateBar - 1 < 0 ? 0 : --currentStateBar;
    }
    
    private void MoveBar(RectTransform zone, bool direcrtion)
    {
        if (direcrtion)
        {
            zone.DOAnchorMax(new Vector2(1f, 0.5f), 1f);
            
        }
        else
        {
            zone.DOAnchorMax(new Vector2(0f, 0.5f), 1f);
        }
    }

    private void Update()
    {
        Debug.Log(currentStateBar);
    }
}
