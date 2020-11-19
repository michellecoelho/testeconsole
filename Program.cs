using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace WebPageClick
{
    class Program
    {
        //static public Point MousePos;
        //static Button One = new Button();
        static int _x, _y;
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var prs = new System.Diagnostics.ProcessStartInfo(@"C:\Program Files (x86)\Google\Chrome\Application\chrome.exe");            
            prs.Arguments = "https://afazenda.r7.com/a-fazenda-12/votacao";

            try
            {
                //System.Diagnostics.Process.Start("https://afazenda.r7.com/a-fazenda-12");
                System.Diagnostics.Process.Start(prs);
                Console.CursorVisible = false;
                
                System.Threading.Thread.Sleep(10000);
            

                while (!Console.KeyAvailable)
                {
                    ShowMousePosition();
                }
                Console.CursorVisible = true;
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        [DllImport("user32.dll")]
        static extern bool GetCursorPos(out POINT lpPoint);

        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        public struct POINT
        {
            public int X;
            public int Y;
        }



        static void ShowMousePosition()
        {
            POINT point;

            if (GetCursorPos(out point) && point.X != _x && point.Y != _y)
            {
                Console.Clear();
                Console.WriteLine("({0},{1})", point.X, point.Y);
                _x = point.X;
                _y = point.Y;
            }

           

            for(int i = 0; i <= 100000000; i++){

            System.Threading.Thread.Sleep(1000);

            //VOTO
            _x = 497;
            _y = 574;

            SetCursorPos(_x, _y);
            Console.WriteLine("mouse");
            mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)_x, (uint)_y, 0, 0);
            System.Threading.Thread.Sleep(1000);
            mouse_event(MOUSEEVENTF_LEFTUP, (uint)_x, (uint)_y, 0, 0);

            System.Threading.Thread.Sleep(1000);
                    
            //VOTAR NOVAMENTE
            _x = 662;
            _y = 455;

            SetCursorPos(_x, _y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)_x, (uint)_y, 0, 0);
            System.Threading.Thread.Sleep(1000);
            mouse_event(MOUSEEVENTF_LEFTUP, (uint)_x, (uint)_y, 0, 0);   

            System.Threading.Thread.Sleep(1000);        
            
            //ROCEIRO
            _x = 503;
            _y = 411;

            SetCursorPos(_x, _y);
            mouse_event(MOUSEEVENTF_LEFTDOWN, (uint)_x, (uint)_y, 0, 0);
            System.Threading.Thread.Sleep(1000);
            mouse_event(MOUSEEVENTF_LEFTUP, (uint)_x, (uint)_y, 0, 0);   

            System.Threading.Thread.Sleep(1000);        
            
            Console.WriteLine(i);
            }
 

        }


        [DllImport("user32.dll",CharSet=CharSet.Auto, CallingConvention=CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);
        //Mouse actions
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;
    }
}
