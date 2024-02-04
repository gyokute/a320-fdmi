using tech.gyoku.FDMi.aerodynamics;
using tech.gyoku.FDMi.avionics;
using tech.gyoku.FDMi.core;
using UdonSharp;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace VRChatAerospaceUniversity.V320.Avionics.Instruments.PFD {
    [UdonBehaviourSyncMode(BehaviourSyncMode.Manual)]
    public class SimplePFD : FDMiBehaviour {
        [SerializeField] private FDMiAirData airData;
        [SerializeField] private FDMiAtomosphere atmosphere;

        [SerializeField] private FDMiFloat pitch, bank;
        [SerializeField] private FDMiFloat heading;

        [SerializeField] private Animator animator;

        [SerializeField] private Text iasText, altitudeText, headingText;

        private readonly int PitchAnimationHash = Animator.StringToHash("Pitch");
        private readonly int BankAnimationHash = Animator.StringToHash("Bank");

        private void LateUpdate() {
            animator.SetFloat(PitchAnimationHash, pitch.data[0] / 180f + 0.5f);
            animator.SetFloat(BankAnimationHash, bank.data[0] / 180f + 0.5f);

            iasText.text = (airData.IAS.data[0] * 1.94384449f).ToString("F");
            altitudeText.text = (atmosphere.Altitude.data[0] * 3.2808399f).ToString("F");
            headingText.text = heading.data[0].ToString("F");
        }
    }
}