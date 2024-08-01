using LiftingStationRevitFeeder.Application;
using LiftingStationRevitFeeder.Domain;
using FluentAssertions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using MeasurementUnits.NET;
//using LiftingStationRevitFeeder.Domain;

namespace RevitFeederUI
{
    public partial class LiftStationSizer : Form
    {
        private void AddItemsToComboBoxes(string[] items, params System.Windows.Forms.ComboBox[] comboBoxes)
        {
            foreach (var comboBox in comboBoxes)
            {
                comboBox.Items.AddRange(items);
            }
        }

        public LiftStationSizer()
        {
            InitializeComponent();

            string[] items = { "Select", "40", "50", "65", "80", "100", "125", "150", "200", "250", "300", "350", "400", "450", "500", "550", "600" };

            AddItemsToComboBoxes(items, dn1, dn2,
                             dnInlet, dn3, dn4,
                             dn5, dnBreath, dnBackflow);

            dn1.SelectedIndex = 0;
            dn2.SelectedIndex = 0;
            dnInlet.SelectedIndex = 0;
            dn3.SelectedIndex = 0;
            dn4.SelectedIndex = 0;
            dn5.SelectedIndex = 0;
            dnBreath.SelectedIndex = 0;
            dnBackflow.SelectedIndex = 0;

            dn1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            dn2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            dnInlet.SelectedIndexChanged += comboBox3_SelectedIndexChanged;
            dn3.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            dn4.SelectedIndexChanged += comboBox5_SelectedIndexChanged;
            dn5.SelectedIndexChanged += comboBox6_SelectedIndexChanged;
            dnBreath.SelectedIndexChanged += comboBox7_SelectedIndexChanged;
            dnBackflow.SelectedIndexChanged += comboBox8_SelectedIndexChanged;

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {
            int lowerBound = 65;
            int upperBound = 500;
            if (int.TryParse(dn1.Text, out int dn1Value))
            {
                if (dn1Value < lowerBound)
                {
                    dn1.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dn1Value > upperBound)
                {
                    dn1.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                dn1.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label23.ForeColor = Color.RoyalBlue;
            label24.ForeColor = Color.RoyalBlue;
            { this.dn2.Enabled = true; }
            { this.label21.Enabled = true; }
            { this.label22.Enabled = true; }
            pumpInletVelocity.Text = Math.Round(((double.Parse(flow.Text) / double.Parse(duty.Text) / 3600) / (Math.Pow(double.Parse(dn1.Text) / 1000, 2) * Math.PI / 4)), 1).ToString();

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void label53_Click(object sender, EventArgs e)
        {

        }

        private void label49_Click_1(object sender, EventArgs e)
        {

        }

        private void label94_Click(object sender, EventArgs e)
        {

        }

        private void label95_Click(object sender, EventArgs e)
        {

        }

        private void label46_Click(object sender, EventArgs e)
        {

        }

        private void label99_Click(object sender, EventArgs e)
        {

        }

        private void label101_Click(object sender, EventArgs e)
        {

        }
        //Flow selector
        private void label106_Click(object sender, EventArgs e)
        {
            int lowerBound = 16;
            int upperBound = 1000;
            if (int.TryParse(flow.Text, out int flowValue))
            {
                if (flowValue < lowerBound)
                {
                    flow.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} m³/h and {upperBound} m³/h." +
                        $"\nValue modified to lower limit!");
                }
                else if (flowValue > upperBound)
                {
                    flow.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} m³/h and {upperBound} m³/h." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                flow.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} m³/h and {upperBound} m³/h." +
                        $"\nValue modified to lower limit!");
            }
            label105.ForeColor = Color.RoyalBlue;
            label106.ForeColor = Color.RoyalBlue;
            { this.head.Enabled = true; }
            { this.label103.Enabled = true; }
            { this.label104.Enabled = true; }
        }

        private void label113_Click(object sender, EventArgs e)
        {

        }

        // RESET Button
        private void button2_Click(object sender, EventArgs e)
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is System.Windows.Forms.TextBox textBox)
                {
                    textBox.Text = string.Empty;
                    textBox.Enabled = false;
                }
                else if (ctrl is System.Windows.Forms.ComboBox comboBox)
                {
                    comboBox.SelectedIndex = 0;
                    comboBox.Enabled = false;
                }
                else if (ctrl is System.Windows.Forms.Label label)
                {
                    label.Enabled = false;
                    label.ForeColor = Color.Black;
                }
            }
            { this.label105.Enabled = true; }
            { this.label106.Enabled = true; }
            { this.label50.Enabled = true; }
            { this.label51.Enabled = true; }
            { this.label50.ForeColor = Color.RoyalBlue; }
            { this.label51.ForeColor = Color.RoyalBlue; }
            { this.label102.Enabled = true; }
            { this.label99.Enabled = true; }
            { this.label102.ForeColor = Color.RoyalBlue; }
            { this.label99.ForeColor = Color.RoyalBlue; }
            { this.label53.Enabled = true; }
            { this.label49.Enabled = true; }
            { this.label53.ForeColor = Color.RoyalBlue; }
            { this.label49.ForeColor = Color.RoyalBlue; }
            { this.label94.Enabled = true; }
            { this.label95.Enabled = true; }
            { this.label94.ForeColor = Color.RoyalBlue; }
            { this.label95.ForeColor = Color.RoyalBlue; }
            { this.flow.Enabled = true; }
            //dn1.SelectedIndex = 0;
            //dn2.SelectedIndex = 0;
            //dnInlet.SelectedIndex = 0;
            //dn3.SelectedIndex = 0;
            //dn4.SelectedIndex = 0;
            //dn5.SelectedIndex = 0;
            //dnBreath.SelectedIndex = 0;
            //dnBackflow.SelectedIndex = 0;
        }
        // Enable DimB
        //private void CheckAndEnableTextBox11()
        //{
        //    bool isComboBoxSelected = comboBox1.SelectedItem != null && comboBox1.SelectedItem.ToString() != "Select";
        //    bool isTextBox1Valid = double.TryParse(textBox1.Text, out _);
        //    bool isTextBox3Valid = double.TryParse(textBox3.Text, out _);

        //    textBox11.Enabled = isComboBoxSelected && isTextBox1Valid && isTextBox3Valid;
        //}
        // DN1 selector
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = dn1.SelectedItem.ToString();
            //if (selectedItem != "Select")
            //{ this.comboBox2.Enabled = true; }
            //else
            //{ this.comboBox2.Enabled = false; }
        }
        // DN2 selector
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = dn2.SelectedItem.ToString();
        }
        // DNInlet selector
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = dnInlet.SelectedItem.ToString();
        }
        // DN3 selector
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = dn3.SelectedItem.ToString();
        }
        // DN4 selector
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = dn4.SelectedItem.ToString();
        }
        // DN5 selector
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = dn5.SelectedItem.ToString();
        }
        // DNBreath selector
        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = dnBreath.SelectedItem.ToString();
        }
        // DNBackflow selector
        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = dnBackflow.SelectedItem.ToString();
        }

        // DimA validator
        private void label1_Click(object sender, EventArgs e)
        {
            int lowerBound = 75;
            int upperBound = 500;
            if (int.TryParse(dimA.Text, out int dimAValue))
            {


                if (dimAValue < lowerBound)
                {
                    dimA.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimAValue > upperBound)
                {
                    dimA.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                dimA.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label1.ForeColor = Color.RoyalBlue;
            label2.ForeColor = Color.RoyalBlue;
            { this.dimC.Enabled = true; }
            { this.label5.Enabled = true; }
            { this.label6.Enabled = true; }
        }
        // DimB validator
        private void label4_Click(object sender, EventArgs e)
        {
            int dn1Value;
            int dimAValue = 0;
            int dimBValue;
            int dimCValue = 0;
            if (int.TryParse(dn1.Text, out dn1Value) && int.TryParse(dimA.Text, out dimAValue)
                && int.TryParse(dimB.Text, out dimBValue) && int.TryParse(dimC.Text, out dimCValue))
            {
                int lowerBound = Convert.ToInt32(1.5 * dn1Value + dimCValue - dimAValue + 400);
                int upperBound = 3000;

                if (dimBValue < lowerBound)
                {
                    dimB.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimBValue > upperBound)
                {
                    dimB.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                int lowerBound = Convert.ToInt32(1.5 * dn1Value + dimCValue - dimAValue + 400);
                int upperBound = 3000;
                dimB.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label3.ForeColor = Color.RoyalBlue;
            label4.ForeColor = Color.RoyalBlue;
            { this.dimD.Enabled = true; }
            { this.label7.Enabled = true; }
            { this.label8.Enabled = true; }
        }
        //DimA selector
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if (double.TryParse(textBox1.Text, out _))
            //{ this.textBox3.Enabled = true; }
            //else
            //{ this.textBox3.Enabled = false; }
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //CheckAndEnableTextBox11();
        }
        // DimC Validator
        private void label6_Click(object sender, EventArgs e)
        {
            int dn2Value;
            int dimAValue = 0;

            if (int.TryParse(dn2.Text, out dn2Value) && int.TryParse(dimA.Text, out dimAValue)
            && int.TryParse(dimC.Text, out int dimCValue))
            {
                int lowerBound = Convert.ToInt32(dn2Value / 2 + dimAValue + 35);
                int upperBound = Convert.ToInt32(dn2Value / 2 + dimAValue + 85);

                if (dimCValue < lowerBound)
                {
                    dimC.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimCValue > upperBound)
                {
                    dimC.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }

                else { }
            }
            else
            {
                int lowerBound = Convert.ToInt32(dn2Value / 2 + dimAValue + 35);
                int upperBound = Convert.ToInt32(dn2Value / 2 + dimAValue + 85);
                dimC.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label5.ForeColor = Color.RoyalBlue;
            label6.ForeColor = Color.RoyalBlue;
            { this.dimB.Enabled = true; }
            { this.label3.Enabled = true; }
            { this.label4.Enabled = true; }
        }
        // DN2 validator
        private void label22_Click(object sender, EventArgs e)
        {
            int dn1Value = int.Parse(dn1.SelectedItem.ToString());
            int dn2Value;

            if (int.TryParse(dn2.Text, out dn2Value) && int.TryParse(dn1.Text, out dn1Value))
            {
                string selectedValue = dn1.SelectedItem.ToString();
                int selectedIndex = dn1.SelectedIndex;
                string smallestItemAvailable = dn1.Items[selectedIndex - 2].ToString();
                int lowerBound = Math.Max(50, Convert.ToInt32(smallestItemAvailable));
                int upperBound = Math.Min(400, Convert.ToInt32(dn1Value));

                if (dn2Value < lowerBound)
                {
                    dn2.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dn2Value > upperBound)
                {
                    dn2.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                string selectedValue = dn1.SelectedItem.ToString();
                int selectedIndex = dn1.SelectedIndex;
                string smallestItemAvailable = dn1.Items[selectedIndex - 2].ToString();
                int lowerBound = Math.Max(50, Convert.ToInt32(smallestItemAvailable));
                int upperBound = Math.Min(400, Convert.ToInt32(dn1Value));
                dn2.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} m and {upperBound} m." +
                        $"\nValue modified to lower limit!");
            }
            label22.ForeColor = Color.RoyalBlue;
            label21.ForeColor = Color.RoyalBlue;
            { this.dimA.Enabled = true; }
            { this.label1.Enabled = true; }
            { this.label2.Enabled = true; }
        }
        // Head validator
        private void label104_Click(object sender, EventArgs e)
        {
            int lowerBound = 3;
            int upperBound = 60;
            if (int.TryParse(head.Text, out int headValue))
            {
                if (headValue < lowerBound)
                {
                    head.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} m and {upperBound} m." +
                        $"\nValue modified to lower limit!");
                }
                else if (headValue > upperBound)
                {
                    head.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} m and {upperBound} m." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                head.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} m and {upperBound} m." +
                        $"\nValue modified to lower limit!");
            }
            label103.ForeColor = Color.RoyalBlue;
            label104.ForeColor = Color.RoyalBlue;
            { this.duty.Enabled = true; }
            { this.label108.Enabled = true; }
            { this.label110.Enabled = true; }
        }
        // No. Duty pumps validator 
        private void label110_Click(object sender, EventArgs e)
        {
            int lowerBound = 1;
            int upperBound = 6;
            if (int.TryParse(duty.Text, out int dutyPumps))
            {
                if (dutyPumps < lowerBound)
                {
                    duty.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} pcs and {upperBound} pcs." +
                        $"\nValue modified to lower limit!");
                }
                else if (dutyPumps > upperBound)
                {
                    duty.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} pcs and {upperBound} pcs." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                duty.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} pcs and {upperBound} pcs." +
                        $"\nValue modified to lower limit!");
            }
            //label108.ForeColor = Color.RoyalBlue;
            label110.ForeColor = Color.RoyalBlue;
            { this.standby.Enabled = true; }
            //{ this.label108.Enabled = true; }
            { this.label107.Enabled = true; }
        }
        // No. Standby pumps validator
        private void label107_Click(object sender, EventArgs e)
        {
            int lowerBound = 1;
            int upperBound = 4;
            if (int.TryParse(standby.Text, out int standbyPumps))
            {
                if (standbyPumps < lowerBound)
                {
                    standby.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} pcs and {upperBound} pcs." +
                        $"\nValue modified to lower limit!");
                }
                else if (standbyPumps > upperBound)
                {
                    standby.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} pcs and {upperBound} pcs." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                standby.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} pcs and {upperBound} pcs." +
                        $"\nValue modified to lower limit!");
            }
            label107.ForeColor = Color.RoyalBlue;
            label108.ForeColor = Color.RoyalBlue;
            { this.dnInlet.Enabled = true; }
            { this.label54.Enabled = true; }
            { this.label93.Enabled = true; }
        }
        // DNInlet validator 
        private void label93_Click(object sender, EventArgs e)
        {
            string flowValue = flow.Text;
            string selectedItem = dnInlet.SelectedItem.ToString();
            if (selectedItem != "Select")
            {
                this.dnBreath.Enabled = true;
                label54.ForeColor = Color.RoyalBlue;
                label93.ForeColor = Color.RoyalBlue;
                { this.label25.Enabled = true; }
                { this.label26.Enabled = true; }
                gravityPipeVelocity.Text = Math.Round(((double.Parse(flowValue) / 3600) / (Math.Pow(double.Parse(selectedItem) / 1000, 2) * Math.PI / 4)), 1).ToString();
            }
            else
            { this.dnBreath.Enabled = false; }

        }
        // DnBreath validator
        private void label26_Click(object sender, EventArgs e)
        {
            string selectedItem = dnBreath.SelectedItem.ToString();
            if (selectedItem != "Select")
            {
                this.dnBackflow.Enabled = true;
                label25.ForeColor = Color.RoyalBlue;
                label26.ForeColor = Color.RoyalBlue;
                { this.label47.Enabled = true; }
                { this.label48.Enabled = true; }
            }
            else
            { this.dnBackflow.Enabled = false; }

        }
        // DNBackflow validator
        private void label48_Click(object sender, EventArgs e)
        {
            string selectedItem = dnBackflow.SelectedItem.ToString();
            if (selectedItem != "Select")
            {
                this.dn1.Enabled = true;
                label47.ForeColor = Color.RoyalBlue;
                label48.ForeColor = Color.RoyalBlue;
                { this.label23.Enabled = true; }
                { this.label24.Enabled = true; }
            }
            else
            { this.dn1.Enabled = false; }

        }
        // DimD validator
        private void label8_Click(object sender, EventArgs e)
        {
            int dn2Value;
            int dimCValue = 0;

            if (int.TryParse(dn2.Text, out dn2Value) && int.TryParse(dimC.Text, out dimCValue)
            && int.TryParse(dimD.Text, out int dimDValue))
            {
                int lowerBound = dn2Value + dimCValue + 75;
                int upperBound = dn2Value + dimCValue + 200;

                if (dimDValue < lowerBound)
                {
                    dimD.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimDValue > upperBound)
                {
                    dimD.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }

                else { }
            }
            else
            {
                int lowerBound = dn2Value + dimCValue + 75;
                int upperBound = dn2Value + dimCValue + 200;
                dimD.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label7.ForeColor = Color.RoyalBlue;
            label8.ForeColor = Color.RoyalBlue;
            { this.dimH.Enabled = true; }
            { this.label15.Enabled = true; }
            { this.label16.Enabled = true; }
        }
        // DimH validator
        private void label16_Click(object sender, EventArgs e)
        {
            int dn1Value;
            int lowerBound = 0;
            int upperBound = 0;

            if (int.TryParse(dn1.Text, out dn1Value) && int.TryParse(dimH.Text, out int dimHValue))
            {
                if (dn1Value < 100)
                {
                    lowerBound = Convert.ToInt32(dn1Value * 4);
                }
                else if (dn1Value < 175)
                {
                    lowerBound = Convert.ToInt32(dn1Value * 3);
                }
                else if (dn1Value < 250)
                {
                    lowerBound = Convert.ToInt32(dn1Value * 2.5);
                }
                else
                {
                    lowerBound = Convert.ToInt32(dn1Value * 2);
                }

                if (dn1Value < 100)
                {
                    upperBound = Convert.ToInt32(dn1Value * 6);
                }
                else if (dn1Value < 175)
                {
                    upperBound = Convert.ToInt32(dn1Value * 5);
                }
                else if (dn1Value < 250)
                {
                    upperBound = Convert.ToInt32(dn1Value * 4.5);
                }
                else
                {
                    upperBound = Convert.ToInt32(dn1Value * 4);
                }

                if (dimHValue < lowerBound)
                {
                    dimH.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimHValue > upperBound)
                {
                    dimH.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }

                else { }
            }
            else
            {
                if (dn1Value < 100)
                {
                    lowerBound = Convert.ToInt32(dn1Value * 4);
                }
                else if (dn1Value < 175)
                {
                    lowerBound = Convert.ToInt32(dn1Value * 3);
                }
                else if (dn1Value < 250)
                {
                    lowerBound = Convert.ToInt32(dn1Value * 2.5);
                }
                else
                {
                    lowerBound = Convert.ToInt32(dn1Value * 2);
                }

                if (dn1Value < 100)
                {
                    upperBound = Convert.ToInt32(dn1Value * 6);
                }
                else if (dn1Value < 175)
                {
                    upperBound = Convert.ToInt32(dn1Value * 5);
                }
                else if (dn1Value < 250)
                {
                    upperBound = Convert.ToInt32(dn1Value * 4.5);
                }
                else
                {
                    upperBound = Convert.ToInt32(dn1Value * 4);
                }

                dimH.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label15.ForeColor = Color.RoyalBlue;
            label16.ForeColor = Color.RoyalBlue;
            { this.dimI.Enabled = true; }
            { this.label17.Enabled = true; }
            { this.label18.Enabled = true; }
        }
        // DimI validator
        private void label18_Click(object sender, EventArgs e)
        {
            int dimHValue = 0;

            if (int.TryParse(dimH.Text, out dimHValue)
            && int.TryParse(dimI.Text, out int dimIValue))
            {
                int lowerBound = Convert.ToInt32(dimHValue * 0.5);
                int upperBound = Convert.ToInt32(dimHValue * 0.75);

                if (dimIValue < lowerBound)
                {
                    dimI.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimIValue > upperBound)
                {
                    dimI.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }

                else { }
            }
            else
            {
                int lowerBound = Convert.ToInt32(dimHValue * 0.5);
                int upperBound = Convert.ToInt32(dimHValue * 0.75);
                dimI.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label17.ForeColor = Color.RoyalBlue;
            label18.ForeColor = Color.RoyalBlue;
            { this.dimE.Enabled = true; }
            { this.label9.Enabled = true; }
            { this.label10.Enabled = true; }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        // DimE validator
        private void label10_Click(object sender, EventArgs e)
        {
            int dimIValue = 0;

            if (int.TryParse(dimI.Text, out dimIValue)
            && int.TryParse(dimE.Text, out int dimEValue))
            {
                int lowerBound = Convert.ToInt32(dimIValue * 1.25);
                int upperBound = Convert.ToInt32(dimIValue * 2);

                if (dimEValue < lowerBound)
                {
                    dimE.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimEValue > upperBound)
                {
                    dimE.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }

                else { }
            }
            else
            {
                int lowerBound = Convert.ToInt32(dimIValue * 1.25);
                int upperBound = Convert.ToInt32(dimIValue * 2);
                dimE.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label9.ForeColor = Color.RoyalBlue;
            label10.ForeColor = Color.RoyalBlue;
            { this.dimF.Enabled = true; }
            { this.label11.Enabled = true; }
            { this.label12.Enabled = true; }
        }
        // DimF validator
        private void label12_Click(object sender, EventArgs e)
        {
            double dn2Value;

            if (double.TryParse(dn2.Text, out dn2Value) && int.TryParse(dimF.Text, out int dimFValue))
            {
                int lowerBound = Convert.ToInt32(Math.Round(((dn2Value + 90) / 2) / 5) * 5);
                int upperBound = 400;

                if (dimFValue < lowerBound)
                {
                    dimF.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimFValue > upperBound)
                {
                    dimF.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }

                else { }
            }
            else
            {
                int lowerBound = Convert.ToInt32(Math.Round(((dn2Value + 90) / 2) / 5) * 5);
                int upperBound = 400;
                dimF.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label11.ForeColor = Color.RoyalBlue;
            label12.ForeColor = Color.RoyalBlue;
            { this.dimG.Enabled = true; }
            { this.label13.Enabled = true; }
            { this.label14.Enabled = true; }
        }
        // DimG validator
        private void label14_Click(object sender, EventArgs e)
        {
            int dn2Value;
            double dimFValue = 0;

            if (int.TryParse(dn2.Text, out dn2Value) && double.TryParse(dimF.Text, out dimFValue)
                && int.TryParse(dimG.Text, out int dimGValue))
            {
                int lowerBound = Convert.ToInt32(dimFValue / 2 + dn2Value);
                int upperBound = Convert.ToInt32(dimFValue + dn2Value * 2);

                if (dimGValue < lowerBound)
                {
                    dimG.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimGValue > upperBound)
                {
                    dimG.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                int lowerBound = Convert.ToInt32(dimFValue / 2 + dn2Value);
                int upperBound = Convert.ToInt32(dimFValue + dn2Value * 2);
                dimG.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label13.ForeColor = Color.RoyalBlue;
            label14.ForeColor = Color.RoyalBlue;
            { this.dimJ.Enabled = true; }
            { this.label19.Enabled = true; }
            { this.label20.Enabled = true; }
        }
        // DimJ validator
        private void label20_Click(object sender, EventArgs e)
        {
            int lowerBound = 65;
            int upperBound = 200;
            if (int.TryParse(dimJ.Text, out int dimJValue))
            {


                if (dimJValue < lowerBound)
                {
                    dimJ.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimJValue > upperBound)
                {
                    dimJ.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                dimJ.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label19.ForeColor = Color.RoyalBlue;
            label20.ForeColor = Color.RoyalBlue;
            { this.dn3.Enabled = true; }
            { this.label69.Enabled = true; }
            { this.label70.Enabled = true; }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        // DN3 validator
        private void label70_Click(object sender, EventArgs e)
        {
            int dn2Value = int.Parse(dn2.SelectedItem.ToString());
            int dn3Value;

            if (int.TryParse(dn3.Text, out dn3Value) && int.TryParse(dn2.Text, out dn2Value))
            {
                string selectedValue = dn2.SelectedItem.ToString();
                int selectedIndex = dn2.SelectedIndex;
                string largestItemAvailable = dn2.Items[selectedIndex + 2].ToString();
                int lowerBound = Math.Max(50, Convert.ToInt32(dn2Value));
                int upperBound = Math.Min(400, Convert.ToInt32(largestItemAvailable));

                if (dn3Value < lowerBound)
                {
                    dn3.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dn3Value > upperBound)
                {
                    dn3.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                string selectedValue = dn2.SelectedItem.ToString();
                int selectedIndex = dn2.SelectedIndex;
                string largestItemAvailable = dn2.Items[selectedIndex + 2].ToString();
                int lowerBound = Math.Max(50, Convert.ToInt32(dn2Value));
                int upperBound = Math.Min(400, Convert.ToInt32(largestItemAvailable));
                dn3.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} m and {upperBound} m." +
                        $"\nValue modified to lower limit!");
            }
            label69.ForeColor = Color.RoyalBlue;
            label70.ForeColor = Color.RoyalBlue;
            { this.dn4.Enabled = true; }
            { this.label71.Enabled = true; }
            { this.label72.Enabled = true; }
            pressurePipeVelocity.Text = Math.Round(((double.Parse(flow.Text) / double.Parse(duty.Text) / 3600) / (Math.Pow(double.Parse(dn3.Text) / 1000, 2) * Math.PI / 4)), 1).ToString();

        }
        // DN4 validator
        private void label72_Click(object sender, EventArgs e)
        {
            int dn3Value = int.Parse(dn3.SelectedItem.ToString());
            int dn4Value;

            if (int.TryParse(dn3.Text, out dn3Value) && int.TryParse(dn4.Text, out dn4Value))
            {
                int lowerBound = dn3Value;
                int upperBound = 500;

                if (dn4Value < lowerBound)
                {
                    dn4.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dn4Value > upperBound)
                {
                    dn4.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                int lowerBound = dn3Value;
                int upperBound = 500;
                dn4.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} m and {upperBound} m." +
                        $"\nValue modified to lower limit!");
            }
            label71.ForeColor = Color.RoyalBlue;
            label72.ForeColor = Color.RoyalBlue;
            { this.dn5.Enabled = true; }
            { this.label87.Enabled = true; }
            { this.label88.Enabled = true; }
        }
        // DN5 validator
        private void label88_Click(object sender, EventArgs e)
        {
            int dn4Value = int.Parse(dn4.SelectedItem.ToString());
            int dn5Value;

            if (int.TryParse(dn5.Text, out dn5Value) && int.TryParse(dn4.Text, out dn4Value))
            {
                string selectedValue = dn4.SelectedItem.ToString();
                int selectedIndex = dn4.SelectedIndex;
                string smallestItemAvailable = dn4.Items[Math.Max(1, selectedIndex - 2)].ToString();
                int lowerBound = Convert.ToInt32(smallestItemAvailable);
                int upperBound = dn4Value;

                if (dn5Value < lowerBound)
                {
                    dn5.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dn5Value > upperBound)
                {
                    dn5.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                string selectedValue = dn4.SelectedItem.ToString();
                int selectedIndex = dn4.SelectedIndex;
                string smallestItemAvailable = dn4.Items[Math.Max(1, selectedIndex - 2)].ToString();
                int lowerBound = Convert.ToInt32(smallestItemAvailable);
                int upperBound = dn4Value;
                dn5.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} m and {upperBound} m." +
                        $"\nValue modified to lower limit!");
            }
            label87.ForeColor = Color.RoyalBlue;
            label88.ForeColor = Color.RoyalBlue;
            { this.dimK.Enabled = true; }
            { this.label85.Enabled = true; }
            { this.label86.Enabled = true; }
        }
        // DimK validator
        private void label86_Click(object sender, EventArgs e)
        {
            int lowerBound = 500;
            int upperBound = 3000;
            if (int.TryParse(dimK.Text, out int dimKValue))
            {


                if (dimKValue < lowerBound)
                {
                    dimK.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimKValue > upperBound)
                {
                    dimK.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                dimK.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label85.ForeColor = Color.RoyalBlue;
            label86.ForeColor = Color.RoyalBlue;
            { this.dimL.Enabled = true; }
            { this.label83.Enabled = true; }
            { this.label84.Enabled = true; }
        }
        // DimL validator
        private void label84_Click(object sender, EventArgs e)
        {
            int lowerBound = 500;
            int upperBound = 1500;
            if (int.TryParse(dimL.Text, out int dimLValue))
            {


                if (dimLValue < lowerBound)
                {
                    dimL.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimLValue > upperBound)
                {
                    dimL.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                dimL.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label83.ForeColor = Color.RoyalBlue;
            label84.ForeColor = Color.RoyalBlue;
            { this.dimM.Enabled = true; }
            { this.label81.Enabled = true; }
            { this.label82.Enabled = true; }
        }
        // DimM validator
        private void label82_Click(object sender, EventArgs e)
        {
            double dn3Value;

            if (double.TryParse(dn3.Text, out dn3Value) && int.TryParse(dimM.Text, out int dimMValue))
            {
                int lowerBound = Convert.ToInt32(dn3Value * 1.5);
                int upperBound = 1500;

                if (dimMValue < lowerBound)
                {
                    dimM.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimMValue > upperBound)
                {
                    dimM.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }

                else { }
            }
            else
            {
                int lowerBound = Convert.ToInt32(dn3Value * 1.5);
                int upperBound = 1500;
                dimM.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label81.ForeColor = Color.RoyalBlue;
            label82.ForeColor = Color.RoyalBlue;
            { this.dimN.Enabled = true; }
            { this.label79.Enabled = true; }
            { this.label80.Enabled = true; }
        }
        // DimN validator
        private void label80_Click(object sender, EventArgs e)
        {
            int lowerBound = 500;
            int upperBound = 3000;
            if (int.TryParse(dimN.Text, out int dimNValue))
            {


                if (dimNValue < lowerBound)
                {
                    dimN.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimNValue > upperBound)
                {
                    dimN.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                dimN.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label79.ForeColor = Color.RoyalBlue;
            label80.ForeColor = Color.RoyalBlue;
            { this.dimO.Enabled = true; }
            { this.label77.Enabled = true; }
            { this.label78.Enabled = true; }
        }
        // DimP validator
        private void label76_Click(object sender, EventArgs e)
        {
            double dn3Value;
            int lowerBound = 0;
            int upperBound = 0;

            if (double.TryParse(dn3.Text, out dn3Value) && int.TryParse(dimP.Text, out int dimPValue))
            {
                if (dn3Value < 80)
                {
                    lowerBound = Convert.ToInt32(2 * Math.Ceiling(dn3Value / 0.4) + 50);
                }
                else if (dn3Value < 125)
                {
                    lowerBound = Convert.ToInt32(2 * Math.Ceiling(dn3Value / 0.6) + 50);
                }
                else
                {
                    lowerBound = Convert.ToInt32(2 * Math.Ceiling(dn3Value / 0.7) + 50);
                }

                if (dn3Value < 80)
                {
                    upperBound = Convert.ToInt32(2 * Math.Ceiling(dn3Value / 0.4) + 1000);
                }
                else if (dn3Value < 125)
                {
                    upperBound = Convert.ToInt32(2 * Math.Ceiling(dn3Value / 0.6) + 1000);
                }
                else
                {
                    upperBound = Convert.ToInt32(2 * Math.Ceiling(dn3Value / 0.7) + 1000);
                }

                if (dimPValue < lowerBound)
                {
                    dimP.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimPValue > upperBound)
                {
                    dimP.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }

                else { }
            }
            else
            {
                if (dn3Value < 80)
                {
                    lowerBound = Convert.ToInt32(2 * (dn3Value + Math.Ceiling(dn3Value / 4) * 10) + 50);
                }
                else if (dn3Value < 125)
                {
                    lowerBound = Convert.ToInt32(2 * (dn3Value + Math.Ceiling(dn3Value / 6) * 10) + 50);
                }
                else
                {
                    lowerBound = Convert.ToInt32(2 * (dn3Value + Math.Ceiling(dn3Value / 7) * 10 + 50));
                }

                if (dn3Value < 80)
                {
                    upperBound = Convert.ToInt32(2 * (dn3Value + Math.Ceiling(dn3Value / 4) * 10) + 1000);
                }
                else if (dn3Value < 125)
                {
                    upperBound = Convert.ToInt32(2 * (dn3Value + Math.Ceiling(dn3Value / 6) * 10) + 1000);
                }
                else
                {
                    upperBound = Convert.ToInt32(2 * (dn3Value + Math.Ceiling(dn3Value / 7) * 10) + 1000);
                }

                dimP.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label76.ForeColor = Color.RoyalBlue;
            label75.ForeColor = Color.RoyalBlue;
            { this.dimQ.Enabled = true; }
            { this.label73.Enabled = true; }
            { this.label74.Enabled = true; }
        }
        // SAVE
        private void button1_Click(object sender, EventArgs e)
        {
            var designPeakHourFlow = new VolumetricFlow(Convert.ToDouble(flow.Text));
            var head = new Length(Convert.ToDouble(this.head.Text)*1000);
            var dutyPumpsCount = new VolumetricFlow(Convert.ToInt32(duty.Text));
            var standbyPumpsCount = new VolumetricFlow(Convert.ToInt32(standby.Text));
            var numberOfPumps = new VolumetricFlow(dutyPumpsCount.Value + standbyPumpsCount.Value);
            var dn1 = new Length(Convert.ToInt32(this.dn1.Text));
            var dn2 = new Length(Convert.ToInt32(this.dn2.Text));
            var dn3 = new Length(Convert.ToInt32(this.dn3.Text));
            var dn4 = new Length(Convert.ToInt32(this.dn4.Text));
            var dn5 = new Length(Convert.ToInt32(this.dn5.Text));
            var dnInlet = new Length(Convert.ToInt32(this.dnInlet.Text));
            var dnBackflow = new Length(Convert.ToInt32(this.dnBackflow.Text));
            var dnBreath = new Length(Convert.ToInt32(this.dnBreath.Text));
            var levA = new Length(Convert.ToInt32(this.levA.Text));
            var levB = new Length(Convert.ToInt32(this.levB.Text));
            var levC = new Length(Convert.ToInt32(this.levC.Text));
            var levD = new Length(Convert.ToInt32(this.levD.Text));
            var levE = new Length(Convert.ToInt32(this.levE.Text));
            var levF = new Length(Convert.ToInt32(this.levF.Text));
            var levG = new Length(Convert.ToInt32(this.levG.Text));
            var levH = new Length(Convert.ToInt32(this.levH.Text));
            var levI = new Length(Convert.ToInt32(this.levI.Text));
            var dimA = new Length(Convert.ToInt32(this.dimA.Text)); 
            var dimB = new Length(Convert.ToInt32(this.dimB.Text));
            var dimC = new Length(Convert.ToInt32(this.dimC.Text));
            var dimD = new Length(Convert.ToInt32(this.dimD.Text));
            var dimE = new Length(Convert.ToInt32(this.dimE.Text));
            var dimF = new Length(Convert.ToInt32(this.dimF.Text));
            var dimG = new Length(Convert.ToInt32(this.dimG.Text));
            var dimH = new Length(Convert.ToInt32(this.dimH.Text));
            var dimI = new Length(Convert.ToInt32(this.dimI.Text));
            var dimJ = new Length(Convert.ToInt32(this.dimJ.Text));
            var dimK = new Length(Convert.ToInt32(this.dimK.Text));
            var dimL = new Length(Convert.ToInt32(this.dimL.Text));
            var dimM = new Length(Convert.ToInt32(this.dimM.Text));
            var dimN = new Length(Convert.ToInt32(this.dimN.Text));
            var dimO = new Length(Convert.ToInt32(this.dimO.Text));
            var dimP = new Length(Convert.ToInt32(this.dimP.Text));
            var dimQ = new Length(Convert.ToInt32(this.dimQ.Text));
            var dimR = new Length(Convert.ToInt32(this.dimR.Text));
            var dimS = new Length(Convert.ToInt32(this.dimS.Text));
            var dimT = new Length(Convert.ToInt32(this.dimT.Text));
            var dimU = new Length(Convert.ToInt32(this.dimU.Text));
            var dimV = new Length(Convert.ToInt32(this.dimV.Text));
            var dimX = new Length(Convert.ToInt32(this.dimX.Text));
            var dimY = new Length(Convert.ToInt32(this.dimY.Text));
            var dimW = new Length(Convert.ToInt32(this.dimW.Text));
            var dimZ = new Length(Convert.ToInt32(this.dimZ.Text));
            var wetWellDepth = new Length(levA.Value + levB.Value + levC.Value + levD.Value + levE.Value + levF.Value + levG.Value + levH.Value + levI.Value);
            var manholeX = new Length((Math.Round((dimE.Value + dimF.Value + dimH.Value + dimJ.Value) / 100) * 100) + 100);
            var manholeY = new Length(Math.Round((dimH.Value / 100) * 100) + 200);
            var slopeStart = new Length((Math.Round((dimM.Value + dimE.Value + dimF.Value + dimG.Value + dimH.Value / 2) / 10) * 10) + 200);

            var revitFeed = new RevitFeederDTO(designPeakHourFlow, head, dutyPumpsCount, standbyPumpsCount, numberOfPumps, dn1, dn2, dn3, dn4, dn5, dnInlet, dnBackflow, dnBreath, levA, levB, levC, levD, levE, levF, levG, levH, levI, dimA, dimB, dimC, dimD, dimE, dimF, dimG, dimH, dimI, dimJ, dimK, dimL, dimM, dimN, dimO, dimP, dimQ, dimR, dimS, dimT, dimU, dimV, dimX, dimY, dimW, dimZ, wetWellDepth, manholeX, manholeY, slopeStart);
            WriteToJsonFile<RevitFeederDTO>($"C:\\RevitTest\\AdvancedInput-Flow{designPeakHourFlow.Value}-D{dutyPumpsCount}-S{standbyPumpsCount}-DN{dn1.Value}.json", revitFeed);
            MessageBox.Show($"Saved to" +
                        $"\nC:\\RevitTest\\AdvancedInput-Flow{designPeakHourFlow.Value}-D{dutyPumpsCount}-S{standbyPumpsCount}-DN{dn1.Value}.json");
        }
        // DimO validator
        private void label78_Click(object sender, EventArgs e)
        {
            double dn3Value;
            int lowerBound = 0;
            int upperBound = 0;

            if (double.TryParse(dn3.Text, out dn3Value) && int.TryParse(dimO.Text, out int dimOValue))
            {
                if (dn3Value < 80)
                {
                    lowerBound = Convert.ToInt32(100 + dn3Value + Math.Ceiling(dn3Value / 4) * 10);
                }
                else if (dn3Value < 125)
                {
                    lowerBound = Convert.ToInt32(100 + dn3Value + Math.Ceiling(dn3Value / 6) * 10);
                }
                else
                {
                    lowerBound = Convert.ToInt32(100 + dn3Value + Math.Ceiling(dn3Value / 7) * 10);
                }

                if (dn3Value < 80)
                {
                    upperBound = Convert.ToInt32(1000 + dn3Value + Math.Ceiling(dn3Value / 4) * 10);
                }
                else if (dn3Value < 125)
                {
                    upperBound = Convert.ToInt32(1000 + dn3Value + Math.Ceiling(dn3Value / 6) * 10);
                }
                else
                {
                    upperBound = Convert.ToInt32(1000 + dn3Value + Math.Ceiling(dn3Value / 7) * 10);
                }

                if (dimOValue < lowerBound)
                {
                    dimO.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimOValue > upperBound)
                {
                    dimO.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }

                else { }
            }
            else
            {
                if (dn3Value < 80)
                {
                    lowerBound = Convert.ToInt32(100 + dn3Value + Math.Ceiling(dn3Value / 4) * 10);
                }
                else if (dn3Value < 125)
                {
                    lowerBound = Convert.ToInt32(100 + dn3Value + Math.Ceiling(dn3Value / 6) * 10);
                }
                else
                {
                    lowerBound = Convert.ToInt32(100 + dn3Value + Math.Ceiling(dn3Value / 7) * 10);
                }

                if (dn3Value < 80)
                {
                    upperBound = Convert.ToInt32(1000 + dn3Value + Math.Ceiling(dn3Value / 4) * 10);
                }
                else if (dn3Value < 125)
                {
                    upperBound = Convert.ToInt32(1000 + dn3Value + Math.Ceiling(dn3Value / 6) * 10);
                }
                else
                {
                    upperBound = Convert.ToInt32(1000 + dn3Value + Math.Ceiling(dn3Value / 7) * 10);
                }

                dimO.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label77.ForeColor = Color.RoyalBlue;
            label78.ForeColor = Color.RoyalBlue;
            { this.dimP.Enabled = true; }
            { this.label75.Enabled = true; }
            { this.label76.Enabled = true; }
        }
        // DimQ validator
        private void label74_Click(object sender, EventArgs e)
        {
            double dn3Value = double.Parse(dn3.Text);
            double dn4Value = double.Parse(dn4.Text);
            int lowerBound = 0;
            int upperBound = 0;

            if (double.TryParse(dn3.Text, out dn3Value) && double.TryParse(dn4.Text, out dn4Value) && int.TryParse(dimQ.Text, out int dimQValue))
            {
                if (dn3Value < 80)
                {
                    lowerBound = Convert.ToInt32(dn4Value + 15 + Math.Ceiling(dn3Value / 0.4));
                }
                else if (dn3Value < 125)
                {
                    lowerBound = Convert.ToInt32(dn4Value + 15 + Math.Ceiling(dn3Value / 0.6));
                }
                else
                {
                    lowerBound = Convert.ToInt32(dn4Value + 15 + Math.Ceiling(dn3Value / 0.7));
                }

                if (dn3Value < 80)
                {
                    upperBound = Convert.ToInt32(1000 + Math.Ceiling(dn3Value / 0.4));
                }
                else if (dn3Value < 125)
                {
                    upperBound = Convert.ToInt32(1000 + Math.Ceiling(dn3Value / 0.6));
                }
                else
                {
                    upperBound = Convert.ToInt32(1000 + Math.Ceiling(dn3Value / 0.7));
                }

                if (dimQValue < lowerBound)
                {
                    dimQ.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimQValue > upperBound)
                {
                    dimQ.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }

                else { }
            }
            else
            {
                if (dn3Value < 80)
                {
                    lowerBound = Convert.ToInt32(dn4Value + 15 + Math.Ceiling(dn3Value / 0.4));
                }
                else if (dn3Value < 125)
                {
                    lowerBound = Convert.ToInt32(dn4Value + 15 + Math.Ceiling(dn3Value / 0.6));
                }
                else
                {
                    lowerBound = Convert.ToInt32(dn4Value + 15 + Math.Ceiling(dn3Value / 0.7));
                }

                if (dn3Value < 80)
                {
                    upperBound = Convert.ToInt32(1000 + Math.Ceiling(dn3Value / 0.4));
                }
                else if (dn3Value < 125)
                {
                    upperBound = Convert.ToInt32(1000 + Math.Ceiling(dn3Value / 0.6));
                }
                else
                {
                    upperBound = Convert.ToInt32(1000 + Math.Ceiling(dn3Value / 0.7));
                }

                dimQ.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label73.ForeColor = Color.RoyalBlue;
            label74.ForeColor = Color.RoyalBlue;
            { this.dimR.Enabled = true; }
            { this.label91.Enabled = true; }
            { this.label92.Enabled = true; }
        }
        // DimR validator
        private void label92_Click(object sender, EventArgs e)
        {
            double dn4Value;

            if (double.TryParse(dn4.Text, out dn4Value) && int.TryParse(dimR.Text, out int dimRValue))
            {
                int lowerBound = Convert.ToInt32(Math.Round(((dn4Value / 2) + 510) / 5) * 5);
                int upperBound = Convert.ToInt32(Math.Round(((dn4Value / 2) + 1510) / 5) * 5);

                if (dimRValue < lowerBound)
                {
                    dimR.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimRValue > upperBound)
                {
                    dimR.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }

                else { }
            }
            else
            {
                int lowerBound = Convert.ToInt32(Math.Round(((dn4Value / 2) + 510) / 5) * 5);
                int upperBound = Convert.ToInt32(Math.Round(((dn4Value / 2) + 1510) / 5) * 5);
                dimR.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label91.ForeColor = Color.RoyalBlue;
            label92.ForeColor = Color.RoyalBlue;
            { this.levA.Enabled = true; }
            { this.label41.Enabled = true; }
            { this.label42.Enabled = true; }
        }
        // DimS validator
        private void label90_Click(object sender, EventArgs e)
        {
            double dn4Value;

            if (double.TryParse(dn4.Text, out dn4Value) && int.TryParse(dimS.Text, out int dimSValue))
            {
                int lowerBound = Convert.ToInt32(Math.Round(dn4Value * 1.5));
                int upperBound = 1000;

                if (dimSValue < lowerBound)
                {
                    dimS.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimSValue > upperBound)
                {
                    dimS.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }

                else { }
            }
            else
            {
                int lowerBound = Convert.ToInt32(Math.Round(dn4Value * 1.5));
                int upperBound = 1000;
                dimS.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label89.ForeColor = Color.RoyalBlue;
            label90.ForeColor = Color.RoyalBlue;
            { this.dimT.Enabled = true; }
            { this.label67.Enabled = true; }
            { this.label68.Enabled = true; }
        }


        // DimT validator
        private void label68_Click(object sender, EventArgs e)
        {
            double dn3Value = double.Parse(dn3.Text);
            double dimSValue = double.Parse(dimS.Text);
            int levAValue = int.Parse(levA.Text);
            int levBValue = int.Parse(levB.Text);
            int levCValue = int.Parse(levC.Text);
            int levDValue = int.Parse(levD.Text);
            int levEValue = int.Parse(levE.Text);
            int levFValue = int.Parse(levF.Text);
            int levGValue = int.Parse(levG.Text);
            int levHValue = int.Parse(levH.Text);
            int levIValue = int.Parse(levI.Text);


            if (double.TryParse(dn3.Text, out dn3Value) && double.TryParse(dimS.Text, out dimSValue) && int.TryParse(dimT.Text, out int dimTValue)
                && int.TryParse(levA.Text, out levAValue) && int.TryParse(levB.Text, out levBValue) && int.TryParse(levC.Text, out levCValue)
                && int.TryParse(levD.Text, out levDValue) && int.TryParse(levE.Text, out levEValue) && int.TryParse(levF.Text, out levFValue)
                && int.TryParse(levG.Text, out levGValue) && int.TryParse(levH.Text, out levHValue) && int.TryParse(levI.Text, out levIValue))
            {
                int lowerBound;
                int upperBound = levAValue + levBValue + levCValue + levDValue + levEValue + levFValue + levGValue + levHValue + levIValue;
                if (dn3Value < 80)
                {
                    lowerBound = Convert.ToInt32(dimSValue + Math.Ceiling(dn3Value / 0.4) + dn3Value);
                }
                else if (dn3Value < 125)
                {
                    lowerBound = Convert.ToInt32(dimSValue + Math.Ceiling(dn3Value / 0.6) + dn3Value);
                }
                else
                {
                    lowerBound = Convert.ToInt32(dimSValue + Math.Ceiling(dn3Value / 0.7) + dn3Value);
                }

                if (dimTValue < lowerBound)
                {
                    dimT.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimTValue > upperBound)
                {
                    dimT.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }

                else { }
            }
            else
            {
                int lowerBound;
                int upperBound = levAValue + levBValue + levCValue + levDValue + levEValue + levFValue + levGValue + levHValue + levIValue;
                if (dn3Value < 80)
                {
                    lowerBound = Convert.ToInt32(dimSValue + Math.Ceiling(dn3Value / 0.4));
                }
                else if (dn3Value < 125)
                {
                    lowerBound = Convert.ToInt32(dimSValue + Math.Ceiling(dn3Value / 0.6));
                }
                else
                {
                    lowerBound = Convert.ToInt32(dimSValue + Math.Ceiling(dn3Value / 0.7));
                }

                dimT.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label67.ForeColor = Color.RoyalBlue;
            label68.ForeColor = Color.RoyalBlue;
            { this.dimU.Enabled = true; }
            { this.label65.Enabled = true; }
            { this.label66.Enabled = true; }

        }
        // LevA validator
        private void label42_Click(object sender, EventArgs e)
        {
            int dnInletValue = int.Parse(dnInlet.Text);
            int lowerBound = 500;
            int upperBound = 5000;
            if (int.TryParse(levA.Text, out int levAValue) && int.TryParse(dnInlet.Text, out dnInletValue))
            {
                if (2 * dnInletValue < 500)
                { lowerBound = 500; }
                else { lowerBound = 2 * dnInletValue; }

                if (levAValue < lowerBound)
                {
                    levA.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (levAValue > upperBound)
                {
                    levA.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                levA.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label41.ForeColor = Color.RoyalBlue;
            label42.ForeColor = Color.RoyalBlue;
            { this.levB.Enabled = true; }
            { this.label39.Enabled = true; }
            { this.label40.Enabled = true; }
        }
        // LevB validator
        private void label40_Click(object sender, EventArgs e)
        {
            int levAValue = int.Parse(levA.Text);
            int lowerBound = 500 - levAValue;
            int upperBound = 5000;
            int levBValue = Math.Max(int.Parse(levB.Text), lowerBound);
            
            if (int.TryParse(levA.Text, out levAValue) && int.TryParse(levB.Text, out levBValue))
            {
                if (levAValue + levBValue < 500)
                { lowerBound = 500 - levAValue; }
                else { lowerBound = levBValue; }

                if (levBValue < lowerBound)
                {
                    levB.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (levBValue > upperBound)
                {
                    levB.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                levB.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label39.ForeColor = Color.RoyalBlue;
            label40.ForeColor = Color.RoyalBlue;
            { this.levC.Enabled = true; }
            { this.label37.Enabled = true; }
            { this.label38.Enabled = true; }
        }
        // LevC validator
        private void label38_Click(object sender, EventArgs e)
        {
            int lowerBound = 200;
            int upperBound = 5000;
            if (int.TryParse(levC.Text, out int levCValue))
            {
                if (levCValue < lowerBound)
                {
                    levC.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (levCValue > upperBound)
                {
                    levC.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                levC.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label37.ForeColor = Color.RoyalBlue;
            label38.ForeColor = Color.RoyalBlue;
            { this.levD.Enabled = true; }
            { this.label35.Enabled = true; }
            { this.label36.Enabled = true; }
        }
        // LevD validator
        private void label36_Click(object sender, EventArgs e)
        {
            int lowerBound = 200;
            int upperBound = 5000;
            if (int.TryParse(levD.Text, out int levDValue))
            {
                if (levDValue < lowerBound)
                {
                    levD.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (levDValue > upperBound)
                {
                    levD.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                levD.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label35.ForeColor = Color.RoyalBlue;
            label36.ForeColor = Color.RoyalBlue;
            { this.levE.Enabled = true; }
            { this.label33.Enabled = true; }
            { this.label34.Enabled = true; }
        }
        // LevE validator
        private void label34_Click(object sender, EventArgs e)
        {
            int lowerBound = 200;
            int upperBound = 5000;
            if (int.TryParse(levE.Text, out int levEValue))
            {
                if (levEValue < lowerBound)
                {
                    levE.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (levEValue > upperBound)
                {
                    levE.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                levE.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label33.ForeColor = Color.RoyalBlue;
            label34.ForeColor = Color.RoyalBlue;
            { this.levF.Enabled = true; }
            { this.label31.Enabled = true; }
            { this.label32.Enabled = true; }
        }
        // LevF validator
        private void label32_Click(object sender, EventArgs e)
        {
            int lowerBound = 200;
            int upperBound = 5000;
            if (int.TryParse(levF.Text, out int levFValue))
            {
                if (levFValue < lowerBound)
                {
                    levE.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (levFValue > upperBound)
                {
                    levF.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                levF.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label31.ForeColor = Color.RoyalBlue;
            label32.ForeColor = Color.RoyalBlue;
            { this.levG.Enabled = true; }
            { this.label29.Enabled = true; }
            { this.label30.Enabled = true; }
        }
        // LevG validator
        private void label30_Click(object sender, EventArgs e)
        {
            int lowerBound = 200;
            int upperBound = 5000;
            if (int.TryParse(levG.Text, out int levGValue))
            {
                if (levGValue < lowerBound)
                {
                    levG.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (levGValue > upperBound)
                {
                    levG.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                levG.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label29.ForeColor = Color.RoyalBlue;
            label30.ForeColor = Color.RoyalBlue;
            { this.levH.Enabled = true; }
            { this.label27.Enabled = true; }
            { this.label28.Enabled = true; }
        }
        // LevH validator
        private void label28_Click(object sender, EventArgs e)
        {
            int lowerBound = 200;
            int upperBound = 5000;
            if (int.TryParse(levH.Text, out int levHValue))
            {
                if (levHValue < lowerBound)
                {
                    levH.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (levHValue > upperBound)
                {
                    levH.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                levH.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label27.ForeColor = Color.RoyalBlue;
            label28.ForeColor = Color.RoyalBlue;
            { this.levI.Enabled = true; }
            { this.label43.Enabled = true; }
            { this.label44.Enabled = true; }
        }
        // LevI validator
        private void label44_Click(object sender, EventArgs e)
        {
            int lowerBound = 200;
            int upperBound = 5000;
            if (int.TryParse(levI.Text, out int levIValue))
            {
                if (levIValue < lowerBound)
                {
                    levI.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (levIValue > upperBound)
                {
                    levI.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                levI.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label43.ForeColor = Color.RoyalBlue;
            label44.ForeColor = Color.RoyalBlue;
            { this.dimS.Enabled = true; }
            { this.label89.Enabled = true; }
            { this.label90.Enabled = true; }
            textBox1.Text = (int.Parse(levA.Text) + int.Parse(levB.Text) + int.Parse(levC.Text)
                           + int.Parse(levD.Text) + int.Parse(levE.Text) + int.Parse(levF.Text)
                           + int.Parse(levE.Text) + int.Parse(levG.Text) + int.Parse(levH.Text)).ToString();
        }
        // DimU validator
        private void label66_Click(object sender, EventArgs e)
        {
            int lowerBound = 100;
            int upperBound = 400;
            if (int.TryParse(dimU.Text, out int dimUValue))
            {
                if (dimUValue < lowerBound)
                {
                    dimU.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimUValue > upperBound)
                {
                    dimU.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                dimU.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label65.ForeColor = Color.RoyalBlue;
            label66.ForeColor = Color.RoyalBlue;
            { this.dimV.Enabled = true; }
            { this.label63.Enabled = true; }
            { this.label64.Enabled = true; }
        }
        // DimV validator
        private void label64_Click(object sender, EventArgs e)
        {
            int lowerBound = 100;
            int upperBound = 400;
            if (int.TryParse(dimV.Text, out int dimVValue))
            {
                if (dimVValue < lowerBound)
                {
                    dimV.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimVValue > upperBound)
                {
                    dimV.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                dimV.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label63.ForeColor = Color.RoyalBlue;
            label64.ForeColor = Color.RoyalBlue;
            { this.dimX.Enabled = true; }
            { this.label61.Enabled = true; }
            { this.label62.Enabled = true; }
        }
        // DimX validator
        private void label62_Click(object sender, EventArgs e)
        {
            int dimKValue = int.Parse(dimK.Text);
            int dimHValue = int.Parse(dimH.Text);
            int dimLValue = int.Parse(dimL.Text);
            int dutyValue = int.Parse(duty.Text);
            int standbyValue = int.Parse(standby.Text);
            int dimXValue;

            if (int.TryParse(dimK.Text, out dimKValue) && int.TryParse(dimX.Text, out dimXValue)
                && int.TryParse(dimH.Text, out dimHValue) && int.TryParse(dimL.Text, out dimLValue)
                && int.TryParse(duty.Text, out dutyValue) && int.TryParse(standby.Text, out standbyValue))
            {
                int noPumps = dutyValue + standbyValue;
                int lowerBound = 2 * dimKValue + noPumps * dimHValue + (noPumps - 1) * dimLValue;
                int upperBound = 2 * dimKValue + (noPumps + 1) * dimHValue + noPumps * dimLValue;
                if (dimXValue < lowerBound)
                {
                    dimX.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimXValue > upperBound)
                {
                    dimX.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                int noPumps = dutyValue + standbyValue;
                int lowerBound = 2 * dimKValue + noPumps * dimHValue + (noPumps - 1) * dimLValue;
                int upperBound = 2 * dimKValue + (noPumps + 1) * dimHValue + noPumps * dimLValue;
                dimX.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label61.ForeColor = Color.RoyalBlue;
            label62.ForeColor = Color.RoyalBlue;
            { this.dimY.Enabled = true; }
            { this.label59.Enabled = true; }
            { this.label60.Enabled = true; }
        }
        // DimY validator
        private void label60_Click(object sender, EventArgs e)
        {
            double dimMValue = int.Parse(dimM.Text);
            double dimEValue = int.Parse(dimE.Text);
            double dimFValue = int.Parse(dimF.Text);
            double dimGValue = int.Parse(dimG.Text);
            double dimHValue = int.Parse(dimH.Text);
            double dimKValue = int.Parse(dimK.Text);
            double dimLValue = int.Parse(dimL.Text);
            double dn4Value = int.Parse(dn4.Text);
            double dimNValue = int.Parse(dimN.Text);
            double dimOValue = int.Parse(dimO.Text);
            double dimPValue = int.Parse(dimP.Text);
            double dimQValue = int.Parse(dimQ.Text);
            double dimRValue = int.Parse(dimR.Text);
            double dimUValue = int.Parse(dimU.Text);
            double dimVValue = int.Parse(dimV.Text);
            double dutyValue = int.Parse(duty.Text);
            double standbyValue = int.Parse(standby.Text);
            double noPumps = dutyValue + standbyValue;
            double dnInletValue = int.Parse(dnInlet.Text);
            int lowerBound = (int)Math.Ceiling(((dimMValue + dimEValue + dimFValue + dimGValue + dimHValue / 2) / 10) * 10 + 800 + Math.Max(dnInletValue * 2, 500) + 150);
            int upperBound = (int)Math.Ceiling(((dimMValue + dimEValue + dimFValue + dimGValue + dimHValue / 2) / 10) * 10 + 800 + Math.Max(dnInletValue * 2, 500) + 150 + 2000);
            if (int.TryParse(dimY.Text, out int dimYValue) && double.TryParse(dimM.Text, out dimMValue)
                && double.TryParse(dimE.Text, out dimEValue) && double.TryParse(dimF.Text, out dimFValue)
                && double.TryParse(dimG.Text, out dimGValue) && double.TryParse(dimH.Text, out dimHValue)
                && double.TryParse(dnInlet.Text, out dnInletValue) && double.TryParse(dn4.Text, out dn4Value)
                && double.TryParse(dimK.Text, out dimKValue) && double.TryParse(dimL.Text, out dimLValue)
                && double.TryParse(duty.Text, out dutyValue) && double.TryParse(standby.Text, out standbyValue)
                && double.TryParse(dimN.Text, out dimNValue) && double.TryParse(dimO.Text, out dimOValue)
                && double.TryParse(dimP.Text, out dimPValue) && double.TryParse(dimQ.Text, out dimQValue)
                && double.TryParse(dimU.Text, out dimUValue) && double.TryParse(dimV.Text, out dimVValue)
                && double.TryParse(dimR.Text, out dimRValue))
            {
                if (dimYValue < lowerBound)
                {
                    dimY.Text = lowerBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
                }
                else if (dimYValue > upperBound)
                {
                    dimY.Text = upperBound.ToString();
                    MessageBox.Show($"Value has to fall between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to upper limit!");
                }
                else { }
            }
            else
            {
                dimY.Text = lowerBound.ToString();
                MessageBox.Show($"Feed me with integer between between {lowerBound} mm and {upperBound} mm." +
                        $"\nValue modified to lower limit!");
            }
            label59.ForeColor = Color.RoyalBlue;
            label60.ForeColor = Color.RoyalBlue;
            { this.save.Enabled = true; }
            dimZ.Text = (dimKValue + (noPumps - 1) * (dimHValue + dimLValue) + (dn4Value + 50) * 11).ToString();
            dimW.Text = (dimNValue + dimOValue + dimPValue + dimQValue + dimUValue + dimVValue + dimRValue).ToString();
        }

        public static void WriteToJsonFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()
        {
            TextWriter writer = null;
            try
            {
                var contentsToWriteToFile = JsonConvert.SerializeObject(objectToWrite);
                writer = new StreamWriter(filePath, append);
                writer.Write(contentsToWriteToFile);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        private void label45_Click(object sender, EventArgs e)
        {

        }

        private void dn3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dimW_TextChanged(object sender, EventArgs e)
        {

        }

        private void label58_Click(object sender, EventArgs e)
        {

        }

        private void label45_Click_1(object sender, EventArgs e)
        {

        }
    }
}
