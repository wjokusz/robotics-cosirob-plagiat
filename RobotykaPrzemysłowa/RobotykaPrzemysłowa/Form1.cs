using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace RobotykaPrzemysłowa
{
    public partial class Form1 : Form
    {
        string dataOut;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBoxPort.Items.AddRange(ports);

            checkBoxDTR.Checked = false;
            checkBoxRTS_CTS.Checked = false;
            checkBoxXON_XOFF.Checked = false;

            buttonQuickCommandSend.Enabled = false;
            buttonClose.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort1.PortName = comboBoxPort.Text;
                serialPort1.BaudRate = Convert.ToInt32(comboBoxBaudRate.Text);
                serialPort1.DataBits = Convert.ToInt32(comboBoxDataBits.Text);
                serialPort1.Parity = (Parity)Enum.Parse(typeof(Parity), comboBoxParity.Text);
                serialPort1.StopBits = (StopBits)Enum.Parse(typeof(StopBits), comboBoxStopBits.Text);

                serialPort1.Open();
                progressBarConnection.Value = 100;
                buttonOpen.Enabled = false;               
                buttonClose.Enabled = true;
                buttonQuickCommandSend.Enabled = true;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonQuickCommandSend_Click(object sender, EventArgs e)
        {
            dataOut = textBoxQuickCommand.Text;
            serialPort1.Write(dataOut + "\r");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            progressBarConnection.Value = 0;
            buttonOpen.Enabled = true;
            buttonClose.Enabled = false;
        }

        private void checkBoxDTR_CheckedChanged(object sender, EventArgs e)
        {
            serialPort1.DtrEnable = checkBoxDTR.Checked;
        }

        private void checkBoxRTS_CTS_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }
    }
}
