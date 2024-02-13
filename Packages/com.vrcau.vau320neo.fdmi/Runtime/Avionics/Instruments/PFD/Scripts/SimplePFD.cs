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

        [SerializeField] private FDMiFloat verticalSpeed;

        [SerializeField] private Animator animator;

        [SerializeField] private Text iasText, altitudeText, headingText;

        private readonly int PitchAnimationHash = Animator.StringToHash("Pitch");
        private readonly int BankAnimationHash = Animator.StringToHash("Bank");
        private readonly int IASAnimationHash = Animator.StringToHash("IAS");
        private readonly int HeadingAnimationHash = Animator.StringToHash("Heading");
        private readonly int VerticalSpeedAnimationHash = Animator.StringToHash("VerticalSpeed");

        private readonly int FlightLevelAltitude1stAnimationHash = Animator
            .StringToHash("FlightLevelAltitude1st");

        private readonly int FlightLevelAltitude2ndAnimationHash = Animator
            .StringToHash("FlightLevelAltitude2nd");

        private readonly int FlightLevelAltitude3rdAnimationHash = Animator
            .StringToHash("FlightLevelAltitude3rd");

        private readonly int SecondAltitudeAnimationHash = Animator.StringToHash("SecondAltitude");

        private void LateUpdate() {
            animator.SetFloat(PitchAnimationHash, pitch.data[0] / 180f + 0.5f);
            animator.SetFloat(BankAnimationHash, bank.data[0] / 180f + 0.5f);
            animator.SetFloat(IASAnimationHash, airData.IAS.data[0] / 660f);
            animator.SetFloat(HeadingAnimationHash, heading.data[0] / 360f);
            animator.SetFloat(VerticalSpeedAnimationHash,
                Mathf.Clamp01(verticalSpeed.data[0] * 196.85f / 6000f + 0.5f));

            var altitude = atmosphere.Altitude.data[0] * 3.2808399f;

            animator.SetFloat(FlightLevelAltitude1stAnimationHash,
                altitude / 10000f % 10f / 10f);
            animator.SetFloat(FlightLevelAltitude2ndAnimationHash,
                altitude / 1000f % 10f / 10f);
            animator.SetFloat(FlightLevelAltitude3rdAnimationHash,
                altitude / 100f % 10f / 10f);

            animator.SetFloat(SecondAltitudeAnimationHash, altitude % 100f / 100f);

            // iasText.text = (airData.IAS.data[0] * 1.94384449f).ToString("F");
            altitudeText.text = altitude.ToString("F");
        }
    }
}