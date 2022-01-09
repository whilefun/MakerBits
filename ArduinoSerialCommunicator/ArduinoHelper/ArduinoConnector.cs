using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO.Ports;
using System.Threading;

namespace ArduinoHelper
{

    class ArduinoConnector
    {
        
        static SerialPort _serialPort;

        public static void ConnectToArduino(string portName, int baudRate)
        {

            _serialPort = new SerialPort();

            // Set your board COM (e.g. COM8)
            _serialPort.PortName = portName;
            // Set your baud rate (e.g. 9600)
            _serialPort.BaudRate = baudRate;


            LogText("Trying to open port '"+portName+"' baud rate '"+baudRate+"'");

            try {

                _serialPort.Open();

                //while (true)
                //{

                //    string a = _serialPort.ReadExisting();

                //    //if(a.Length > 0)
                //    //{

                //        Console.WriteLine(a);

                //        //Form1.logOutputTextBox.Text += a + "\n";
                //        logText(a);

                //        Thread.Sleep(200);

                //    //}



                //}

                if (_serialPort.IsOpen)
                {
                    LogText("Port Open!");
                }
                else
                {
                    LogText("Port Not Open!");
                }

            }
            catch(Exception e)
            {

                string exceptionString = "ArduinoConnector.ConnectToArduino()->Exception:: '" + e.Message + "'";
                LogText(exceptionString);

            }

        }

        public static void ClosePort()
        {
            try
            {

                if (_serialPort != null && _serialPort.IsOpen)
                {
                    LogText("Closing Port...");
                    _serialPort.Close();
                }

            }
            catch (Exception e)
            {

                string exceptionString = "ArduinoConnector.ClosePort()->Exception:: '" + e.Message + "'";
                LogText(exceptionString);

            }


        }


        public static void ReadFromPort()
        {

            try
            {

                int availableBytes = _serialPort.BytesToRead;
                LogText("There are " + availableBytes + " to read");

                string a = _serialPort.ReadExisting();
                LogText(a);
                //Thread.Sleep(200);

            }
            catch (Exception e)
            {

                string exceptionString = "ArduinoConnector.ReadFromPort()->Exception:: '" + e.Message + "'";
                LogText(exceptionString);

            }

        }

        public static void WriteToPort(string data)
        {

            try
            {

                _serialPort.Write(data);

            }
            catch (Exception e)
            {

                string exceptionString = "ArduinoConnector.WriteToPort()->Exception:: '" + e.Message + "'";
                LogText(exceptionString);

            }

        }

        public static void WriteCharsToPort(char[] dataChars)
        {

            try
            {

                _serialPort.Write(dataChars, 0, dataChars.Length);

            }
            catch (Exception e)
            {

                string exceptionString = "ArduinoConnector.WriteCharsToPort()->Exception:: '" + e.Message + "'";
                LogText(exceptionString);

            }

        }

        public static void WriteHeadingIntToPort(int heading)
        {

            try
            {

                string headingString = "" + heading;

                char[] headingChars = new char[headingString.Length + 1];

                for(int i = 0; i < headingString.Length; i++)
                {
                    headingChars[i] = headingString[i];
                }

                headingChars[headingChars.Length - 1] = '\n';


                //char[] headingTest = { '2', '3', '5', '\n' };

                //for(int i = 0; i < 4; i++)
                //{
                    _serialPort.Write(headingChars, 0, headingChars.Length);
                //}

                string msg = _serialPort.ReadExisting();
                LogText("RETURN='" + msg + "'");

                //string msg = "" + heading + '\0';
                //_serialPort.Write(msg);

            }
            catch (Exception e)
            {

                string exceptionString = "ArduinoConnector.WriteRawStringToPort()->Exception:: '" + e.Message + "'";
                LogText(exceptionString);

            }

        }


        public static void LogText(string msg)
        {

            Form1.logOutputTextBox.Text += msg + "\r\n";

            Console.WriteLine(msg);

        }

    }
    

}
