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
        private string _id = Guid.NewGuid().ToString();
        public Publisher(string IP)
        {
            _broker = new MqttClient(IP);
            _broker.Connect(_id);
        }
        public Publisher(string topic, byte[] message)
        {
            _broker.Publish(topic, message);
        }
    }
}
