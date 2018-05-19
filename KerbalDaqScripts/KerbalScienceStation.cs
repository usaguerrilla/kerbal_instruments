using UnityEngine;

namespace KerbalDaqScripts
{
    public class KerbalScienceStation : MonoBehaviour
    {
        public GameObject KerbalDataItemPrefab;
        public GameObject KerbalScienceStationPrefab;

        void Start()
        {
            Debug.Log("KPL KerbalScienceStation::Start");
        }

        internal GameObject GetDataItem()
        {
            return Instantiate(KerbalDataItemPrefab) as GameObject;
        }

        void OnDisable()
        {
            Debug.Log("KPL KerbalScienceStation::OnDisable");
        }

        void OnEnable()
        {
            Debug.Log("KPL KerbalScienceStation::OnEnable");
        }

        public void Show(Transform transform)
        {
            if (this.kerbalScienceStation == null)
            {
                this.kerbalScienceStation = Instantiate(KerbalScienceStationPrefab) as GameObject;
            }
            this.kerbalScienceStation.transform.SetParent(transform);
            ((RectTransform) this.kerbalScienceStation.transform).pivot = new Vector2(1.0f, 1.0f);
            ((RectTransform) this.kerbalScienceStation.transform).SetAsLastSibling();
            this.gameObject.SetActive(true);
            this.kerbalScienceStation.SetActive(true);
        }

        public void Hide()
        {
            this.kerbalScienceStation.SetActive(false);
            this.gameObject.SetActive(false);
        }

        private GameObject kerbalScienceStation;
    }
}
