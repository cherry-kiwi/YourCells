// Copyright (C) 2015-2021 gamevanilla - All rights reserved.
// This code can only be used under the standard Unity Asset Store End User License Agreement.
// A Copy of the Asset Store EULA is available at http://unity3d.com/company/legal/as_terms.

using System.Text;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UltimateClean
{
    /// <summary>
    /// This component goes together with a button object and contains
    /// the audio clips to play when the player rolls over and presses it.
    /// </summary>
    [RequireComponent(typeof(AudioSource))]
    public class ButtonSounds : MonoBehaviour
    {
        public AudioClip takeSound;
        public AudioClip pressedSound;
        public AudioClip rolloverSound;

        private AudioSource audioSource;
        void Update()
        {
            //Touch

            //if (Input.touchCount > 0)
            //{
            //    Touch touch = Input.GetTouch(0);

            //    //if(OnTriggerEnter2D == Camera.main.ScreenToWorldPoint(touch.position));

            //}

            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase != TouchPhase.Began)
                    return;

                if (EventSystem.current.IsPointerOverGameObject(0))
                {
                    return;
                }
                PlayPressedSound();
            }
        }

        private void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void PlayTakeSound()
        {
            audioSource.clip = takeSound;
            audioSource.Play();
        }

        public void PlayPressedSound()
        {
            audioSource.clip = pressedSound;
            audioSource.Play();
        }

        public void PlayRolloverSound()
        {
            audioSource.clip = rolloverSound;
            audioSource.Play();
        }
    }
}