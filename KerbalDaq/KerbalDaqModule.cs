using System;

using KSP.UI.Screens;

public class KerbalDaqModule : PartModule
{
    public KerbalDaqModule()
    {
    }

    private void OnVesselRecovered(ProtoVessel vessel, bool flag)
    {
        if (this.vesselId == null || vessel == null || vessel.vesselRef == null || vessel.vesselRef.id != this.vesselId)
        {
            return;
        }
        DownloadAvailableData();
        Reset();
    }

    public override void OnCopy(PartModule fromModule)
    {
        this.vesselId = ((KerbalDaqModule)fromModule).vesselId;
        this.numberOfRecordedParameters = ((KerbalDaqModule)fromModule).numberOfRecordedParameters;
    }

    public override void OnActive()
    {
        IsRecording = true;
    }

    public void OnDisable()
    {
        Reset();
    }

    public override void OnInactive()
    {
        Reset();
    }

    public override void OnStart(StartState state)
    {
        RegisterStaging();

        if ((state & StartState.Editor) != StartState.Editor)
        {
            RegisterVesselEvents();
        }

        if (this.vessel != null && this.vesselId == Guid.Empty)
        {
            this.vesselId = this.vessel.id;
        }
    }

    public override void OnFixedUpdate()
    {
        // TODO
    }

    private void DownloadAvailableData()
    {
        // TODO
    }

    private void Reset()
    {
        UnregisterVesselEvents();
        UnregisterStaging();
    }

    private void RegisterVesselEvents()
    {
        if (!this.vesselEventsRegistered)
        {
            GameEvents.onVesselRecovered.Add(OnVesselRecovered);
            this.vesselEventsRegistered = true;
        }
    }

    private void UnregisterVesselEvents()
    {
        if (this.vesselEventsRegistered)
        {
            this.vesselEventsRegistered = false;
            GameEvents.onVesselRecovered.Remove(OnVesselRecovered);
        }
    }

    private void RegisterStaging()
    {
        if (!this.stagingRegistered)
        {
            this.part.inStageIndex = StageManager.CurrentStage;
            this.part.stackIconGrouping = StackIconGrouping.SAME_MODULE;
            this.part.stackIcon.SetIcon(DefaultIcons.SCIENCE_GENERIC);
            this.stagingIcon = StageManager.CreateIcon(this.part.stackIcon);
            StageManager.Selection.Add(this.stagingIcon);
            this.stagingRegistered = true;
        }
    }

    private void UnregisterStaging()
    {
        if (this.stagingRegistered)
        {
            this.stagingRegistered = false;
            StageManager.RemoveIcon(this.stagingIcon);
            this.stagingIcon = null;
        }
    }

    [KSPField(isPersistant = false, guiName = "Data", guiActive = false, guiActiveEditor = true)]
    [UI_ChooseOption(scene = UI_Scene.Editor, options = new string[] { "Total Mass", "Thrust", "Velocity", "Acceleration", "Staging" }, display = new string[] { "Total Mass", "Thrust", "Velocity", "Accel.", "Staging" })]
    public string DataToRecord = "Acceleration";

    [KSPField(isPersistant = false, guiName = "Recorder Status", guiActive = true, guiActiveEditor = false)]
    [UI_Toggle(scene = UI_Scene.Flight, enabledText = "Recording", disabledText = "Idle")]
    public bool IsRecording = false;

    [KSPField(isPersistant = false, guiName = "Memory Usage %", guiActive = true, guiActiveEditor = false)]
    [UI_ProgressBar(scene = UI_Scene.Flight, minValue = 0f, maxValue = 100f)]
    public float MemoryUsage = 0.0f;

    [KSPField(isPersistant = true)]
    public int numberOfRecordedParameters;

    [KSPField(isPersistant = true)]
    public float delayBetweenSamplesSeconds;

    private Guid vesselId;

    private StageIcon stagingIcon;

    private bool stagingRegistered;
    private bool vesselEventsRegistered;
}
