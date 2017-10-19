using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace WpfApp2.Mqtt
{
    class Subscriber : INotifyPropertyChanged
    {
        private MqttClient _broker = null;
        private string _id = Guid.NewGuid().ToString();
        private ObservableCollection<string> _topics = new ObservableCollection<string>();
        private ObservableCollection<Message> _messages = new ObservableCollection<Message>();
        public event PropertyChangedEventHandler PropertyChanged;

        public Subscriber()
        {
        }
        public MqttClient Broker {
            set
            {
                _broker = value;
                _broker.MqttMsgPublishReceived += (s, e) =>
                {
                    Message received = new Message();
                    received.Topic = e.Topic;
                    received.Content = Encoding.UTF8.GetString(e.Message);
                    //Dispatcher from UI Thread
                    WpfApp2.App.Current.Dispatcher.Invoke(new Action(() => { Messages.Add(received); }));
                    
                };
            }
        }
        public void Subscribe(string topic)
        {
            if (_broker != null)
            {
                Topics.Add(topic);
                _broker.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
            }
        }
        public ObservableCollection<string> Topics { get => _topics; private set { _topics = value; NotifyPropertyChanged(); } }
        public ObservableCollection<Message> Messages { get => _messages; private set { _messages = value; NotifyPropertyChanged(); } }
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
