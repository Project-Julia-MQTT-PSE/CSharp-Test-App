using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace WpfApp2.Mqtt
{
    class Publisher
    {
        private MqttClient _broker = null;
        public Publisher()
        {
        }
        public MqttClient Broker { set { _broker = value; } }
        public void Publish(string topic, byte[] message)
        {
            if (_broker != null)
            {
                _broker.Publish(topic, message);
            }
        }
    }
}
