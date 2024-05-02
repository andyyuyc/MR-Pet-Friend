using Crosstales.RTVoice;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpeakExample : MonoBehaviour
{
    public TMP_Text Text;

    public string VoiceName;

    public void Speak() {
        Speaker.Speak(Text.text, null, Speaker.VoiceForName(VoiceName));
    }
}
