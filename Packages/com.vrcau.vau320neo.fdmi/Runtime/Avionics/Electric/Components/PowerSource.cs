using System;
using UdonSharp;
using UnityEngine;

namespace VRChatAerospaceUniversity.V320.Avionics.Electric.Components {
    public class PowerSource : UdonSharpBehaviour {
        public ElectricalAppliance consumer;

        public float voltage = 115f;
        public float power = 100f; // unit: watts

        private void Update() {
            consumer.Power(voltage, Mathf.Sqrt(power / consumer.GetResistance()));
        }
    }
}
