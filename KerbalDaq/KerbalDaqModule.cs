using System;

using UnityEngine;

using KSP.UI.Screens;

public class KerbalDaqModule : PartModule
{
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
        this.vesselId = ((KerbalDaqModule) fromModule).vesselId;
        this.numberOfRecordedParameters = ((KerbalDaqModule) fromModule).numberOfRecordedParameters;
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

    [KSPEvent(name = "ToggleRecordingRecording", guiName = "Start Recording", requireFullControl = true, guiActive = true, active = true)]
    public void ToggleRecordingRecording()
    {
        Events["ToggleRecordingRecording"].guiName = this.isRecording ? "Stop Recording" : "Start Recording";
        this.isRecording = !this.isRecording;
    }

    [KSPField(isPersistant = false, guiName = "test", guiActiveEditor = true, guiActive = true)]
    public bool Test;

    [KSPField(isPersistant = false, guiName = "test1", guiActiveEditor = true, guiActive = true)]
    [UI_FloatRange﻿(stepIncrement = 0.5f, maxValue = 100f, minValue = 0f)]
    public float Test1 = 20;

    [KSPField(isPersistant = false, guiName = "test2", guiActiveEditor = true, guiActive = true)]
    [UI_ProgressBar(maxValue = 100f, minValue = 0f)]
    public float Test2 = 30;

    [KSPField(isPersistant = true)]
    public int numberOfRecordedParameters;

    [KSPField(isPersistant = true)]
    public float delayBetweenSamplesSeconds;

    private Guid vesselId;

    private StageIcon stagingIcon;

    private bool isRecording;
    private bool stagingRegistered;
    private bool vesselEventsRegistered;
}
