using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using uPLibrary.Networking.M2Mqtt;
using WpfApp2.Mqtt;

namespace WpfApp2
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Subscriber _subscriber = new Subscriber();
        private Publisher _publisher = new Publisher();
        private MqttClient _broker = null;
        public MainWindow()
        {
            InitializeComponent();
            lbReceivedMessages.ItemsSource = _subscriber.Messages;
            lbSubscribedTopics.ItemsSource = _subscriber.Topics;
            //Establishe a new connection with an unencrypted Broker
            cmdConnectPublicMosquittoUnencrypted.Click += (s, e) => 
            {
                //If new Connection, create a new broker connection
                if (_broker == null)
                {
                    _broker = new MqttClient("test.mosquitto.org");
                }
                //If a Connection has already been established, close it and create new one
                else
                {
                    _broker.Disconnect();
                    _broker = new MqttClient("test.mosquitto.org");
                }
                string _id = Guid.NewGuid().ToString();
                _broker.Connect(_id);
                //Cleanup messages and topics from old connection
                _subscriber.Messages.Clear();
                _subscriber.Topics.Clear();
                _subscriber.Broker = _broker;
                _publisher.Broker = _broker;
                chbConnectionStatus.IsChecked = true;
                chbConnectionStatus.Content = "Mosquitto unencrypted public server";
            };
            //Subscribe to new topic
            cmdSubscribe.Click += (s, e) =>
            {
                if (txtSubscribeTopic.Text != "")
                {
                    _subscriber.Subscribe(txtSubscribeTopic.Text);
                }
            };
            //Send Message to Topic
            cmdSend.Click += (s, e) => 
            {
                if (txtMessage.Text != "" && txtTopic.Text != "")
                {
                    _publisher.Publish(txtTopic.Text, Encoding.UTF8.GetBytes(txtMessage.Text));
                }
            };
        }
    }
}
