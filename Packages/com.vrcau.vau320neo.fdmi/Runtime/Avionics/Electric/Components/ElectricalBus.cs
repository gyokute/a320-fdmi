using UnityEngine;

namespace VRChatAerospaceUniversity.V320.Avionics.Electric.Components {
    public class ElectricalBus : ElectricalAppliance {
        public ElectricalAppliance[] consumers;

        public override float GetResistance() {
            var totalResistance = 0f;
            foreach (var consumer in consumers) {
                totalResistance += 1 / consumer.GetResistance();
            }

            totalResistance = 1 / totalResistance;

            resistance = totalResistance;

            return totalResistance;
        }

        public override void Power(float powerVoltage, float powerAmperage) {
            base.Power(powerVoltage, powerAmperage);

            foreach (var consumer in consumers) {
                consumer.Power(powerVoltage, powerVoltage / consumer.GetResistance());
            }
        }
    }
}
