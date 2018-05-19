using UnityEngine;

using KSP.UI.Screens;

using KSPAssets;
using KSPAssets.Loaders;

namespace KerbalInstruments.KerbalDaq
{
    [KSPScenario(ScenarioCreationOptions.AddToAllGames, new GameScenes[] { GameScenes.SPACECENTER })]
    public class KerbalDataAnalysisStation : ScenarioModule
    {
        public override void OnAwake()
        {
            RegisterEvents();
        }

        public override void OnLoad(ConfigNode node)
        {
            // TODO
            Debug.Log(">>>> KerbalDataAnalysisStation::OnLoad: " + GetHashCode());
        }

        public override void OnSave(ConfigNode node)
        {
            // TODO
            Debug.Log(">>>> KerbalDataAnalysisStation::OnSave: " + GetHashCode());
        }

        public void OnDisable()
        {
            OnCloseDataScienceStation();
            UnregisterEvents();
        }

        private void RegisterEvents()
        {
            GameEvents.onGUIApplicationLauncherReady.Add(OnGUIApplicationLauncherReady);
            GameEvents.onGUIApplicationLauncherUnreadifying.Add(OnGUIApplicationLauncherUnreadifying);
        }

        private void UnregisterEvents()
        {
            GameEvents.onGUIApplicationLauncherReady.Remove(OnGUIApplicationLauncherReady);
            GameEvents.onGUIApplicationLauncherUnreadifying.Remove(OnGUIApplicationLauncherUnreadifying);
        }

        private void OnGUIApplicationLauncherReady()
        {
            if (this.applicationLauncherButton == null)
            {
                Texture2D texture = GameDatabase.Instance.GetTexture(TOOLBAR_BUTTON_TEXTURE, false);

                if (texture != null)
                {
                    this.applicationLauncherButton = A﻿pplicationLaunch﻿er.I﻿nsta﻿nce﻿﻿.AddModApplication(OnOpenDataScienceStation,
                                                                                                    OnCloseDataScienceStation,
                                                                                                    OnDummyCallback,
                                                                                                    OnDummyCallback,
                                                                                                    OnDummyCallback,
                                                                                                    OnDummyCallback,
                                                                                                    ApplicationLauncher.AppScenes.SPACECENTER,
                                                                                                    texture);
                }
                else
                {
                    Debug.LogError("Failed to load '" + TOOLBAR_BUTTON_TEXTURE + "' texture");
                }
            }
        }

        private void OnGUIApplicationLauncherUnreadifying(GameScenes data)
        {
            if (this.applicationLauncherButton != null && ApplicationLauncher.Ready)
            {
                A﻿pplicationLaunch﻿er.I﻿nsta﻿nce﻿﻿.RemoveModApplication(this.applicationLauncherButton);
                this.applicationLauncherButton = null;
            }
        }

        private void OnOpenDataScienceStation()
        {
            if (this.dataScienceStationGameObject == null)
            {
                AssetLoader.LoadAssets(AssetLoaded, new AssetDefinition[]
                {
                    AssetLoader.GetAssetDefinitionWithName(BUNDLE_NAME, OBJ_KERBAL_DATA_ITEM),
                    AssetLoader.GetAssetDefinitionWithName(BUNDLE_NAME, OBJ_KERBAL_DATA_ITEM_POOL),
                    AssetLoader.GetAssetDefinitionWithName(BUNDLE_NAME, OBJ_KERBAL_DATA_SCIENCE_STATION),
                });
            }
            else if (!this.dataScienceStationGameObject.activeSelf)
            {
                this.dataScienceStationGameObject.SetActive(true);
            }
        }

        private void AssetLoaded(AssetLoader.Loader obj)
        {
            for (int i = 0; i < obj.definitions.Length; ++i)
            {
                if (obj.definitions[i].name == OBJ_KERBAL_DATA_SCIENCE_STATION)
                {
                    Vector3 pos = this.applicationLauncherButton.GetAnchor();
                    this.dataScienceStationGameObject = Instantiate(obj.objects[i]) as GameObject;
                    this.dataScienceStationGameObject.transform.SetParent(MainCanvasUtil.MainCanvas.transform);
                    ((RectTransform)this.dataScienceStationGameObject.transform).pivot = new Vector2(1.0f, 1.0f);
                    ((RectTransform)this.dataScienceStationGameObject.transform).SetAsLastSibling();
                }
            }
        }

        private void OnCloseDataScienceStation()
        {
            if (this.dataScienceStationGameObject != null)
            {
                this.dataScienceStationGameObject.SetActive(false);
            }
        }

        private void OnDummyCallback()
        {
        }

        private GameObject dataScienceStationGameObject;
        private ApplicationLauncherButton applicationLauncherButton;

        private const string OBJ_KERBAL_DATA_ITEM = "ui_KerbalDataItem";
        private const string OBJ_KERBAL_DATA_ITEM_POOL = "ui_KerbalDataItemPool";
        private const string OBJ_KERBAL_DATA_SCIENCE_STATION = "ui_KerbalDataScienceStation";

        private const string BUNDLE_NAME = "KerbalInstruments/UI/kerbalinstruments";

        private const string TOOLBAR_BUTTON_TEXTURE = "KerbalInstruments/Textures/ToolbarButtons/data-science-station";
    }
}
