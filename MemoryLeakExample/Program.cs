using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MemoryLeakExample
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting...");
            var hbm = new HelloBotManager();
            hbm.AddBot("Mike", 2);
            hbm.RemoveBot("Mike");

            Console.WriteLine("press Enter to end the program.");
            Console.ReadKey();
        }


    }

    public class HelloBotManager
    {
        public List<HelloBot> HelloBotList = new List<HelloBot>();
        public void AddBot(string name, int seconds) 
            => this.HelloBotList.Add(new HelloBot(name,seconds));

        public void RemoveBot(string name)
        {
            //HelloBotList.FirstOrDefault(hb => hb.Name.Equals(name)).DetachEvents();
            HelloBotList.RemoveAll(i => i.Name == name);
        }
    }

    public class HelloBot
    {
        private System.Timers.Timer _helloTimer;
        public string Name;

        public HelloBot(string name, int seconds)
        {
            this.Name = name;
            _helloTimer = new System.Timers.Timer(){Interval = seconds * 1000, Enabled = true};
            _helloTimer.Elapsed += _helloTimer_Elapsed;
        }

        public void DetachEvents() => this._helloTimer.Elapsed -= _helloTimer_Elapsed;

        private void _helloTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
            => Console.WriteLine($"Hello from {Name}");
    }


}
