using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Linq;
namespace Observer {
    interface IPublisher {
        void Subscribe(ISubscriber subscriber);
        void Unsubscribe(ISubscriber subscriber);
        void Notify();
    }

    interface ISubscriber {
        void Update(IPublisher publisher);
    }
    class EventManager : IPublisher {

        public int State { get; set; }

        private List<ISubscriber> Subscribers = new List<ISubscriber>();

        public void Subscribe(ISubscriber subscriber) {
            Console.WriteLine("Subscribed to Publisher");
            this.Subscribers.Add(subscriber);
        }

        public void Unsubscribe(ISubscriber subscriber) {
            this.Subscribers.Remove(subscriber);
            Console.WriteLine("Unsubscribed from Publisher");
        }

        public void Notify() {
            foreach (ISubscriber subscriber in this.Subscribers) {
                subscriber.Update(this);
            }
        }

        public void SendAMessage() {
            State = new Random().Next(0, 10);

            Thread.Sleep(3);

            Notify();
        }
    }

    class WriteEventsToFile : ISubscriber {
        public void Update(IPublisher publisher) {
            if (((EventManager)publisher).State < 3) {
                using (StreamWriter streamWriter = new StreamWriter("./logs/log.txt", true)){
                    streamWriter.WriteLine($"The publisher's state is now {((EventManager)publisher).State}");
                }
            }
        }
    }

    class WriteEventsToConsole : ISubscriber {
        public void Update(IPublisher publisher) {
            if (((EventManager)publisher).State > 7) {
                Console.WriteLine($"The publisher's state is now {(publisher as EventManager).State}");
            }
        }
    }

    class WriteEventsToSecondTextFile : ISubscriber {
        public void Update(IPublisher publisher) {
            if ((publisher as EventManager).State == 5) {
                using (StreamWriter streamWriter = new StreamWriter("./Log2.txt", true)) {
                    streamWriter.WriteLine($"The publisher's state is now {(publisher as EventManager).State}");
                }
            }
        }
    }

    class WriteEventToLogFile : ISubscriber {

        private string LogFilePath { get; }

        private int[] StateRange { get; }

        private string Message { get; set; }
        public WriteEventToLogFile(string path, int[] stateRange, string message) {
            LogFilePath = path;
            StateRange = stateRange;
            Message = message;
        }
        public void Update(IPublisher publisher) {
            if (StateRange.Contains((publisher as EventManager).State)) {
                using (StreamWriter streamWriter = new StreamWriter(LogFilePath, true)) {
                    streamWriter.WriteLine(string.Format(Message, (publisher as EventManager).State));
                }
            }
        }
    }

    class Program {
        static void Main(string[] args) {
            EventManager eventManager = new EventManager();

            List<ISubscriber> eventsToFiles = new List<ISubscriber>();
            for (int i = 0; i < 10; i++){
                eventsToFiles.Add(new WriteEventToLogFile($"./logs/log{i}.txt", new int[] {i}, $"The publisher's state is now {i}"));
                eventManager.Subscribe(eventsToFiles[i]);
            }

            ISubscriber eventsToConsole = new WriteEventsToConsole();
            eventManager.Subscribe(eventsToConsole);

            for (int i = 0; i < 10; i++) {
                eventManager.SendAMessage();
            }

            eventManager.Unsubscribe(eventsToConsole);

            for (int i = 0; i < 5; i++) {
                eventManager.SendAMessage();
            }
        }
    }
}