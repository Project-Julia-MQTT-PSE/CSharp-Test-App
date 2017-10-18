using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace WpfApp2.Mqtt
{
    class Subscriber : INotifyPropertyChanged
    {
        private MqttClient _broker = null;
        private string _id = Guid.NewGuid().ToString();
        private List<string> _topics = new List<string>();
        private List<Message> _messages = new List<Message>();
        public event PropertyChangedEventHandler PropertyChanged;

        public Subscriber(string IP)
        {
            _broker = new MqttClient(IP);
            _broker.Connect(_id);
            _broker.MqttMsgPublishReceived += (s,e) => 
            {
                Message received = new Message();
                received.Topic = e.Topic;
                received.Content = e.Message.ToString();
                Messages.Add(received);
            };
        }
        public void Subscribe(string topic)
        {
            Topics.Add(topic);
            _broker.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        }
        public List<string> Topics { get => _topics; private set { _topics = value; NotifyPropertyChanged(); } }
        public List<Message> Messages { get => _messages; private set { _messages = value; NotifyPropertyChanged(); } }
        //Notify Property Event
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
