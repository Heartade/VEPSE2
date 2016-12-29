// Copyright 2014 Google Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class DoorBehave : MonoBehaviour, IGvrGazeResponder {
    //private Vector3 startingPosition;
    public Animation anim;
    public Animator animator;
    public int openHash = Animator.StringToHash("doorOpens");
    public int closeHash = Animator.StringToHash("doorCloses");
    public bool isOpen = false;

    void Start() {
        //startingPosition = transform.localPosition;
        //target = this.transform;
        //SetGazedAt(false);
        anim = GetComponent<Animation>();
        animator = GetComponent<Animator>();
        openHash = Animator.StringToHash("doorOpens");
        closeHash = Animator.StringToHash("doorCloses");
}

    public void Open() {
        if (isOpen == false)
            isOpen = true;
        animator.SetTrigger("doorOpens");
    }

    public void Close() {
        if (isOpen == true)
            isOpen = false;
        animator.SetTrigger("doorCloses");
    }

    void Update() {
    //    if (Vector3.Distance(transform.position, target.position) > 2)
    //        target.position = Vector3.MoveTowards(target.position, transform.position, (float)0.01);
    }

    void LateUpdate() {
    //    GvrViewer.Instance.UpdateState();
    //    if (GvrViewer.Instance.BackButtonPressed) {
    //        Application.Quit();
    //    }
    }

    public void SetGazedAt(bool gazedAt) {
        /*if (gazedAt)
            Open();
        else
            Close();
        GetComponent<Renderer>().material.color = gazedAt ? Color.green : Color.red;*/
    }

    public void Reset() {
     //   transform.localPosition = startingPosition;
    }

    public void ToggleVRMode() {
        GvrViewer.Instance.VRModeEnabled = !GvrViewer.Instance.VRModeEnabled;
    }

    public void ToggleDistortionCorrection() {
        switch (GvrViewer.Instance.DistortionCorrection) {
            case GvrViewer.DistortionCorrectionMethod.Unity:
                GvrViewer.Instance.DistortionCorrection = GvrViewer.DistortionCorrectionMethod.Native;
                break;
            case GvrViewer.DistortionCorrectionMethod.Native:
                GvrViewer.Instance.DistortionCorrection = GvrViewer.DistortionCorrectionMethod.None;
                break;
            case GvrViewer.DistortionCorrectionMethod.None:
            default:
                GvrViewer.Instance.DistortionCorrection = GvrViewer.DistortionCorrectionMethod.Unity;
                break;
        }
    }

    //public void ToggleDirectRender() {
    //    GvrViewer.Controller.directRender = !GvrViewer.Controller.directRender;
    //}

    //public void TeleportRandomly() {
    //    Vector3 direction = Random.onUnitSphere;
    //    direction.y = Mathf.Clamp(direction.y, 0.5f, 1f);
    //    float distance = 4 * Random.value + 1.5f;
    //    transform.localPosition = direction * distance;
    //}

    #region IGvrGazeResponder implementation

    /// Called when the user is looking on a GameObject with this script,
    /// as long as it is set to an appropriate layer (see GvrGaze).
    public void OnGazeEnter() {
        //animator.SetTrigger(openHash);
        SetGazedAt(true);
    }

    /// Called when the user stops looking on the GameObject, after OnGazeEnter
    /// was already called.
    public void OnGazeExit() {
        //animator.SetTrigger(closeHash);
        SetGazedAt(false);
    }

    /// Called when the viewer's trigger is used, between OnGazeEnter and OnGazeExit.
    public void OnGazeTrigger() {
        if (isOpen)
            Close();
        else
            Open();
    }

    #endregion
}
