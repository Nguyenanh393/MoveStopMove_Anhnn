using System;
using System.Collections.Generic;
using UnityEngine;

namespace _UI.Scripts.UI.SkinShopButton
{
    public class TopBarUI : MonoBehaviour
    {
        [SerializeField] private TopBarButtonUI topBarButtonPrefab;
        [SerializeField] private Transform topBarParent;
        [SerializeField] private TopBarButtonSO topBarButtonSO;

        private List<TopBarButtonUI> topBarButtonList = new List<TopBarButtonUI>();
        private void Start()
        {
            SpawnListTopBarButton();
        }

        private void SpawnListTopBarButton()
        {
            for (int i = 0; i < topBarButtonSO.DataList.Count; i++)
            {
                SpawnTopBarButton(i);
                topBarButtonList.Add(topBarButtonPrefab);
            }
        }

        private void SpawnTopBarButton(int index)
        {
            TopBarButtonUI topBarButton = Instantiate(topBarButtonPrefab, topBarParent);
            topBarButton.SetData(topBarButtonSO.DataList[index].Icon, topBarButtonSO.DataList[index].ItemType);
        }
        
    }
}