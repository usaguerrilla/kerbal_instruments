using UnityEngine;

namespace KerbalDaqScripts
{
    public class KerbalDataItemScrollView : MonoBehaviour
    {
        public Transform ContentTransform;
        public KerbalScienceStation KerbalScienceStation;

        void Start()
        {
            GameObject newDataItem = KerbalScienceStation.GetDataItem();
            newDataItem.transform.SetParent(ContentTransform, false);
            newDataItem = KerbalScienceStation.GetDataItem();
            newDataItem.transform.SetParent(ContentTransform, false);
            newDataItem = KerbalScienceStation.GetDataItem();
            newDataItem.transform.SetParent(ContentTransform, false);
            newDataItem = KerbalScienceStation.GetDataItem();
            newDataItem.transform.SetParent(ContentTransform, false);
            newDataItem = KerbalScienceStation.GetDataItem();
            newDataItem.transform.SetParent(ContentTransform, false);
            newDataItem = KerbalScienceStation.GetDataItem();
            newDataItem.transform.SetParent(ContentTransform, false);
            newDataItem = KerbalScienceStation.GetDataItem();
            newDataItem.transform.SetParent(ContentTransform, false);
            newDataItem = KerbalScienceStation.GetDataItem();
            newDataItem.transform.SetParent(ContentTransform, false);
            newDataItem = KerbalScienceStation.GetDataItem();
            newDataItem.transform.SetParent(ContentTransform, false);
            newDataItem = KerbalScienceStation.GetDataItem();
            newDataItem.transform.SetParent(ContentTransform, false);
            newDataItem = KerbalScienceStation.GetDataItem();
            newDataItem.transform.SetParent(ContentTransform, false);
            newDataItem = KerbalScienceStation.GetDataItem();
            newDataItem.transform.SetParent(ContentTransform, false);
            newDataItem = KerbalScienceStation.GetDataItem();
            newDataItem.transform.SetParent(ContentTransform, false);
            newDataItem = KerbalScienceStation.GetDataItem();
            newDataItem.transform.SetParent(ContentTransform, false);
            newDataItem = KerbalScienceStation.GetDataItem();
            newDataItem.transform.SetParent(ContentTransform, false);
            newDataItem = KerbalScienceStation.GetDataItem();
            newDataItem.transform.SetParent(ContentTransform, false);
            newDataItem = KerbalScienceStation.GetDataItem();
            newDataItem.transform.SetParent(ContentTransform, false);
            newDataItem = KerbalScienceStation.GetDataItem();
            newDataItem.transform.SetParent(ContentTransform, false);
            Debug.Log("KPL KerbalDataItemScrollView::Start");
        }

        void OnDisable()
        {
            Debug.Log("KPL KerbalDataItemScrollView::OnDisable");
        }

        void OnEnable()
        {
            Debug.Log("KPL KerbalDataItemScrollView::OnEnable");
        }
    }
}
