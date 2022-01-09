using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArduinoHelper
{

    

    public partial class Form1 : Form
    {

        public static TextBox logOutputTextBox;

        public Form1()
        {

            InitializeComponent();

            logOutputTextBox = loggingTextBox;

        }

        //private void ConnectButton_Click(object sender, EventArgs e)
        //{

           

        //}


        void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {

            ArduinoConnector.ClosePort();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            ArduinoConnector.ReadFromPort();

        }

        //private void button2_Click(object sender, EventArgs e)
        //{

        //    ArduinoConnector.ClosePort();

        //}

        private Button connectButton;
        private Button closePortButton;
        private Button readFromPortButton;
        private Button sendOneButton;
        private Button sendZeroButton;
        private Button sendEscapeCharButton;

        private TextBox loggingTextBox;
        private TextBox portNameTextBox;
        private TextBox baudRateTextBox;

        private void InitializeComponent()
        {
            this.connectButton = new System.Windows.Forms.Button();
            this.closePortButton = new System.Windows.Forms.Button();
            this.readFromPortButton = new System.Windows.Forms.Button();
            this.sendOneButton = new System.Windows.Forms.Button();
            this.sendZeroButton = new System.Windows.Forms.Button();
            this.loggingTextBox = new System.Windows.Forms.TextBox();
            this.portNameTextBox = new System.Windows.Forms.TextBox();
            this.baudRateTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.headingTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.sendStepsButton = new System.Windows.Forms.Button();
            this.sendEscapeCharButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(295, 54);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(184, 23);
            this.connectButton.TabIndex = 0;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click_1);
            // 
            // closePortButton
            // 
            this.closePortButton.Location = new System.Drawing.Point(295, 83);
            this.closePortButton.Name = "closePortButton";
            this.closePortButton.Size = new System.Drawing.Size(184, 23);
            this.closePortButton.TabIndex = 1;
            this.closePortButton.Text = "Close Port";
            this.closePortButton.UseVisualStyleBackColor = true;
            this.closePortButton.Click += new System.EventHandler(this.closePortButton_Click);
            // 
            // readFromPortButton
            // 
            this.readFromPortButton.Location = new System.Drawing.Point(19, 312);
            this.readFromPortButton.Name = "readFromPortButton";
            this.readFromPortButton.Size = new System.Drawing.Size(75, 23);
            this.readFromPortButton.TabIndex = 2;
            this.readFromPortButton.Text = "Read From Port";
            this.readFromPortButton.UseVisualStyleBackColor = true;
            this.readFromPortButton.Click += new System.EventHandler(this.readFromPortButton_Click);
            // 
            // sendOneButton
            // 
            this.sendOneButton.Location = new System.Drawing.Point(223, 314);
            this.sendOneButton.Name = "sendOneButton";
            this.sendOneButton.Size = new System.Drawing.Size(75, 23);
            this.sendOneButton.TabIndex = 3;
            this.sendOneButton.Text = "Send \"1\"";
            this.sendOneButton.UseVisualStyleBackColor = true;
            this.sendOneButton.Click += new System.EventHandler(this.sendOneButton_Click);
            // 
            // sendZeroButton
            // 
            this.sendZeroButton.Location = new System.Drawing.Point(304, 314);
            this.sendZeroButton.Name = "sendZeroButton";
            this.sendZeroButton.Size = new System.Drawing.Size(75, 23);
            this.sendZeroButton.TabIndex = 4;
            this.sendZeroButton.Text = "Send \"0\"";
            this.sendZeroButton.UseVisualStyleBackColor = true;
            this.sendZeroButton.Click += new System.EventHandler(this.sendZeroButton_Click);
            // 
            // loggingTextBox
            // 
            this.loggingTextBox.Location = new System.Drawing.Point(19, 125);
            this.loggingTextBox.Multiline = true;
            this.loggingTextBox.Name = "loggingTextBox";
            this.loggingTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.loggingTextBox.Size = new System.Drawing.Size(460, 168);
            this.loggingTextBox.TabIndex = 5;
            // 
            // portNameTextBox
            // 
            this.portNameTextBox.Location = new System.Drawing.Point(149, 56);
            this.portNameTextBox.Name = "portNameTextBox";
            this.portNameTextBox.Size = new System.Drawing.Size(99, 20);
            this.portNameTextBox.TabIndex = 6;
            this.portNameTextBox.Text = "COM8";
            // 
            // baudRateTextBox
            // 
            this.baudRateTextBox.Location = new System.Drawing.Point(149, 82);
            this.baudRateTextBox.Name = "baudRateTextBox";
            this.baudRateTextBox.Size = new System.Drawing.Size(99, 20);
            this.baudRateTextBox.TabIndex = 7;
            this.baudRateTextBox.Text = "9600";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Port Name (e.g. COM8)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Baud Rate (e.g. 9600)";
            // 
            // headingTextBox
            // 
            this.headingTextBox.Location = new System.Drawing.Point(324, 380);
            this.headingTextBox.Name = "headingTextBox";
            this.headingTextBox.Size = new System.Drawing.Size(46, 20);
            this.headingTextBox.TabIndex = 10;
            this.headingTextBox.Text = "359";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 383);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Steps To Move";
            // 
            // sendStepsButton
            // 
            this.sendStepsButton.Location = new System.Drawing.Point(385, 375);
            this.sendStepsButton.Name = "sendStepsButton";
            this.sendStepsButton.Size = new System.Drawing.Size(83, 29);
            this.sendStepsButton.TabIndex = 12;
            this.sendStepsButton.Text = "Send Steps";
            this.sendStepsButton.UseVisualStyleBackColor = true;
            this.sendStepsButton.Click += new System.EventHandler(this.sendStepsButton_Click);
            // 
            // sendEscapeCharButton
            // 
            this.sendEscapeCharButton.Location = new System.Drawing.Point(385, 314);
            this.sendEscapeCharButton.Name = "sendEscapeCharButton";
            this.sendEscapeCharButton.Size = new System.Drawing.Size(72, 24);
            this.sendEscapeCharButton.TabIndex = 13;
            this.sendEscapeCharButton.Text = "Send \"\\0\"";
            this.sendEscapeCharButton.UseVisualStyleBackColor = true;
            this.sendEscapeCharButton.Click += new System.EventHandler(this.sendEscapeCharButton_Click_1);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(493, 517);
            this.Controls.Add(this.sendEscapeCharButton);
            this.Controls.Add(this.sendStepsButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.headingTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.baudRateTextBox);
            this.Controls.Add(this.portNameTextBox);
            this.Controls.Add(this.loggingTextBox);
            this.Controls.Add(this.sendZeroButton);
            this.Controls.Add(this.sendOneButton);
            this.Controls.Add(this.readFromPortButton);
            this.Controls.Add(this.closePortButton);
            this.Controls.Add(this.connectButton);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void connectButton_Click_1(object sender, EventArgs e)
        {
            ArduinoConnector.ConnectToArduino(portNameTextBox.Text, 9600);
        }

        private void closePortButton_Click(object sender, EventArgs e)
        {
            ArduinoConnector.ClosePort();
        }

        private void readFromPortButton_Click(object sender, EventArgs e)
        {
            ArduinoConnector.ReadFromPort();
        }

        private void sendOneButton_Click(object sender, EventArgs e)
        {
            ArduinoConnector.WriteToPort("1");
        }

        private void sendZeroButton_Click(object sender, EventArgs e)
        {
            ArduinoConnector.WriteToPort("0");
        }

        private Label label1;
        private Label label2;
        private TextBox headingTextBox;
        private Label label3;
        private Button sendStepsButton;

        private void sendStepsButton_Click(object sender, EventArgs e)
        {

            string rawHeading = headingTextBox.Text;

            try
            {

                int heading = int.Parse(rawHeading);

                if(heading >= 0 && heading <= 359)
                {
                    ArduinoConnector.WriteHeadingIntToPort(heading);
                }
                else
                {
                    ArduinoConnector.LogText("Bad heading '" + rawHeading + "'");
                }

            }
            catch(Exception ex)
            {

                string exceptionString = "Form1.sendStepsButton_Click()->Exception:: '" + ex.Message + "'";
                ArduinoConnector.LogText(exceptionString);

            }

        }

        

        private void sendEscapeCharButton_Click_1(object sender, EventArgs e)
        {

            ArduinoConnector.WriteToPort("\0");

        }
    }

}
