using JetBrains.Annotations;
using UdonSharp;
using UnityEngine;

namespace VRChatAerospaceUniversity.V320.Avionics.Electric.Components {
    public class ElectricalAppliance : UdonSharpBehaviour {
        public float voltage = 0f;
        public float amperage = 0f;
        public float power = 0f;

        public float resistance = 600f;

        [PublicAPI]
        public virtual void Power(float powerVoltage, float powerAmperage) {
            voltage = powerVoltage;
            amperage = powerAmperage;
            power = powerVoltage * powerVoltage / GetResistance();
        }

        [PublicAPI]
        public virtual float GetResistance() {
            return resistance;
        }
    }
}
